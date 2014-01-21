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
            AssertContent("Ammunition", 1, 10);
        }

        [Test]
        public void ThrowingAxePercentile()
        {
            AssertContent("Throwing axe", 11, 15);
        }

        [Test]
        public void HeavyCrossbowPercentile()
        {
            AssertContent("Heavy crossbow", 16, 25);
        }

        [Test]
        public void LightCrossbowPercentile()
        {
            AssertContent("Light crossbow", 26, 35);
        }

        [Test]
        public void DartPercentile()
        {
            AssertContent("Dart", 36, 39);
        }

        [Test]
        public void JavelinPercentile()
        {
            AssertContent("Javelin", 40, 41);
        }

        [Test]
        public void ShortbowPercentile()
        {
            AssertContent("Shortbow", 42, 46);
        }

        [Test]
        public void Composite0ShortbowPercentile()
        {
            AssertContent("Composite (+0) Shortbow", 47, 51);
        }

        [Test]
        public void Composite1ShortbowPercentile()
        {
            AssertContent("Composite (+1) Shortbow", 52, 56);
        }

        [Test]
        public void Composite2ShortbowPercentile()
        {
            AssertContent("Composite (+2) Shortbow", 57, 61);
        }

        [Test]
        public void SlingPercentile()
        {
            AssertContent("Sling", 62, 65);
        }

        [Test]
        public void LongbowPercentile()
        {
            AssertContent("Longbow", 66, 75);
        }

        [Test]
        public void Composite0LongbowPercentile()
        {
            AssertContent("Composite (+0) Longbow", 76, 80);
        }

        [Test]
        public void Composite1LongbowPercentile()
        {
            AssertContent("Composite (+1) Longbow", 81, 85);
        }

        [Test]
        public void Composite2LongbowPercentile()
        {
            AssertContent("Composite (+2) Longbow", 86, 90);
        }

        [Test]
        public void Composite3LongbowPercentile()
        {
            AssertContent("Composite (+3) Longbow", 91, 95);
        }

        [Test]
        public void Composite4LongbowPercentile()
        {
            AssertContent("Composite (+4) Longbow", 96, 100);
        }
    }
}