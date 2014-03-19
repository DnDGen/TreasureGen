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
            AssertContent("2", 1, 5);
        }

        [Test]
        public void Level3Percentile()
        {
            AssertContent("3", 6, 65);
        }

        [Test]
        public void Level4Percentile()
        {
            AssertContent("4", 66, 95);
        }

        [Test]
        public void Level5Percentile()
        {
            AssertContent("5", 96, 100);
        }
    }
}