using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level6ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level6Items"; }
        }

        [TestCase(EmptyContent, 1, 54)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Mundane, "1d4", 55, 59)]
        [TestCase(PowerConstants.Minor, "1d3", 60, 99)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Medium, "1", 100)]
        public void Percentile(String power, String amount, Int32 roll)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, roll);
        }
    }
}