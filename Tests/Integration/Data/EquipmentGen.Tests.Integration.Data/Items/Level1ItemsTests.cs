using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items
{
    [TestFixture, PercentileTable("Level1Items")]
    public class Level1ItemsTests : PercentileTests
    {
        [Test]
        public void Level1ItemsEmptyPercentile()
        {
            AssertEmpty(1, 71);
        }

        [Test]
        public void Level1ItemsMundanePercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Mundane);
            AssertContent(content, 72, 95);
        }

        [Test]
        public void Level1ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Minor);
            AssertContent(content, 96, 100);
        }
    }
}