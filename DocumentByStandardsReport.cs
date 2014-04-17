using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Qualtrax.Core.Common;
using Qualtrax.Core.Data;
using Qualtrax.Documents.Interfaces.Projectors;
using Qualtrax.Infrastructure.Database;
using Qualtrax.Reporting.Interfaces;

namespace Qualtrax.Core.Reporting.StandardReports
{
    public class DocumentByStandardsReport : IDocumentByStandardsReport
    {
        private IQualtraxConnection connection;
        private QualtraxCommand command;
        private IBrowseTreeChildDocumentsProvider childDocumentsProvider;

        public DocumentByStandardsReport(IQualtraxConnection connection, QualtraxCommand command, IBrowseTreeChildDocumentsProvider childDocumentsProvider)
        {
            this.connection = connection;
            this.command = command;
            this.childDocumentsProvider = childDocumentsProvider;
        }

        public DataSet GetReportData(IEnumerable<Int32> standardsSelected, IEnumerable<Int32> foldersSelected, IEnumerable<String> additionalFields, Boolean showEmptyStandards, Boolean showRetiredDocuments)
        {
            var additonalFieldsSql = GetAdditionalFieldsSql(additionalFields);

            if (showEmptyStandards)
                return GetReportDataShowingEmptyStandards(standardsSelected, foldersSelected, additonalFieldsSql, showRetiredDocuments);

            var whereFiltersSql = GetWhereFiltersSql(standardsSelected, foldersSelected, showRetiredDocuments);

            var sql = String.Format(@"SELECT sys.ORGANIZATION, sys.STANDARD, sys.DESCRIPTION, dmds.DOCID, dmd.TITLE{0} 
                                   FROM  SY_Standards sys 
                                   INNER JOIN DM_DocumentStandards dmds ON sys.Id = dmds.StandardID 
                                   INNER JOIN DM_Document dmd ON dmd.Id = dmds.DocId 
                                   INNER JOIN WF_States wfs ON dmd.StateId = wfs.Id 
                                   INNER JOIN DM_DocumentRevision dmdr ON (dmdr.DocId = dmd.Id AND dmdr.Revision = dmd.CurrentRevision) 
                                   {1}
                                   ORDER BY sys.Organization, sys.Standard, dmds.DocId", additonalFieldsSql, whereFiltersSql);

            var dataSet = new DataSet();
            command.ExecuteQuery(sql, ref dataSet);

            return dataSet;
        }

        private String GetWhereFiltersSql(IEnumerable<Int32> standardsSelected, IEnumerable<Int32> foldersSelected, Boolean showRetiredDocuments)
        {
            var whereFilters = GetWhereFilters(standardsSelected, foldersSelected);
            var whereFiltersWithoutLocation = whereFilters.Where(f => f != GetSqlForSelectedDocuments(foldersSelected));
            var retiredWhereFilters = new List<String>();

            if (showRetiredDocuments)
            {
                var retiredDocsSql = String.Format("dmd.StateId = {0}", Qualtrax.Core.Common.Constants.DOCUMENT.DOC_RETIRED_STATE);
                retiredWhereFilters.AddRange(whereFiltersWithoutLocation);
                retiredWhereFilters.Add(retiredDocsSql);
            }

            whereFilters.Add(String.Format("dmd.StateId <> {0}", Qualtrax.Core.Common.Constants.DOCUMENT.DOC_RETIRED_STATE));

            return GetWhereFilterSql(whereFilters, retiredWhereFilters);
        }

        public DataSet GetChartData(IEnumerable<Int32> standardsSelected, IEnumerable<Int32> foldersSelected, Boolean showEmptyStandards, Boolean showRetiredDocuments)
        {
            if (showEmptyStandards)
                return GetChartSqlShowingEmptyStandards(standardsSelected, foldersSelected, showRetiredDocuments);

            var whereFiltersSql = GetWhereFiltersSql(standardsSelected, foldersSelected, showRetiredDocuments);

            var sql = String.Format(@"SELECT sys.ORGANIZATION, sys.STANDARD, COUNT(sys.Standard) AMOUNT
                                   FROM SY_Standards sys
                                   INNER JOIN DM_DocumentStandards dmds ON sys.Id = dmds.StandardID
                                   INNER JOIN DM_Document dmd ON dmd.Id = dmds.DocId
                                   {0}
                                   GROUP BY sys.Organization, sys.Standard
                                   ORDER BY sys.Organization, sys.Standard", whereFiltersSql);

            var dataSet = new DataSet();
            command.ExecuteQuery(sql, ref dataSet);

            return dataSet;
        }

        private DataSet GetReportDataShowingEmptyStandards(IEnumerable<Int32> standardsSelected, IEnumerable<Int32> foldersSelected, String additionalFields, Boolean showRetiredDocuments)
        {
            var notRetiredDocsSql = String.Empty;
            var retiredWhereFilters = new List<String>();

            var whereFilters = GetWhereFilters(standardsSelected, foldersSelected);
            var whereFiltersWithoutLocation = whereFilters.Where(f => f != GetSqlForSelectedDocuments(foldersSelected));

            if (showRetiredDocuments)
            {
                var retiredDocumentsSql = String.Format("dmd.StateId = {0}", Qualtrax.Core.Common.Constants.DOCUMENT.DOC_RETIRED_STATE);
                retiredWhereFilters.AddRange(whereFiltersWithoutLocation);
                retiredWhereFilters.Add(retiredDocumentsSql);
            }
            else
            {
                notRetiredDocsSql = String.Format(" AND dmds.DocId IN (SELECT dmd2.Id FROM DM_Document dmd2 WHERE dmd2.StateId <> {0})", Constants.DOCUMENT.DOC_RETIRED_STATE);
            }

            var emptyStandardsWhereFilters = new List<String>();
            emptyStandardsWhereFilters.AddRange(whereFiltersWithoutLocation);
            emptyStandardsWhereFilters.Add("dmd.Id IS NULL");

            var nonEmptyStandardsWhereFilters = new List<String>();
            if (!whereFiltersWithoutLocation.Any())
                nonEmptyStandardsWhereFilters.Add("dmd.Id IS NOT NULL");

            var whereFiltersSql = GetWhereFilterSql(whereFilters, retiredWhereFilters, emptyStandardsWhereFilters, nonEmptyStandardsWhereFilters);

            var sql = String.Format(@"SELECT sys.ORGANIZATION, sys.STANDARD, sys.DESCRIPTION, dmd.Id AS DOCID, dmd.TITLE{0} 
                                   FROM SY_Standards sys 
                                   LEFT JOIN DM_DocumentStandards dmds ON (sys.Id = dmds.StandardID {1}) 
                                   LEFT JOIN DM_Document dmd ON dmd.Id = dmds.DocId 
                                   LEFT JOIN WF_States wfs ON dmd.StateId = wfs.Id 
                                   LEFT JOIN DM_DocumentRevision dmdr ON (dmdr.Docid = dmd.id AND dmdr.Revision = dmd.CurrentRevision) 
                                   {2}
                                   ORDER BY sys.Organization, sys.Standard, dmds.DocId", additionalFields, notRetiredDocsSql, whereFiltersSql);

            var dataSet = new DataSet();
            command.ExecuteQuery(sql, ref dataSet);

            return dataSet;
        }

        private DataSet GetChartSqlShowingEmptyStandards(IEnumerable<Int32> standardsSelected, IEnumerable<Int32> foldersSelected, Boolean showRetiredDocuments)
        {
            var notRetiredDocsSql = String.Empty;
            var retiredWhereFilters = new List<String>();
            var whereFilters = GetWhereFilters(standardsSelected, foldersSelected);
            var whereFiltersWithoutLocation = whereFilters.Where(f => f != GetSqlForSelectedDocuments(foldersSelected));

            var emptyStandardsWhereFilters = new List<String>();
            emptyStandardsWhereFilters.AddRange(whereFiltersWithoutLocation);
            emptyStandardsWhereFilters.Add("dmd.Id IS NULL");
            var emptyWhereFiltersSql = GetWhereFilterSql(emptyStandardsWhereFilters);

            whereFilters.Add("dmd.Id IS NOT NULL");

            if (showRetiredDocuments)
            {
                var retiredDocumentsSql = String.Format("dmd.StateId = {0}", Qualtrax.Core.Common.Constants.DOCUMENT.DOC_RETIRED_STATE);
                retiredWhereFilters.AddRange(whereFiltersWithoutLocation);
                retiredWhereFilters.Add("dmd.Id IS NOT NULL");
                retiredWhereFilters.Add(retiredDocumentsSql);
            }
            else
            {
                notRetiredDocsSql = String.Format(" AND dmds.DocId IN (SELECT dmd2.Id FROM DM_Document dmd2 WHERE dmd2.StateId <> {0})", Constants.DOCUMENT.DOC_RETIRED_STATE);
                whereFilters.Add(String.Format("dmd.StateId <> {0}", Qualtrax.Core.Common.Constants.DOCUMENT.DOC_RETIRED_STATE));
            }

            var nonEmptyWhereFiltersSql = GetWhereFilterSql(whereFilters, retiredWhereFilters);

            var sql = String.Format(@"SELECT sys.ORGANIZATION, sys.STANDARD, COUNT(sys.Standard) AMOUNT
                                   FROM SY_Standards sys 
                                   LEFT JOIN DM_DocumentStandards dmds ON (sys.Id = dmds.StandardID)
                                   LEFT JOIN DM_Document dmd ON (dmd.Id = dmds.DocId)
                                   {1} 
                                   GROUP BY sys.Organization, sys.Standard
                                   UNION
                                   SELECT sys.ORGANIZATION, sys.STANDARD, 0 AMOUNT
                                   FROM SY_Standards sys
                                   LEFT JOIN DM_DocumentStandards dmds ON (sys.Id = dmds.StandardID {0})
                                   LEFT JOIN DM_Document dmd on dmds.DocId = dmd.Id
                                   {2}
                                   GROUP BY sys.Organization, sys.Standard
                                   ORDER BY Organization, Standard", notRetiredDocsSql, nonEmptyWhereFiltersSql, emptyWhereFiltersSql);

            var dataSet = new DataSet();
            command.ExecuteQuery(sql, ref dataSet);

            return dataSet;
        }

        private List<String> GetWhereFilters(IEnumerable<Int32> standardsSelected, IEnumerable<Int32> foldersSelected)
        {
            var documentsSelectedSql = GetSqlForSelectedDocuments(foldersSelected);
            var standardsSelectedsql = GetSqlForSelectedStandards(standardsSelected);

            var whereFilters = new List<String>();

            if (!String.IsNullOrEmpty(documentsSelectedSql))
                whereFilters.Add(documentsSelectedSql);

            if (!String.IsNullOrEmpty(standardsSelectedsql))
                whereFilters.Add(standardsSelectedsql);

            whereFilters.Add("sys.Enabled = 1");

            return whereFilters;
        }

        private String GetSqlForSelectedDocuments(IEnumerable<Int32> foldersSelected)
        {
            if (!foldersSelected.Any())
                return String.Empty;

            var documentIds = childDocumentsProvider.GetChildDocumentIds(foldersSelected.ToArray());

            if (!documentIds.Any())
                return String.Format("dmds.DOCID IN ({0})", foldersSelected.First());

            var joinedDocumentIds = String.Join(",", documentIds);
            return String.Format("dmds.DOCID IN ({0})", joinedDocumentIds);
        }

        private String GetWhereFilterSql(params IEnumerable<String>[] whereAndFilters)
        {
            if (!whereAndFilters.Any())
                return String.Empty;

            var orStatements = new List<String>();

            foreach (var andFilters in whereAndFilters)
            {
                if (!andFilters.Any())
                    continue;

                var joinedAndFilters = String.Join(" AND ", andFilters);
                orStatements.Add(joinedAndFilters);
            }

            if (!orStatements.Any())
                return String.Empty;

            var joinedOrStatements = String.Join(") OR (", orStatements);
            return String.Format("WHERE ({0})", joinedOrStatements);
        }

        private String GetAdditionalFieldsSql(IEnumerable<String> additionalFields)
        {
            var additionalFieldsSql = String.Empty;

            if (!additionalFields.Any())
                return String.Empty;

            foreach (var additionalField in additionalFields)
                additionalFieldsSql += ", " + additionalField;

            return additionalFieldsSql;
        }

        private String GetSqlForSelectedStandards(IEnumerable<Int32> standardsSelected)
        {
            if (!standardsSelected.Any())
                return String.Empty;

            var joinedStandards = String.Join(",", standardsSelected);
            return String.Format("sys.Id IN ({0})", joinedStandards);
        }
    }
}