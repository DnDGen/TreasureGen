using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level19ItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level19Items"; }
        }

        [TestCase(EmptyContent, 1, 4)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Medium, "1d4", 5, 70)]
        [TestCase(PowerConstants.Major, "1", 71, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}