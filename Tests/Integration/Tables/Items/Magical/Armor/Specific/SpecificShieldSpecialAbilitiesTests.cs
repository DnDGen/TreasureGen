using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificShieldSpecialAbilitiesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPESpecialAbilities, AttributeConstants.Shield); }
        }

        [TestCase(ArmorConstants.AbsorbingShield)]
        [TestCase(ArmorConstants.CastersShield)]
        [TestCase(ArmorConstants.Buckler)]
        [TestCase(ArmorConstants.HeavySteelShield)]
        [TestCase(ArmorConstants.HeavyWoodenShield)]
        [TestCase(ArmorConstants.LionsShield)]
        [TestCase(ArmorConstants.SpinedShield)]
        [TestCase(ArmorConstants.WingedShield)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}