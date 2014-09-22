using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level10ItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 10); }
        }

        [TestCase(EmptyContent, 1, 40)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d4", 41, 88)]
        [TestCase(PowerConstants.Medium, "1", 89, 99)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }

        [TestCase(PowerConstants.Major, "1", 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 roll)
        {
            base.TypeAndAmountPercentile(type, amount, roll);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}