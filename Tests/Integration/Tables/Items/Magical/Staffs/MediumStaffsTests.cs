using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Staves
{
    [TestFixture]
    public class MediumStaffsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Staff); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(StaffConstants.Charming, 1, 15)]
        [TestCase(StaffConstants.Fire, 16, 30)]
        [TestCase(StaffConstants.SwarmingInsects, 31, 40)]
        [TestCase(StaffConstants.Healing, 41, 60)]
        [TestCase(StaffConstants.SizeAlteration, 61, 75)]
        [TestCase(StaffConstants.Illumination, 76, 90)]
        [TestCase(StaffConstants.Frost, 91, 95)]
        [TestCase(StaffConstants.Defense, 96, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}