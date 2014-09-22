using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level14ItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 14); }
        }

        [TestCase(EmptyContent, 1, 19)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d6", 20, 58)]
        [TestCase(PowerConstants.Medium, "1", 59, 92)]
        [TestCase(PowerConstants.Major, "1", 93, 100)]
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