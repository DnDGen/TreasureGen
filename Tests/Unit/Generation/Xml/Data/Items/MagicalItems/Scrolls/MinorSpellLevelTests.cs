using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Scrolls
{
    [TestFixture, PercentileTable("MinorSpellLevel")]
    public class MinorSpellLevelTests : PercentileTests
    {
        [Test]
        public void Level0Percentile()
        {
            AssertContent("0", 1, 5);
        }

        [Test]
        public void Level1Percentile()
        {
            AssertContent("1", 6, 50);
        }

        [Test]
        public void Level2Percentile()
        {
            AssertContent("2", 51, 95);
        }

        [Test]
        public void Level3Percentile()
        {
            AssertContent("3", 96, 100);
        }
    }
}