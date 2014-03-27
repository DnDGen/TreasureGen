using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level9Items")]
    public class Level9ItemsTests : PercentileTests
    {
        [Test]
        public void Level9ItemsEmptyPercentile()
        {
            AssertEmpty(1, 43);
        }

        [Test]
        public void Level9ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Minor);
            AssertPercentile(content, 44, 91);
        }

        [Test]
        public void Level9ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 92, 100);
        }
    }
}