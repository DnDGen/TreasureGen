using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level7Items")]
    public class Level7ItemsTests : PercentileTests
    {
        [Test]
        public void Level7ItemsEmptyPercentile()
        {
            AssertEmpty(1, 51);
        }

        [Test]
        public void Level7ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Minor);
            AssertPercentile(content, 52, 97);
        }

        [Test]
        public void Level7ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 98, 100);
        }
    }
}