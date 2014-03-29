using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level1ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level1Items";
        }

        [Test]
        public void Level1ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 71);
        }

        [Test]
        public void Level1ItemsMundanePercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Mundane);
            AssertPercentile(content, 72, 95);
        }

        [Test]
        public void Level1ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Minor);
            AssertPercentile(content, 96, 100);
        }
    }
}