using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level9ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level9Items";
        }

        [Test]
        public void Level9ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 43);
        }

        [Test]
        public void Level9ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Minor);
            AssertPercentile(content, 44, 91);
        }

        [Test]
        public void Level9ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 92, 100);
        }
    }
}