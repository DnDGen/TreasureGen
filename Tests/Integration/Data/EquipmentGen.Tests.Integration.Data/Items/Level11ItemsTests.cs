using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items
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
            var content = String.Format("{0},1d4", PowerConstants.Minor);
            AssertContent(content, 32, 84);
        }

        [Test]
        public void Level11ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertContent(content, 85, 98);
        }

        [Test]
        public void Level11ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertContent(content, 99, 100);
        }
    }
}