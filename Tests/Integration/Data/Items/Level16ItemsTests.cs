using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
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
            var content = String.Format("{0},1d10", PowerConstants.Minor);
            AssertPercentile(content, 41, 46);
        }

        [Test]
        public void Level16ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Medium);
            AssertPercentile(content, 47, 90);
        }

        [Test]
        public void Level16ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 91, 100);
        }
    }
}