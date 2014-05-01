using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificShieldsSpecialAbilitiesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "SpecificShieldsSpecialAbilities"; }
        }

        [TestCase(ArmorConstants.AbsorbingShield)]
        [TestCase(ArmorConstants.CastersShield)]
        [TestCase(ArmorConstants.Buckler)]
        [TestCase(ArmorConstants.HeavySteelShield)]
        [TestCase(ArmorConstants.HeavyWoodenShield)]
        [TestCase(ArmorConstants.LionsShield)]
        [TestCase(ArmorConstants.SpinedShield)]
        [TestCase(ArmorConstants.WingedShield)]
        public void Attributes(String name)
        {
            AssertEmpty(name);
        }
    }
}