using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class CommonRangedWeaponsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "CommonRanged"); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(AttributeConstants.Ammunition, 1, 10)]
        [TestCase(WeaponConstants.ThrowingAxe, 11, 15)]
        [TestCase(WeaponConstants.HeavyCrossbow, 16, 25)]
        [TestCase(WeaponConstants.LightCrossbow, 26, 35)]
        [TestCase(WeaponConstants.Dart, 36, 39)]
        [TestCase(WeaponConstants.Javelin, 40, 41)]
        [TestCase(WeaponConstants.Shortbow, 42, 46)]
        [TestCase(WeaponConstants.CompositePlus0Shortbow, 47, 51)]
        [TestCase(WeaponConstants.CompositePlus1Shortbow, 52, 56)]
        [TestCase(WeaponConstants.CompositePlus2Shortbow, 57, 61)]
        [TestCase(WeaponConstants.Sling, 62, 65)]
        [TestCase(WeaponConstants.Longbow, 66, 75)]
        [TestCase(WeaponConstants.CompositePlus0Longbow, 76, 80)]
        [TestCase(WeaponConstants.CompositePlus1Longbow, 81, 85)]
        [TestCase(WeaponConstants.CompositePlus2Longbow, 86, 90)]
        [TestCase(WeaponConstants.CompositePlus3Longbow, 91, 95)]
        [TestCase(WeaponConstants.CompositePlus4Longbow, 96, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}