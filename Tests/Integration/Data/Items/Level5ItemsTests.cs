using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level5ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level5Items";
        }

        [Test]
        public void Level5ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 57);
        }

        [Test]
        public void Level5ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Mundane);
            AssertPercentile(content, 58, 67);
        }

        [Test]
        public void Level5ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d3", PowerConstants.Minor);
            AssertPercentile(content, 68, 100);
        }
    }
}