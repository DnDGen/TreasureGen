using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level8ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level8Items";
        }

        [Test]
        public void Level8ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 48);
        }

        [Test]
        public void Level8ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Minor);
            AssertPercentile(content, 49, 96);
        }

        [Test]
        public void Level8ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 97, 100);
        }
    }
}