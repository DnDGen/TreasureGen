using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class ArmorConstantsTests
    {
        [Test]
        public void PaddedArmorConstant()
        {
            Assert.That(ArmorConstants.PaddedArmor, Is.EqualTo("Padded armor"));
        }

        [Test]
        public void LeatherArmorConstant()
        {
            Assert.That(ArmorConstants.LeatherArmor, Is.EqualTo("Leather armor"));
        }

        [Test]
        public void StuddedLeatherArmorConstant()
        {
            Assert.That(ArmorConstants.StuddedLeatherArmor, Is.EqualTo("Studded leather armor"));
        }

        [Test]
        public void ChainShirtConstant()
        {
            Assert.That(ArmorConstants.ChainShirt, Is.EqualTo("Chain shirt"));
        }

        [Test]
        public void HideArmorConstant()
        {
            Assert.That(ArmorConstants.HideArmor, Is.EqualTo("Hide armor"));
        }

        [Test]
        public void ScaleMailConstant()
        {
            Assert.That(ArmorConstants.ScaleMail, Is.EqualTo("Scale mail"));
        }

        [Test]
        public void ChainmailConstant()
        {
            Assert.That(ArmorConstants.Chainmail, Is.EqualTo("Chainmail"));
        }

        [Test]
        public void BreastplateConstant()
        {
            Assert.That(ArmorConstants.Breastplate, Is.EqualTo("Breastplate"));
        }

        [Test]
        public void SplintMailConstant()
        {
            Assert.That(ArmorConstants.SplintMail, Is.EqualTo("Splint mail"));
        }

        [Test]
        public void BandedMailConstant()
        {
            Assert.That(ArmorConstants.BandedMail, Is.EqualTo("Banded mail"));
        }

        [Test]
        public void HalfPlateConstant()
        {
            Assert.That(ArmorConstants.HalfPlate, Is.EqualTo("Half-plate"));
        }

        [Test]
        public void FullPlateConstant()
        {
            Assert.That(ArmorConstants.FullPlate, Is.EqualTo("Full plate"));
        }

        [Test]
        public void BucklerConstant()
        {
            Assert.That(ArmorConstants.Buckler, Is.EqualTo("Buckler"));
        }

        [Test]
        public void LightWoodenShieldConstant()
        {
            Assert.That(ArmorConstants.LightWoodenShield, Is.EqualTo("Light wooden shield"));
        }

        [Test]
        public void LightSteelShieldConstant()
        {
            Assert.That(ArmorConstants.LightSteelShield, Is.EqualTo("Light steel shield"));
        }

        [Test]
        public void HeavyWoodenShieldConstant()
        {
            Assert.That(ArmorConstants.HeavyWoodenShield, Is.EqualTo("Heavy wooden shield"));
        }

        [Test]
        public void HeavySteelShieldConstant()
        {
            Assert.That(ArmorConstants.HeavySteelShield, Is.EqualTo("Heavy steel shield"));
        }

        [Test]
        public void TowerShieldConstant()
        {
            Assert.That(ArmorConstants.TowerShield, Is.EqualTo("Tower shield"));
        }

        [Test]
        public void MithralShirtConstant()
        {
            Assert.That(ArmorConstants.MithralShirt, Is.EqualTo("Mithral shirt"));
        }

        [Test]
        public void DragonhidePlateConstant()
        {
            Assert.That(ArmorConstants.DragonhidePlate, Is.EqualTo("Dragonhide plate"));
        }

        [Test]
        public void ElvenChainConstant()
        {
            Assert.That(ArmorConstants.ElvenChain, Is.EqualTo("Elven chain"));
        }

        [Test]
        public void RhinoHideConstant()
        {
            Assert.That(ArmorConstants.RhinoHide, Is.EqualTo("Rhino hide"));
        }

        [Test]
        public void AdamantineBreastplateConstant()
        {
            Assert.That(ArmorConstants.AdamantineBreastplate, Is.EqualTo("Adamantine breastplate"));
        }

        [Test]
        public void DwarvenPlateConstant()
        {
            Assert.That(ArmorConstants.DwarvenPlate, Is.EqualTo("Dwarven plate"));
        }

        [Test]
        public void BandedMailOfLuckConstant()
        {
            Assert.That(ArmorConstants.BandedMailOfLuck, Is.EqualTo("Banded mail of luck"));
        }

        [Test]
        public void CelestialArmorConstant()
        {
            Assert.That(ArmorConstants.CelestialArmor, Is.EqualTo("Celestial armor"));
        }

        [Test]
        public void PlateArmorOfTheDeepConstant()
        {
            Assert.That(ArmorConstants.PlateArmorOfTheDeep, Is.EqualTo("Plate armor of the deep"));
        }

        [Test]
        public void BreastplateOfCommandConstant()
        {
            Assert.That(ArmorConstants.BreastplateOfCommand, Is.EqualTo("Breastplate of command"));
        }

        [Test]
        public void MithralFullPlateOfSpeedConstant()
        {
            Assert.That(ArmorConstants.MithralFullPlateOfSpeed, Is.EqualTo("Mithral full plate of speed"));
        }

        [Test]
        public void DemonArmorConstant()
        {
            Assert.That(ArmorConstants.DemonArmor, Is.EqualTo("Demon armor"));
        }

        [Test]
        public void DarkwoodBucklerConstant()
        {
            Assert.That(ArmorConstants.DarkwoodBuckler, Is.EqualTo("Darkwood buckler"));
        }

        [Test]
        public void DarkwoodShieldConstant()
        {
            Assert.That(ArmorConstants.DarkwoodShield, Is.EqualTo("Darkwood shield"));
        }

        [Test]
        public void MithralHeavyShieldConstant()
        {
            Assert.That(ArmorConstants.MithralHeavyShield, Is.EqualTo("Mithral heavy shield"));
        }

        [Test]
        public void CastersShieldConstant()
        {
            Assert.That(ArmorConstants.CastersShield, Is.EqualTo("Caster's shield"));
        }

        [Test]
        public void SpinedShieldConstant()
        {
            Assert.That(ArmorConstants.SpinedShield, Is.EqualTo("Spined shield"));
        }

        [Test]
        public void LionsShieldConstant()
        {
            Assert.That(ArmorConstants.LionsShield, Is.EqualTo("Lion's shield"));
        }

        [Test]
        public void WingedShieldConstant()
        {
            Assert.That(ArmorConstants.WingedShield, Is.EqualTo("Winged shield"));
        }

        [Test]
        public void AbsorbingShieldConstant()
        {
            Assert.That(ArmorConstants.AbsorbingShield, Is.EqualTo("Absorbing shield"));
        }
    }
}