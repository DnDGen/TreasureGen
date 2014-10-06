using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Staves
{
    [TestFixture]
    public class MajorStaffsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Staff); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(StaffConstants.Charming, 1, 3)]
        [TestCase(StaffConstants.Fire, 4, 9)]
        [TestCase(StaffConstants.SwarmingInsects, 10, 11)]
        [TestCase(StaffConstants.Healing, 12, 17)]
        [TestCase(StaffConstants.SizeAlteration, 18, 19)]
        [TestCase(StaffConstants.Illumination, 20, 24)]
        [TestCase(StaffConstants.Frost, 25, 31)]
        [TestCase(StaffConstants.Defense, 32, 38)]
        [TestCase(StaffConstants.Abjuration, 39, 43)]
        [TestCase(StaffConstants.Conjuration, 44, 48)]
        [TestCase(StaffConstants.Enchantment, 49, 53)]
        [TestCase(StaffConstants.Evocation, 54, 58)]
        [TestCase(StaffConstants.Illusion, 59, 63)]
        [TestCase(StaffConstants.Necromancy, 64, 68)]
        [TestCase(StaffConstants.Transmutation, 69, 73)]
        [TestCase(StaffConstants.Divination, 74, 77)]
        [TestCase(StaffConstants.EarthAndStone, 78, 82)]
        [TestCase(StaffConstants.Woodlands, 83, 87)]
        [TestCase(StaffConstants.Life, 88, 92)]
        [TestCase(StaffConstants.Passage, 93, 97)]
        [TestCase(StaffConstants.Power, 98, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}