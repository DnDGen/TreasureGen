using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items
{
    [TestFixture, PercentileTable("Level17Items")]
    public class Level17ItemsTests : PercentileTests
    {
        [Test]
        public void Level17ItemsEmptyPercentile()
        {
            AssertEmpty(1, 33);
        }

        [Test]
        public void Level17ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Medium);
            AssertContent(content, 34, 83);
        }

        [Test]
        public void Level17ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertContent(content, 84, 100);
        }
    }
}