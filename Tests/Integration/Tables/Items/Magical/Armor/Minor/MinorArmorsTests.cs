using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Minor
{
    [TestFixture]
    public class MinorArmorsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MinorArmors"; }
        }

        [TestCase(AttributeConstants.Shield, 1, 1, 60)]
        [TestCase(ItemTypeConstants.Armor, 1, 61, 80)]
        [TestCase(AttributeConstants.Shield, 2, 81, 85)]
        [TestCase(ItemTypeConstants.Armor, 2, 86, 87)]
        [TestCase("SpecificArmors", 0, 88, 89)]
        [TestCase("SpecificShields", 0, 90, 91)]
        [TestCase("SpecialAbility", 1, 92, 100)]
        public void Percentile(String type, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", type, bonus);
            AssertPercentile(content, lower, upper);
        }
    }
}