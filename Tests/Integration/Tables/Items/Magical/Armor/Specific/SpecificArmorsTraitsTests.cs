using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificArmorsTraitsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "SpecificArmorsTraits"; }
        }

        [TestCase(ArmorConstants.BandedMailOfLuck)]
        [TestCase(ArmorConstants.BreastplateOfCommand)]
        [TestCase(ArmorConstants.CelestialArmor)]
        [TestCase(ArmorConstants.DemonArmor)]
        [TestCase(ArmorConstants.DwarvenPlate, TraitConstants.Adamantine)]
        [TestCase(ArmorConstants.ElvenChain, TraitConstants.Mithral)]
        [TestCase(ArmorConstants.FullPlateOfSpeed, TraitConstants.Mithral)]
        [TestCase(ArmorConstants.PlateArmorOfTheDeep)]
        [TestCase(ArmorConstants.RhinoHide)]
        [TestCase(ArmorConstants.ChainShirt, TraitConstants.Mithral)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Dragonhide)]
        [TestCase(ArmorConstants.Breastplate, TraitConstants.Adamantine)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}