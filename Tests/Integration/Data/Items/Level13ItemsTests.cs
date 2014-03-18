using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level13Items")]
    public class Level13ItemsTests : PercentileTests
    {
        [Test]
        public void Level13ItemsEmptyPercentile()
        {
            AssertEmpty(1, 19);
        }

        [Test]
        public void Level13ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d6", PowerConstants.Minor);
            AssertContent(content, 20, 73);
        }

        [Test]
        public void Level13ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertContent(content, 74, 95);
        }

        [Test]
        public void Level13ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertContent(content, 96, 100);
        }
    }
}