using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture, PercentileTable("Level11Items")]
    public class Level11ItemsTests : PercentileTests
    {
        [Test]
        public void Level11ItemsEmptyPercentile()
        {
            AssertEmpty(1, 31);
        }

        [Test]
        public void Level11ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Power.Minor);
            AssertContent(content, 32, 84);
        }

        [Test]
        public void Level11ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Medium);
            AssertContent(content, 85, 98);
        }

        [Test]
        public void Level11ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Major);
            AssertContent(content, 99, 100);
        }
    }
}