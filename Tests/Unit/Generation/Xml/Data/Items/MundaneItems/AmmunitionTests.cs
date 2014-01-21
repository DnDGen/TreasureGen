using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class AmmunitionTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Ammunition";
        }

        [Test]
        public void ArrowsPercentile()
        {
            AssertContent("Arrows", 1, 50);
        }

        [Test]
        public void CrossbowBoltsPercentile()
        {
            AssertContent("Crossbow bolts", 51, 80);
        }

        [Test]
        public void SlingBulletsPercentile()
        {
            AssertContent("Sling bullets", 81, 100);
        }
    }
}