using System;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Alchemical
{
    [TestFixture]
    public class AlchemicalItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Percentiles.Set.AlchemicalItems; }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Alchemist's fire", "1d4", 1, 12)]
        [TestCase("Acid", "2d4", 13, 24)]
        [TestCase("Smokestick", "1d4", 25, 36)]
        [TestCase("Holy water", "1d4", 37, 48)]
        [TestCase("Antitoxin", "1d4", 49, 62)]
        [TestCase("Everburning torch", "1", 63, 74)]
        [TestCase("Tanglefoot bag", "1d4", 75, 88)]
        [TestCase("Thunderstone", "1d4", 89, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}