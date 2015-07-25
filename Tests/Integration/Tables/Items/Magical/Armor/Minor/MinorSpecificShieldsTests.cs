using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Minor
{
    [TestFixture]
    public class MinorSpecificShieldsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, PowerConstants.Minor, AttributeConstants.Shield); }
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

        [TestCase(ArmorConstants.Buckler, 0, 1, 30)]
        [TestCase(ArmorConstants.HeavyWoodenShield, 0, 31, 80)]
        [TestCase(ArmorConstants.HeavySteelShield, 0, 81, 95)]
        [TestCase(ArmorConstants.CastersShield, 1, 96, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}