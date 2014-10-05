using System;
using System.Linq;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class ArmorConstantsTests
    {
        [TestCase(ArmorConstants.PaddedArmor, "Padded armor")]
        [TestCase(ArmorConstants.LeatherArmor, "Leather armor")]
        [TestCase(ArmorConstants.StuddedLeatherArmor, "Studded leather armor")]
        [TestCase(ArmorConstants.ChainShirt, "Chain shirt")]
        [TestCase(ArmorConstants.HideArmor, "Hide armor")]
        [TestCase(ArmorConstants.ScaleMail, "Scale mail")]
        [TestCase(ArmorConstants.Chainmail, "Chainmail")]
        [TestCase(ArmorConstants.Breastplate, "Breastplate")]
        [TestCase(ArmorConstants.SplintMail, "Splint mail")]
        [TestCase(ArmorConstants.BandedMail, "Banded mail")]
        [TestCase(ArmorConstants.HalfPlate, "Half-plate")]
        [TestCase(ArmorConstants.FullPlate, "Full plate")]
        [TestCase(ArmorConstants.Buckler, "Buckler")]
        [TestCase(ArmorConstants.LightWoodenShield, "Light wooden shield")]
        [TestCase(ArmorConstants.LightSteelShield, "Light steel shield")]
        [TestCase(ArmorConstants.HeavyWoodenShield, "Heavy wooden shield")]
        [TestCase(ArmorConstants.HeavySteelShield, "Heavy steel shield")]
        [TestCase(ArmorConstants.TowerShield, "Tower shield")]
        [TestCase(ArmorConstants.ElvenChain, "Elven chain")]
        [TestCase(ArmorConstants.RhinoHide, "Rhino hide")]
        [TestCase(ArmorConstants.DwarvenPlate, "Dwarven plate")]
        [TestCase(ArmorConstants.BandedMailOfLuck, "Banded mail of luck")]
        [TestCase(ArmorConstants.CelestialArmor, "Celestial armor")]
        [TestCase(ArmorConstants.PlateArmorOfTheDeep, "Plate armor of the deep")]
        [TestCase(ArmorConstants.BreastplateOfCommand, "Breastplate of command")]
        [TestCase(ArmorConstants.FullPlateOfSpeed, "Full plate of speed")]
        [TestCase(ArmorConstants.DemonArmor, "Demon armor")]
        [TestCase(ArmorConstants.CastersShield, "Caster's shield")]
        [TestCase(ArmorConstants.SpinedShield, "Spined shield")]
        [TestCase(ArmorConstants.LionsShield, "Lion's shield")]
        [TestCase(ArmorConstants.WingedShield, "Winged shield")]
        [TestCase(ArmorConstants.AbsorbingShield, "Absorbing shield")]
        [TestCase(ArmorConstants.ArmorOfRage, "Armor of rage")]
        [TestCase(ArmorConstants.ArmorOfArrowAttraction, "Armor of arrow attraction")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllArmors()
        {
            var armors = ArmorConstants.GetAllArmors();

            Assert.That(armors, Contains.Item(ArmorConstants.PaddedArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.LeatherArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.ChainShirt));
            Assert.That(armors, Contains.Item(ArmorConstants.HideArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.ScaleMail));
            Assert.That(armors, Contains.Item(ArmorConstants.Chainmail));
            Assert.That(armors, Contains.Item(ArmorConstants.Breastplate));
            Assert.That(armors, Contains.Item(ArmorConstants.SplintMail));
            Assert.That(armors, Contains.Item(ArmorConstants.BandedMail));
            Assert.That(armors, Contains.Item(ArmorConstants.HalfPlate));
            Assert.That(armors, Contains.Item(ArmorConstants.FullPlate));
            Assert.That(armors, Contains.Item(ArmorConstants.Buckler));
            Assert.That(armors, Contains.Item(ArmorConstants.LightWoodenShield));
            Assert.That(armors, Contains.Item(ArmorConstants.LightSteelShield));
            Assert.That(armors, Contains.Item(ArmorConstants.HeavyWoodenShield));
            Assert.That(armors, Contains.Item(ArmorConstants.HeavySteelShield));
            Assert.That(armors, Contains.Item(ArmorConstants.TowerShield));
            Assert.That(armors, Contains.Item(ArmorConstants.ElvenChain));
            Assert.That(armors, Contains.Item(ArmorConstants.RhinoHide));
            Assert.That(armors, Contains.Item(ArmorConstants.DwarvenPlate));
            Assert.That(armors, Contains.Item(ArmorConstants.BandedMailOfLuck));
            Assert.That(armors, Contains.Item(ArmorConstants.CelestialArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.PlateArmorOfTheDeep));
            Assert.That(armors, Contains.Item(ArmorConstants.BreastplateOfCommand));
            Assert.That(armors, Contains.Item(ArmorConstants.FullPlateOfSpeed));
            Assert.That(armors, Contains.Item(ArmorConstants.DemonArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.CastersShield));
            Assert.That(armors, Contains.Item(ArmorConstants.SpinedShield));
            Assert.That(armors, Contains.Item(ArmorConstants.LionsShield));
            Assert.That(armors, Contains.Item(ArmorConstants.WingedShield));
            Assert.That(armors, Contains.Item(ArmorConstants.AbsorbingShield));
            Assert.That(armors, Contains.Item(ArmorConstants.ArmorOfRage));
            Assert.That(armors, Contains.Item(ArmorConstants.ArmorOfArrowAttraction));
            Assert.That(armors.Count(), Is.EqualTo(34));
        }
    }
}