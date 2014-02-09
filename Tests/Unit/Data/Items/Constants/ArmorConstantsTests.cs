using EquipmentGen.Core.Data.Items.Constants;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items.Constants
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
    }
}