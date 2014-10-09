using System;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables
{
    [TestFixture]
    public class ReplacementStringsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Attributes.Set.ReplacementStrings; }
        }

        [TestCase(TableNameConstants.Attributes.Set.ReplacementStrings,
            "DESIGNATEDFOE",
            "GENDER",
            "HEIGHT",
            "KNOWLEDGECATEGORIES",
            "ENERGY",
            "PROTECTIONALIGNMENT")]
        [TestCase("DESIGNATEDFOE",
            TableNameConstants.Percentiles.Set.DesignatedFoes)]
        [TestCase("GENDER",
            TableNameConstants.Percentiles.Set.Gender)]
        [TestCase("HEIGHT",
            TableNameConstants.Percentiles.Set.CurseHeightChanges)]
        [TestCase("KNOWLEDGECATEGORIES",
            TableNameConstants.Percentiles.Set.KnowledgeCategories)]
        [TestCase("ENERGY",
            TableNameConstants.Percentiles.Set.Elements)]
        [TestCase("PROTECTIONALIGNMENT",
            TableNameConstants.Percentiles.Set.ProtectionAlignments)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}