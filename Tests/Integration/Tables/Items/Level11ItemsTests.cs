using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level11ItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level11Items"; }
        }

        [TestCase(EmptyContent, 1, 31)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d4", 32, 84)]
        [TestCase(PowerConstants.Medium, "1", 85, 98)]
        [TestCase(PowerConstants.Major, "1", 99, 100)]
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