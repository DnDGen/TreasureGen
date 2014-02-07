using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture, PercentileTable("Level8Items")]
    public class Level8ItemsTests : PercentileTests
    {
        [Test]
        public void Level8ItemsEmptyPercentile()
        {
            AssertEmpty(1, 48);
        }

        [Test]
        public void Level8ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Minor);
            AssertContent(content, 49, 96);
        }

        [Test]
        public void Level8ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertContent(content, 97, 100);
        }
    }
}