using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
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
            AssertPercentile(content, 20, 73);
        }

        [Test]
        public void Level13ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 74, 95);
        }

        [Test]
        public void Level13ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 96, 100);
        }
    }
}