using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level12ItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level12Items"; }
        }

        [TestCase(EmptyContent, 1, 27)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d6", 28, 82)]
        [TestCase(PowerConstants.Medium, "1", 83, 97)]
        [TestCase(PowerConstants.Major, "1", 98, 100)]
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