using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level13ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level13Items"; }
        }

        [TestCase(EmptyContent, 1, 19)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d6", 20, 73)]
        [TestCase(PowerConstants.Medium, "1", 74, 95)]
        [TestCase(PowerConstants.Major, "1", 96, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}