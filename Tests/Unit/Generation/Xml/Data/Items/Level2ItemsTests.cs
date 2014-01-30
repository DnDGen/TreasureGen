using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture, PercentileTable("Level2Items")]
    public class Level2ItemsTests : PercentileTests
    {
        [Test]
        public void Level2ItemsEmptyPercentile()
        {
            AssertEmpty(1, 49);
        }

        [Test]
        public void Level2ItemsMundanePercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Mundane);
            AssertContent(content, 50, 85);
        }

        [Test]
        public void Level2ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Minor);
            AssertContent(content, 86, 100);
        }
    }
}