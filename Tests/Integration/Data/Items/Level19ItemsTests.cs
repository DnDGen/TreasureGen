using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level19Items")]
    public class Level19ItemsTests : PercentileTests
    {
        [Test]
        public void Level19ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 4);
        }

        [Test]
        public void Level19ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Medium);
            AssertPercentile(content, 5, 70);
        }

        [Test]
        public void Level19ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 71, 100);
        }
    }
}