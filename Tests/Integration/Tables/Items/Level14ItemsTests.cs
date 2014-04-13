using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level14ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level14Items"; }
        }

        [TestCase(EmptyContent, 1, 19)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d6", 20, 58)]
        [TestCase(PowerConstants.Medium, "1", 59, 92)]
        [TestCase(PowerConstants.Major, "1", 93, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}