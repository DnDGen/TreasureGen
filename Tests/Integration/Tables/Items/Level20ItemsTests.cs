using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level20ItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level20Items"; }
        }

        [TestCase(EmptyContent, 1, 25)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Medium, "1d4", 26, 65)]
        [TestCase(PowerConstants.Major, "1d3", 66, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}