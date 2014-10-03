using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumSpecificShieldsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, PowerConstants.Medium, AttributeConstants.Shield); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(ArmorConstants.Buckler, 0, 1, 20)]
        [TestCase(ArmorConstants.HeavyWoodenShield, 0, 21, 45)]
        [TestCase(ArmorConstants.HeavySteelShield, 0, 46, 70)]
        [TestCase(ArmorConstants.CastersShield, 1, 71, 85)]
        [TestCase(ArmorConstants.SpinedShield, 1, 86, 90)]
        [TestCase(ArmorConstants.LionsShield, 2, 91, 95)]
        [TestCase(ArmorConstants.WingedShield, 3, 96, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}