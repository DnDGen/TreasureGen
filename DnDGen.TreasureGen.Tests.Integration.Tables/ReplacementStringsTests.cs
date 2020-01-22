using NUnit.Framework;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;

namespace DnDGen.TreasureGen.Tests.Integration.Tables
{
    [TestFixture]
    public class ReplacementStringsTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Collections.Set.ReplacementStrings; }
        }

        [TestCase(TableNameConstants.Collections.Set.ReplacementStrings,
            ReplacementStringConstants.DesignatedFoe,
            ReplacementStringConstants.Gender,
            ReplacementStringConstants.Height,
            ReplacementStringConstants.KnowledgeCategory,
            ReplacementStringConstants.Energy,
            ReplacementStringConstants.PartialAlignment,
            ReplacementStringConstants.FullAlignment)]
        [TestCase(ReplacementStringConstants.DesignatedFoe,
            TableNameConstants.Percentiles.Set.DesignatedFoes)]
        [TestCase(ReplacementStringConstants.Gender,
            TableNameConstants.Percentiles.Set.Gender)]
        [TestCase(ReplacementStringConstants.Height,
            TableNameConstants.Percentiles.Set.CurseHeightChanges)]
        [TestCase(ReplacementStringConstants.KnowledgeCategory,
            TableNameConstants.Percentiles.Set.KnowledgeCategories)]
        [TestCase(ReplacementStringConstants.Energy,
            TableNameConstants.Percentiles.Set.Elements)]
        [TestCase(ReplacementStringConstants.PartialAlignment,
            TableNameConstants.Percentiles.Set.PartialAlignments)]
        [TestCase(ReplacementStringConstants.FullAlignment,
            TableNameConstants.Percentiles.Set.FullAlignments)]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}