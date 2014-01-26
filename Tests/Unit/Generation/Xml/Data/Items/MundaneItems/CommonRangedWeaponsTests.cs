using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class CommonRangedWeaponsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "CommonRangedWeapons";
        }

        [Test]
        public void AmmunitionPercentile()
        {
            AssertContent(ItemsConstants.Gear.Types.Ammunition, 1, 10);
        }

        [Test]
        public void ThrowingAxePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.ThrowingAxe, 11, 15);
        }

        [Test]
        public void HeavyCrossbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.HeavyCrossbow, 16, 25);
        }

        [Test]
        public void LightCrossbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.LightCrossbow, 26, 35);
        }

        [Test]
        public void DartPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Dart, 36, 39);
        }

        [Test]
        public void JavelinPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Javelin, 40, 41);
        }

        [Test]
        public void ShortbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Shortbow, 42, 46);
        }

        [Test]
        public void CompositePlus0ShortbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus0Shortbow, 47, 51);
        }

        [Test]
        public void CompositePlus1ShortbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus1Shortbow, 52, 56);
        }

        [Test]
        public void CompositePlus2ShortbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus2Shortbow, 57, 61);
        }

        [Test]
        public void SlingPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Sling, 62, 65);
        }

        [Test]
        public void LongbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Longbow, 66, 75);
        }

        [Test]
        public void CompositePlus0LongbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus0Longbow, 76, 80);
        }

        [Test]
        public void CompositePlus1LongbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus1Longbow, 81, 85);
        }

        [Test]
        public void CompositePlus2LongbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus2Longbow, 86, 90);
        }

        [Test]
        public void CompositePlus3LongbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus3Longbow, 91, 95);
        }

        [Test]
        public void CompositePlus4LongbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus4Longbow, 96, 100);
        }
    }
}