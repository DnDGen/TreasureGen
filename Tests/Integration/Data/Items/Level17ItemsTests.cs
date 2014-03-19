using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
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