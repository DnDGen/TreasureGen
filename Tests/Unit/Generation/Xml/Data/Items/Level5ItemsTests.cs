using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture, PercentileTable("Level5Items")]
    public class Level5ItemsTests : PercentileTests
    {
        [Test]
        public void Level5ItemsEmptyPercentile()
        {
            AssertEmpty(1, 57);
        }

        [Test]
        public void Level5ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Mundane);
            AssertContent(content, 58, 67);
        }

        [Test]
        public void Level5ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Minor);
            AssertContent(content, 68, 100);
        }
    }
}