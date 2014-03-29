using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level6ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level6Items";
        }

        [Test]
        public void Level6ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 54);
        }

        [Test]
        public void Level6ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Mundane);
            AssertPercentile(content, 55, 59);
        }

        [Test]
        public void Level6ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Minor);
            AssertPercentile(content, 60, 99);
        }

        [Test]
        public void Level6ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 100);
        }
    }
}