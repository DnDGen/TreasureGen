using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level15Items")]
    public class Level15ItemsTests : PercentileTests
    {
        [Test]
        public void Level15ItemsEmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level15ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d10", PowerConstants.Minor);
            AssertPercentile(content, 12, 46);
        }

        [Test]
        public void Level15ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 47, 90);
        }

        [Test]
        public void Level15ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 91, 100);
        }
    }
}