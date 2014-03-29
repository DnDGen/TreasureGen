using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls
{
    [TestFixture]
    public class MajorSpellLevelsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MajorSpellLevels";
        }

        [Test]
        public void Level4Percentile()
        {
            AssertPercentile("4", 1, 5);
        }

        [Test]
        public void Level5Percentile()
        {
            AssertPercentile("5", 6, 50);
        }

        [Test]
        public void Level6Percentile()
        {
            AssertPercentile("6", 51, 70);
        }

        [Test]
        public void Level7Percentile()
        {
            AssertPercentile("7", 71, 85);
        }

        [Test]
        public void Level8Percentile()
        {
            AssertPercentile("8", 86, 95);
        }

        [Test]
        public void Level9Percentile()
        {
            AssertPercentile("9", 96, 100);
        }
    }
}