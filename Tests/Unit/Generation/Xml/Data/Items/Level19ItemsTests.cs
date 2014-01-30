using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture, PercentileTable("Level19Items")]
    public class Level19ItemsTests : PercentileTests
    {
        [Test]
        public void Level19ItemsEmptyPercentile()
        {
            AssertEmpty(1, 4);
        }

        [Test]
        public void Level19ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Power.Medium);
            AssertContent(content, 5, 70);
        }

        [Test]
        public void Level19ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Major);
            AssertContent(content, 71, 100);
        }
    }
}