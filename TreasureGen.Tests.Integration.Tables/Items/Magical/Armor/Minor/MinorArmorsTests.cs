using System;
using TreasureGen.Items;
using TreasureGen.Domain.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Minor
{
    [TestFixture]
    public class MinorArmorsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.Armor); }
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

        [TestCase(AttributeConstants.Shield, 1, 1, 60)]
        [TestCase(ItemTypeConstants.Armor, 1, 61, 80)]
        [TestCase(AttributeConstants.Shield, 2, 81, 85)]
        [TestCase(ItemTypeConstants.Armor, 2, 86, 87)]
        [TestCase(ItemTypeConstants.Armor, 0, 88, 89)]
        [TestCase(AttributeConstants.Shield, 0, 90, 91)]
        [TestCase("SpecialAbility", 1, 92, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}