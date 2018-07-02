using NUnit.Framework;
using TreasureGen.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Weapons.Minor
{
    [TestFixture]
    public class MinorSpecificWeaponsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.Weapon); }
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

        [TestCase(WeaponConstants.SleepArrow, 1, 1, 15)]
        [TestCase(WeaponConstants.ScreamingBolt, 2, 16, 25)]
        [TestCase(WeaponConstants.SilverDagger, 0, 26, 45)]
        [TestCase(WeaponConstants.Longsword, 0, 46, 65)]
        [TestCase(WeaponConstants.JavelinOfLightning, 0, 66, 75)]
        [TestCase(WeaponConstants.SlayingArrow, 1, 76, 80)]
        [TestCase(WeaponConstants.Dagger, 0, 81, 90)]
        [TestCase(WeaponConstants.Battleaxe, 0, 91, 100)]
        public override void TypeAndAmountPercentile(string type, int amount, int lower, int upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}