using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture, PercentileTable("Level16Items")]
    public class Level16ItemsTests : PercentileTests
    {
        [Test]
        public void Level16ItemsEmptyPercentile()
        {
            AssertEmpty(1, 40);
        }

        [Test]
        public void Level16ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d10", ItemsConstants.Power.Minor);
            AssertContent(content, 41, 46);
        }

        [Test]
        public void Level16ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d3", ItemsConstants.Power.Medium);
            AssertContent(content, 47, 90);
        }

        [Test]
        public void Level16ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Major);
            AssertContent(content, 91, 100);
        }
    }
}