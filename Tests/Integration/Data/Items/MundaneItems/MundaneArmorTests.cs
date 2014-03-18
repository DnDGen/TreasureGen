using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, PercentileTable("MundaneArmor")]
    public class MundaneArmorTests : PercentileTests
    {
        [Test]
        public void ChainShirtPercentile()
        {
            AssertContent(ArmorConstants.ChainShirt, 1, 12);
        }

        [Test]
        public void StuddedLeatherArmorPercentile()
        {
            AssertContent(ArmorConstants.StuddedLeatherArmor, 13, 18);
        }

        [Test]
        public void BreastplatePercentile()
        {
            AssertContent(ArmorConstants.Breastplate, 19, 26);
        }

        [Test]
        public void BandedMailPercentile()
        {
            AssertContent(ArmorConstants.BandedMail, 27, 34);
        }

        [Test]
        public void HalfPlatePercentile()
        {
            AssertContent(ArmorConstants.HalfPlate, 35, 54);
        }

        [Test]
        public void FullPlatePercentile()
        {
            AssertContent(ArmorConstants.FullPlate, 55, 80);
        }

        [Test]
        public void DarkwoodPercentile()
        {
            AssertContent(TraitConstants.Darkwood, 81, 90);
        }

        [Test]
        public void MasterworkPercentile()
        {
            AssertContent(TraitConstants.Masterwork, 91, 100);
        }
    }
}