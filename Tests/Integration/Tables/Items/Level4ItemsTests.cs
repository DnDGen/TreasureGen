using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level4ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level4Items"; }
        }

        [TestCase(EmptyContent, 1, 42)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Mundane, "1d4", 43, 62)]
        [TestCase(PowerConstants.Minor, "1", 63, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}