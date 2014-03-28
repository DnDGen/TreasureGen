using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls
{
    [TestFixture, PercentileTable("MediumSpellLevels")]
    public class MediumSpellLevelsTests : PercentileTests
    {
        [Test]
        public void Level2Percentile()
        {
            AssertPercentile("2", 1, 5);
        }

        [Test]
        public void Level3Percentile()
        {
            AssertPercentile("3", 6, 65);
        }

        [Test]
        public void Level4Percentile()
        {
            AssertPercentile("4", 66, 95);
        }

        [Test]
        public void Level5Percentile()
        {
            AssertPercentile("5", 96, 100);
        }
    }
}