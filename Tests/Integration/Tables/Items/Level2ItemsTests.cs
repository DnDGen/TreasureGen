using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level2ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level2Items"; }
        }

        [TestCase(EmptyContent, 1, 49)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Mundane, "1", 50, 85)]
        [TestCase(PowerConstants.Minor, "1", 86, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}