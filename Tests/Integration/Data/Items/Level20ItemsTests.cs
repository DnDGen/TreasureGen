using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level20Items")]
    public class Level20ItemsTests : PercentileTests
    {
        [Test]
        public void Level20ItemsEmptyPercentile()
        {
            AssertEmpty(1, 25);
        }

        [Test]
        public void Level20ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Medium);
            AssertContent(content, 26, 65);
        }

        [Test]
        public void Level20ItemsMajorPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Major);
            AssertContent(content, 66, 100);
        }
    }
}