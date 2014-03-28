using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level3Items")]
    public class Level3ItemsTests : PercentileTests
    {
        [Test]
        public void Level3ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 49);
        }

        [Test]
        public void Level3ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Mundane);
            AssertPercentile(content, 50, 79);
        }

        [Test]
        public void Level3ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Minor);
            AssertPercentile(content, 80, 100);
        }
    }
}