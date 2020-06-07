using DnDGen.TreasureGen.Items;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
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
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllArmorsAndShields()
        {
            var armorAndShields = ArmorConstants.GetAllArmorsAndShields(true);

            Assert.That(armorAndShields, Contains.Item(ArmorConstants.PaddedArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.LeatherArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.ChainShirt));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.HideArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.ScaleMail));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.Chainmail));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.Breastplate));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.SplintMail));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.BandedMail));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.HalfPlate));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.FullPlate));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.Buckler));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.LightWoodenShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.LightSteelShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.HeavyWoodenShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.HeavySteelShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.TowerShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.ElvenChain));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.RhinoHide));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.DwarvenPlate));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.BandedMailOfLuck));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.CelestialArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.PlateArmorOfTheDeep));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.BreastplateOfCommand));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.FullPlateOfSpeed));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.DemonArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.CastersShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.SpinedShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.LionsShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.WingedShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.AbsorbingShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.ArmorOfRage));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.ArmorOfArrowAttraction));
            Assert.That(armorAndShields.Count(), Is.EqualTo(34));
        }

        [Test]
        public void MundaneArmorsAndShields()
        {
            var armorAndShields = ArmorConstants.GetAllArmorsAndShields(false);

            Assert.That(armorAndShields, Contains.Item(ArmorConstants.PaddedArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.LeatherArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.ChainShirt));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.HideArmor));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.ScaleMail));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.Chainmail));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.Breastplate));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.SplintMail));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.BandedMail));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.HalfPlate));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.FullPlate));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.Buckler));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.LightWoodenShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.LightSteelShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.HeavyWoodenShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.HeavySteelShield));
            Assert.That(armorAndShields, Contains.Item(ArmorConstants.TowerShield));
            Assert.That(armorAndShields.Count(), Is.EqualTo(18));
        }

        [Test]
        public void AllArmors()
        {
            var armors = ArmorConstants.GetAllArmors(true);

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
            Assert.That(armors, Contains.Item(ArmorConstants.ElvenChain));
            Assert.That(armors, Contains.Item(ArmorConstants.RhinoHide));
            Assert.That(armors, Contains.Item(ArmorConstants.DwarvenPlate));
            Assert.That(armors, Contains.Item(ArmorConstants.BandedMailOfLuck));
            Assert.That(armors, Contains.Item(ArmorConstants.CelestialArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.PlateArmorOfTheDeep));
            Assert.That(armors, Contains.Item(ArmorConstants.BreastplateOfCommand));
            Assert.That(armors, Contains.Item(ArmorConstants.FullPlateOfSpeed));
            Assert.That(armors, Contains.Item(ArmorConstants.DemonArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.ArmorOfRage));
            Assert.That(armors, Contains.Item(ArmorConstants.ArmorOfArrowAttraction));
            Assert.That(armors.Count(), Is.EqualTo(23));
        }

        [Test]
        public void MundaneArmors()
        {
            var armors = ArmorConstants.GetAllArmors(false);

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
            Assert.That(armors.Count(), Is.EqualTo(12));
        }

        [Test]
        public void AllLightArmors()
        {
            var armors = ArmorConstants.GetAllLightArmors(true);

            Assert.That(armors, Contains.Item(ArmorConstants.PaddedArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.LeatherArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.ChainShirt));
            Assert.That(armors, Contains.Item(ArmorConstants.ElvenChain));
            Assert.That(armors, Contains.Item(ArmorConstants.CelestialArmor));
            Assert.That(armors.Count(), Is.EqualTo(6));
        }

        [Test]
        public void MundaneLightArmors()
        {
            var armors = ArmorConstants.GetAllLightArmors(false);

            Assert.That(armors, Contains.Item(ArmorConstants.PaddedArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.LeatherArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.ChainShirt));
            Assert.That(armors.Count(), Is.EqualTo(4));
        }

        [Test]
        public void AllMediumArmors()
        {
            var armors = ArmorConstants.GetAllMediumArmors(true);

            Assert.That(armors, Contains.Item(ArmorConstants.HideArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.ScaleMail));
            Assert.That(armors, Contains.Item(ArmorConstants.Chainmail));
            Assert.That(armors, Contains.Item(ArmorConstants.Breastplate));
            Assert.That(armors, Contains.Item(ArmorConstants.RhinoHide));
            Assert.That(armors, Contains.Item(ArmorConstants.BreastplateOfCommand));
            Assert.That(armors.Count(), Is.EqualTo(6));
        }

        [Test]
        public void MundaneMediumArmors()
        {
            var armors = ArmorConstants.GetAllMediumArmors(false);

            Assert.That(armors, Contains.Item(ArmorConstants.HideArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.ScaleMail));
            Assert.That(armors, Contains.Item(ArmorConstants.Chainmail));
            Assert.That(armors, Contains.Item(ArmorConstants.Breastplate));
            Assert.That(armors.Count(), Is.EqualTo(4));
        }

        [Test]
        public void AllHeavyArmors()
        {
            var armors = ArmorConstants.GetAllHeavyArmors(true);

            Assert.That(armors, Contains.Item(ArmorConstants.SplintMail));
            Assert.That(armors, Contains.Item(ArmorConstants.BandedMail));
            Assert.That(armors, Contains.Item(ArmorConstants.HalfPlate));
            Assert.That(armors, Contains.Item(ArmorConstants.FullPlate));
            Assert.That(armors, Contains.Item(ArmorConstants.DwarvenPlate));
            Assert.That(armors, Contains.Item(ArmorConstants.BandedMailOfLuck));
            Assert.That(armors, Contains.Item(ArmorConstants.PlateArmorOfTheDeep));
            Assert.That(armors, Contains.Item(ArmorConstants.FullPlateOfSpeed));
            Assert.That(armors, Contains.Item(ArmorConstants.DemonArmor));
            Assert.That(armors, Contains.Item(ArmorConstants.ArmorOfRage));
            Assert.That(armors, Contains.Item(ArmorConstants.ArmorOfArrowAttraction));
            Assert.That(armors.Count(), Is.EqualTo(11));
        }

        [Test]
        public void MundaneHeavyArmors()
        {
            var armors = ArmorConstants.GetAllHeavyArmors(false);

            Assert.That(armors, Contains.Item(ArmorConstants.SplintMail));
            Assert.That(armors, Contains.Item(ArmorConstants.BandedMail));
            Assert.That(armors, Contains.Item(ArmorConstants.HalfPlate));
            Assert.That(armors, Contains.Item(ArmorConstants.FullPlate));
            Assert.That(armors.Count(), Is.EqualTo(4));
        }

        [Test]
        public void AllShields()
        {
            var shields = ArmorConstants.GetAllShields(true);

            Assert.That(shields, Contains.Item(ArmorConstants.Buckler));
            Assert.That(shields, Contains.Item(ArmorConstants.LightWoodenShield));
            Assert.That(shields, Contains.Item(ArmorConstants.LightSteelShield));
            Assert.That(shields, Contains.Item(ArmorConstants.HeavyWoodenShield));
            Assert.That(shields, Contains.Item(ArmorConstants.HeavySteelShield));
            Assert.That(shields, Contains.Item(ArmorConstants.TowerShield));
            Assert.That(shields, Contains.Item(ArmorConstants.CastersShield));
            Assert.That(shields, Contains.Item(ArmorConstants.SpinedShield));
            Assert.That(shields, Contains.Item(ArmorConstants.LionsShield));
            Assert.That(shields, Contains.Item(ArmorConstants.WingedShield));
            Assert.That(shields, Contains.Item(ArmorConstants.AbsorbingShield));
            Assert.That(shields.Count(), Is.EqualTo(11));
        }

        [Test]
        public void MundaneShields()
        {
            var shields = ArmorConstants.GetAllShields(false);

            Assert.That(shields, Contains.Item(ArmorConstants.Buckler));
            Assert.That(shields, Contains.Item(ArmorConstants.LightWoodenShield));
            Assert.That(shields, Contains.Item(ArmorConstants.LightSteelShield));
            Assert.That(shields, Contains.Item(ArmorConstants.HeavyWoodenShield));
            Assert.That(shields, Contains.Item(ArmorConstants.HeavySteelShield));
            Assert.That(shields, Contains.Item(ArmorConstants.TowerShield));
            Assert.That(shields.Count(), Is.EqualTo(6));
        }

        [Test]
        public void SpecificArmorsAndShields()
        {
            var specific = ArmorConstants.GetAllSpecificArmorsAndShields();
            Assert.That(specific, Contains.Item(ArmorConstants.ElvenChain));
            Assert.That(specific, Contains.Item(ArmorConstants.RhinoHide));
            Assert.That(specific, Contains.Item(ArmorConstants.DwarvenPlate));
            Assert.That(specific, Contains.Item(ArmorConstants.BandedMailOfLuck));
            Assert.That(specific, Contains.Item(ArmorConstants.CelestialArmor));
            Assert.That(specific, Contains.Item(ArmorConstants.PlateArmorOfTheDeep));
            Assert.That(specific, Contains.Item(ArmorConstants.BreastplateOfCommand));
            Assert.That(specific, Contains.Item(ArmorConstants.FullPlateOfSpeed));
            Assert.That(specific, Contains.Item(ArmorConstants.DemonArmor));
            Assert.That(specific, Contains.Item(ArmorConstants.ArmorOfRage));
            Assert.That(specific, Contains.Item(ArmorConstants.ArmorOfArrowAttraction));
            Assert.That(specific, Contains.Item(ArmorConstants.CastersShield));
            Assert.That(specific, Contains.Item(ArmorConstants.SpinedShield));
            Assert.That(specific, Contains.Item(ArmorConstants.LionsShield));
            Assert.That(specific, Contains.Item(ArmorConstants.WingedShield));
            Assert.That(specific, Contains.Item(ArmorConstants.AbsorbingShield));
            Assert.That(specific.Count(), Is.EqualTo(16));

        }

        [Test]
        public void SpecificArmors()
        {
            var specific = ArmorConstants.GetAllSpecificArmors();
            Assert.That(specific, Contains.Item(ArmorConstants.ElvenChain));
            Assert.That(specific, Contains.Item(ArmorConstants.RhinoHide));
            Assert.That(specific, Contains.Item(ArmorConstants.DwarvenPlate));
            Assert.That(specific, Contains.Item(ArmorConstants.BandedMailOfLuck));
            Assert.That(specific, Contains.Item(ArmorConstants.CelestialArmor));
            Assert.That(specific, Contains.Item(ArmorConstants.PlateArmorOfTheDeep));
            Assert.That(specific, Contains.Item(ArmorConstants.BreastplateOfCommand));
            Assert.That(specific, Contains.Item(ArmorConstants.FullPlateOfSpeed));
            Assert.That(specific, Contains.Item(ArmorConstants.DemonArmor));
            Assert.That(specific, Contains.Item(ArmorConstants.ArmorOfRage));
            Assert.That(specific, Contains.Item(ArmorConstants.ArmorOfArrowAttraction));
            Assert.That(specific.Count(), Is.EqualTo(11));
        }

        [Test]
        public void SpecificShields()
        {

            var specific = ArmorConstants.GetAllSpecificShields();
            Assert.That(specific, Contains.Item(ArmorConstants.CastersShield));
            Assert.That(specific, Contains.Item(ArmorConstants.SpinedShield));
            Assert.That(specific, Contains.Item(ArmorConstants.LionsShield));
            Assert.That(specific, Contains.Item(ArmorConstants.WingedShield));
            Assert.That(specific, Contains.Item(ArmorConstants.AbsorbingShield));
            Assert.That(specific.Count(), Is.EqualTo(5));
        }
    }
}