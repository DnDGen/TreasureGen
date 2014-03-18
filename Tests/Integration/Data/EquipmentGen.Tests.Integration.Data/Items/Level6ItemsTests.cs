using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items
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