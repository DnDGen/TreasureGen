using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture, PercentileTable("Level14Items")]
    public class Level14ItemsTests : PercentileTests
    {
        [Test]
        public void Level14ItemsEmptyPercentile()
        {
            AssertEmpty(1, 19);
        }

        [Test]
        public void Level14ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d6", ItemsConstants.Power.Minor);
            AssertContent(content, 20, 58);
        }

        [Test]
        public void Level14ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Medium);
            AssertContent(content, 59, 92);
        }

        [Test]
        public void Level14ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Major);
            AssertContent(content, 93, 100);
        }
    }
}