using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level17ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level17Items"; }
        }

        [TestCase(EmptyContent, 1, 33)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Medium, "1d3", 34, 83)]
        [TestCase(PowerConstants.Major, "1", 84, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}