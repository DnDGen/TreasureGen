using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level11ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level11Items";
        }

        [Test]
        public void Level11ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 31);
        }

        [Test]
        public void Level11ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Minor);
            AssertPercentile(content, 32, 84);
        }

        [Test]
        public void Level11ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 85, 98);
        }

        [Test]
        public void Level11ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 99, 100);
        }
    }
}