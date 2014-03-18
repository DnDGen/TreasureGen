using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls
{
    [TestFixture, PercentileTable("MajorSpellLevel")]
    public class MajorSpellLevelTests : PercentileTests
    {
        [Test]
        public void Level4Percentile()
        {
            AssertContent("4", 1, 5);
        }

        [Test]
        public void Level5Percentile()
        {
            AssertContent("5", 6, 50);
        }

        [Test]
        public void Level6Percentile()
        {
            AssertContent("6", 51, 70);
        }

        [Test]
        public void Level7Percentile()
        {
            AssertContent("7", 71, 85);
        }

        [Test]
        public void Level8Percentile()
        {
            AssertContent("8", 86, 95);
        }

        [Test]
        public void Level9Percentile()
        {
            AssertContent("9", 96, 100);
        }
    }
}