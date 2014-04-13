using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level8ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level8Items"; }
        }

        [TestCase(EmptyContent, 1, 48)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d4", 49, 96)]
        [TestCase(PowerConstants.Medium, "1", 97, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}