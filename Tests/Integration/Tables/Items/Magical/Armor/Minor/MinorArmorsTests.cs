using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Minor
{
    [TestFixture]
    public class MinorArmorsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "MinorArmors"; }
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
        [TestCase("SpecificArmors", 0, 88, 89)]
        [TestCase("SpecificShields", 0, 90, 91)]
        [TestCase("SpecialAbility", 1, 92, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}