using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
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
            AssertContent(ArmorConstants.PaddedArmor, 1);
        }

        [Test]
        public void LeatherArmorPercentile()
        {
            AssertContent(ArmorConstants.LeatherArmor, 2);
        }

        [Test]
        public void StuddedLeatherArmorPercentile()
        {
            AssertContent(ArmorConstants.StuddedLeatherArmor, 3, 17);
        }

        [Test]
        public void ChainShirtPercentile()
        {
            AssertContent(ArmorConstants.ChainShirt, 18, 32);
        }

        [Test]
        public void HideArmorPercentile()
        {
            AssertContent(ArmorConstants.HideArmor, 33, 42);
        }

        [Test]
        public void ScaleMailPercentile()
        {
            AssertContent(ArmorConstants.ScaleMail, 43);
        }

        [Test]
        public void ChainmailPercentile()
        {
            AssertContent(ArmorConstants.Chainmail, 44);
        }

        [Test]
        public void BreastplatePercentile()
        {
            AssertContent(ArmorConstants.Breastplate, 45, 57);
        }

        [Test]
        public void SplintMailPercentile()
        {
            AssertContent(ArmorConstants.SplintMail, 58);
        }

        [Test]
        public void BandedMailPercentile()
        {
            AssertContent(ArmorConstants.BandedMail, 59);
        }

        [Test]
        public void HalfPlatePercentile()
        {
            AssertContent(ArmorConstants.HalfPlate, 60);
        }

        [Test]
        public void FullPlatePercentile()
        {
            AssertContent(ArmorConstants.FullPlate, 61, 100);
        }
    }
}