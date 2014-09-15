using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Major
{
    [TestFixture]
    public class MajorSpecificArmorsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "MajorSpecificArmors"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(ArmorConstants.Breastplate, 0, 1, 10)]
        [TestCase(ArmorConstants.DwarvenPlate, 0, 11, 20)]
        [TestCase(ArmorConstants.BandedMailOfLuck, 3, 21, 32)]
        [TestCase(ArmorConstants.CelestialArmor, 3, 33, 50)]
        [TestCase(ArmorConstants.PlateArmorOfTheDeep, 1, 51, 60)]
        [TestCase(ArmorConstants.BreastplateOfCommand, 2, 61, 75)]
        [TestCase(ArmorConstants.FullPlateOfSpeed, 1, 76, 90)]
        [TestCase(ArmorConstants.DemonArmor, 4, 91, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}