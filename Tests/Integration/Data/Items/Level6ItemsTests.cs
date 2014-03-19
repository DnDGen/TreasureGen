using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level6Items")]
    public class Level6ItemsTests : PercentileTests
    {
        [Test]
        public void Level6ItemsEmptyPercentile()
        {
            AssertEmpty(1, 54);
        }

        [Test]
        public void Level6ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Mundane);
            AssertContent(content, 55, 59);
        }

        [Test]
        public void Level6ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Minor);
            AssertContent(content, 60, 99);
        }

        [Test]
        public void Level6ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertContent(content, 100);
        }
    }
}