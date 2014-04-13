using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level20ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level20Items"; }
        }

        [TestCase(EmptyContent, 1, 25)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Medium, "1d4", 26, 65)]
        [TestCase(PowerConstants.Major, "1d3", 66, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}