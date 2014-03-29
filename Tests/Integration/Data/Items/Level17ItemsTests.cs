using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level17ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level17Items";
        }

        [Test]
        public void Level17ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 33);
        }

        [Test]
        public void Level17ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Medium);
            AssertPercentile(content, 34, 83);
        }

        [Test]
        public void Level17ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 84, 100);
        }
    }
}