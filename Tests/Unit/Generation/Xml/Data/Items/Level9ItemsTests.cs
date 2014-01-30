using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
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
            var content = String.Format("{0},1d4", ItemsConstants.Power.Minor);
            AssertContent(content, 44, 91);
        }

        [Test]
        public void Level9ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Medium);
            AssertContent(content, 92, 100);
        }
    }
}