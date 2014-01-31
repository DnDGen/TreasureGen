using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor
{
    [TestFixture, PercentileTable("ArmorType")]
    public class ArmorTypeTests : PercentileTests
    {
        [Test]
        public void PaddedArmorPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.PaddedArmor, 1);
        }

        [Test]
        public void LeatherArmorPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.LeatherArmor, 2);
        }

        [Test]
        public void StuddedLeatherArmorPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.StuddedLeatherArmor, 3, 17);
        }

        [Test]
        public void ChainShirtPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.ChainShirt, 18, 32);
        }

        [Test]
        public void HideArmorPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.HideArmor, 33, 42);
        }

        [Test]
        public void ScaleMailPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.ScaleMail, 43);
        }

        [Test]
        public void ChainmailPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.Chainmail, 44);
        }

        [Test]
        public void BreastplatePercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.Breastplate, 45, 57);
        }

        [Test]
        public void SplintMailPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.SplintMail, 58);
        }

        [Test]
        public void BandedMailPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.BandedMail, 59);
        }

        [Test]
        public void HalfPlatePercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.HalfPlate, 60);
        }

        [Test]
        public void FullPlatePercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.FullPlate, 61, 100);
        }
    }
}