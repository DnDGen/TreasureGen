using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls
{
    [TestFixture, PercentileTable("MinorSpellLevels")]
    public class MinorSpellLevelsTests : PercentileTests
    {
        [Test]
        public void Level0Percentile()
        {
            AssertPercentile("0", 1, 5);
        }

        [Test]
        public void Level1Percentile()
        {
            AssertPercentile("1", 6, 50);
        }

        [Test]
        public void Level2Percentile()
        {
            AssertPercentile("2", 51, 95);
        }

        [Test]
        public void Level3Percentile()
        {
            AssertPercentile("3", 96, 100);
        }
    }
}