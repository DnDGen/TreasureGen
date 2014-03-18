using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
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
            var content = String.Format("{0},1", PowerConstants.Mundane);
            AssertContent(content, 50, 85);
        }

        [Test]
        public void Level2ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Minor);
            AssertContent(content, 86, 100);
        }
    }
}