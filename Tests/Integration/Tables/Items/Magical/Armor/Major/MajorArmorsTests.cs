using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Major
{
    [TestFixture]
    public class MajorArmorsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Armor); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(AttributeConstants.Shield, 3, 1, 8)]
        [TestCase(ItemTypeConstants.Armor, 3, 9, 16)]
        [TestCase(AttributeConstants.Shield, 4, 17, 27)]
        [TestCase(ItemTypeConstants.Armor, 4, 28, 38)]
        [TestCase(AttributeConstants.Shield, 5, 39, 49)]
        [TestCase(ItemTypeConstants.Armor, 5, 50, 57)]
        [TestCase(ItemTypeConstants.Armor, 0, 58, 60)]
        [TestCase(AttributeConstants.Shield, 0, 61, 63)]
        [TestCase("SpecialAbility", 1, 64, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
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