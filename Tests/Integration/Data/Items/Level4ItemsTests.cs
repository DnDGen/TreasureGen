using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level4ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level4Items";
        }

        [Test]
        public void Level4ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 42);
        }

        [Test]
        public void Level4ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Mundane);
            AssertPercentile(content, 43, 62);
        }

        [Test]
        public void Level4ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Minor);
            AssertPercentile(content, 63, 100);
        }
    }
}