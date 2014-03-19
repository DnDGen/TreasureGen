using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
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