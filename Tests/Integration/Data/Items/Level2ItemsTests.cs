using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level2ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level2Items";
        }

        [Test]
        public void Level2ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 49);
        }

        [Test]
        public void Level2ItemsMundanePercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Mundane);
            AssertPercentile(content, 50, 85);
        }

        [Test]
        public void Level2ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Minor);
            AssertPercentile(content, 86, 100);
        }
    }
}