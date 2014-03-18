using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items
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