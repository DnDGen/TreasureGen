using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level20Items")]
    public class Level20ItemsTests : PercentileTests
    {
        [Test]
        public void Level20ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 25);
        }

        [Test]
        public void Level20ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Medium);
            AssertPercentile(content, 26, 65);
        }

        [Test]
        public void Level20ItemsMajorPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Major);
            AssertPercentile(content, 66, 100);
        }
    }
}