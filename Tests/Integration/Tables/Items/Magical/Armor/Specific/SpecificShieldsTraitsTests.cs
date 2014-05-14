using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificShieldsTraitsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "SpecificShieldsTraits"; }
        }

        [TestCase(ArmorConstants.AbsorbingShield)]
        [TestCase(ArmorConstants.CastersShield)]
        [TestCase(ArmorConstants.Buckler, TraitConstants.Darkwood)]
        [TestCase(ArmorConstants.HeavySteelShield, TraitConstants.Mithral)]
        [TestCase(ArmorConstants.HeavyWoodenShield, TraitConstants.Darkwood)]
        [TestCase(ArmorConstants.LionsShield)]
        [TestCase(ArmorConstants.SpinedShield)]
        [TestCase(ArmorConstants.WingedShield)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}