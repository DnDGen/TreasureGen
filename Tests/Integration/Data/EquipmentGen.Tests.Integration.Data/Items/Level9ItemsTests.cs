using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items
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
            AssertContent(content, 44, 91);
        }

        [Test]
        public void Level9ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertContent(content, 92, 100);
        }
    }
}