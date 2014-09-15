using System;
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
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllArmors()
        {
            Assert.Fail();
        }
    }
}