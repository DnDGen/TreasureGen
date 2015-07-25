using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Weapons.Minor
{
    [TestFixture]
    public class MinorSpecificWeaponsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.Weapon); }
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
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}