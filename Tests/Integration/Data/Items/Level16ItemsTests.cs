using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level16ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level16Items";
        }

        [Test]
        public void Level16ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 40);
        }

        [Test]
        public void Level16ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d10", PowerConstants.Minor);
            AssertPercentile(content, 41, 46);
        }

        [Test]
        public void Level16ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Medium);
            AssertPercentile(content, 47, 90);
        }

        [Test]
        public void Level16ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 91, 100);
        }
    }
}