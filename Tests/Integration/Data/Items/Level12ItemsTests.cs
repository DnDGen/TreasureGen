using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level12Items")]
    public class Level12ItemsTests : PercentileTests
    {
        [Test]
        public void Level12ItemsEmptyPercentile()
        {
            AssertEmpty(1, 27);
        }

        [Test]
        public void Level12ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d6", PowerConstants.Minor);
            AssertContent(content, 28, 82);
        }

        [Test]
        public void Level12ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertContent(content, 83, 97);
        }

        [Test]
        public void Level12ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertContent(content, 98, 100);
        }
    }
}