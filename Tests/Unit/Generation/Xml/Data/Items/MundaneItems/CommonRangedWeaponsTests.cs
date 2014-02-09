using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("CommonRangedWeapons")]
    public class CommonRangedWeaponsTests : PercentileTests
    {
        [Test]
        public void AmmunitionPercentile()
        {
            AssertContent(TypeConstants.Ammunition, 1, 10);
        }

        [Test]
        public void ThrowingAxePercentile()
        {
            AssertContent(WeaponConstants.ThrowingAxe, 11, 15);
        }

        [Test]
        public void HeavyCrossbowPercentile()
        {
            AssertContent(WeaponConstants.HeavyCrossbow, 16, 25);
        }

        [Test]
        public void LightCrossbowPercentile()
        {
            AssertContent(WeaponConstants.LightCrossbow, 26, 35);
        }

        [Test]
        public void DartPercentile()
        {
            AssertContent(WeaponConstants.Dart, 36, 39);
        }

        [Test]
        public void JavelinPercentile()
        {
            AssertContent(WeaponConstants.Javelin, 40, 41);
        }

        [Test]
        public void ShortbowPercentile()
        {
            AssertContent(WeaponConstants.Shortbow, 42, 46);
        }

        [Test]
        public void CompositePlus0ShortbowPercentile()
        {
            AssertContent(WeaponConstants.CompositePlus0Shortbow, 47, 51);
        }

        [Test]
        public void CompositePlus1ShortbowPercentile()
        {
            AssertContent(WeaponConstants.CompositePlus1Shortbow, 52, 56);
        }

        [Test]
        public void CompositePlus2ShortbowPercentile()
        {
            AssertContent(WeaponConstants.CompositePlus2Shortbow, 57, 61);
        }

        [Test]
        public void SlingPercentile()
        {
            AssertContent(WeaponConstants.Sling, 62, 65);
        }

        [Test]
        public void LongbowPercentile()
        {
            AssertContent(WeaponConstants.Longbow, 66, 75);
        }

        [Test]
        public void CompositePlus0LongbowPercentile()
        {
            AssertContent(WeaponConstants.CompositePlus0Longbow, 76, 80);
        }

        [Test]
        public void CompositePlus1LongbowPercentile()
        {
            AssertContent(WeaponConstants.CompositePlus1Longbow, 81, 85);
        }

        [Test]
        public void CompositePlus2LongbowPercentile()
        {
            AssertContent(WeaponConstants.CompositePlus2Longbow, 86, 90);
        }

        [Test]
        public void CompositePlus3LongbowPercentile()
        {
            AssertContent(WeaponConstants.CompositePlus3Longbow, 91, 95);
        }

        [Test]
        public void CompositePlus4LongbowPercentile()
        {
            AssertContent(WeaponConstants.CompositePlus4Longbow, 96, 100);
        }
    }
}