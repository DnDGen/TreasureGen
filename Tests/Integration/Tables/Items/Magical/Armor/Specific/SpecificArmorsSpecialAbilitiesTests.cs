using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificArmorsSpecialAbilitiesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "SpecificArmorsSpecialAbilities"; }
        }

        [TestCase(ArmorConstants.BandedMailOfLuck)]
        [TestCase(ArmorConstants.BreastplateOfCommand)]
        [TestCase(ArmorConstants.CelestialArmor)]
        [TestCase(ArmorConstants.DemonArmor)]
        [TestCase(ArmorConstants.DwarvenPlate)]
        [TestCase(ArmorConstants.ElvenChain)]
        [TestCase(ArmorConstants.FullPlateOfSpeed)]
        [TestCase(ArmorConstants.PlateArmorOfTheDeep)]
        [TestCase(ArmorConstants.RhinoHide)]
        [TestCase(ArmorConstants.ChainShirt)]
        [TestCase(ArmorConstants.FullPlate)]
        [TestCase(ArmorConstants.Breastplate)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}