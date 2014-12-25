using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumSpecificArmorsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Armor); }
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

        [TestCase(ArmorConstants.ChainShirt, 0, 1, 25)]
        [TestCase(ArmorConstants.FullPlate, 0, 26, 45)]
        [TestCase(ArmorConstants.ElvenChain, 0, 46, 57)]
        [TestCase(ArmorConstants.RhinoHide, 2, 58, 67)]
        [TestCase(ArmorConstants.Breastplate, 0, 68, 82)]
        [TestCase(ArmorConstants.DwarvenPlate, 0, 83, 97)]
        [TestCase(ArmorConstants.BandedMailOfLuck, 3, 98, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}