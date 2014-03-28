using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor
{
    [TestFixture, PercentileTable("ArmorTypes")]
    public class ArmorTypesTests : PercentileTests
    {
        [Test]
        public void PaddedArmorPercentile()
        {
            AssertPercentile(ArmorConstants.PaddedArmor, 1);
        }

        [Test]
        public void LeatherArmorPercentile()
        {
            AssertPercentile(ArmorConstants.LeatherArmor, 2);
        }

        [Test]
        public void StuddedLeatherArmorPercentile()
        {
            AssertPercentile(ArmorConstants.StuddedLeatherArmor, 3, 17);
        }

        [Test]
        public void ChainShirtPercentile()
        {
            AssertPercentile(ArmorConstants.ChainShirt, 18, 32);
        }

        [Test]
        public void HideArmorPercentile()
        {
            AssertPercentile(ArmorConstants.HideArmor, 33, 42);
        }

        [Test]
        public void ScaleMailPercentile()
        {
            AssertPercentile(ArmorConstants.ScaleMail, 43);
        }

        [Test]
        public void ChainmailPercentile()
        {
            AssertPercentile(ArmorConstants.Chainmail, 44);
        }

        [Test]
        public void BreastplatePercentile()
        {
            AssertPercentile(ArmorConstants.Breastplate, 45, 57);
        }

        [Test]
        public void SplintMailPercentile()
        {
            AssertPercentile(ArmorConstants.SplintMail, 58);
        }

        [Test]
        public void BandedMailPercentile()
        {
            AssertPercentile(ArmorConstants.BandedMail, 59);
        }

        [Test]
        public void HalfPlatePercentile()
        {
            AssertPercentile(ArmorConstants.HalfPlate, 60);
        }

        [Test]
        public void FullPlatePercentile()
        {
            AssertPercentile(ArmorConstants.FullPlate, 61, 100);
        }
    }
}