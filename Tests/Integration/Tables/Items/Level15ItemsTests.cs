using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level15ItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level15Items"; }
        }

        [TestCase(EmptyContent, 1, 11)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d10", 12, 46)]
        [TestCase(PowerConstants.Medium, "1", 47, 90)]
        [TestCase(PowerConstants.Major, "1", 91, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}