using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls
{
    [TestFixture]
    public class MediumSpellLevelsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MediumSpellLevels";
        }

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