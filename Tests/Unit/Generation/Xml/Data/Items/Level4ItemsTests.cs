using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture, PercentileTable("Level4Items")]
    public class Level4ItemsTests : PercentileTests
    {
        [Test]
        public void Level4ItemsEmptyPercentile()
        {
            AssertEmpty(1, 42);
        }

        [Test]
        public void Level4ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Power.Mundane);
            AssertContent(content, 43, 62);
        }

        [Test]
        public void Level4ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Minor);
            AssertContent(content, 63, 100);
        }
    }
}