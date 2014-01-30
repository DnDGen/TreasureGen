using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("MundaneArmor")]
    public class MundaneArmorTests : PercentileTests
    {
        [Test]
        public void ChainShirtPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.ChainShirt, 1, 12);
        }

        [Test]
        public void StuddedLeatherArmorPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.StuddedLeatherArmor, 13, 18);
        }

        [Test]
        public void BreastplatePercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.Breastplate, 19, 26);
        }

        [Test]
        public void BandedMailPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.BandedMail, 27, 34);
        }

        [Test]
        public void HalfPlatePercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.HalfPlate, 35, 54);
        }

        [Test]
        public void FullPlatePercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.FullPlate, 55, 80);
        }

        [Test]
        public void DarkwoodPercentile()
        {
            AssertContent(ItemsConstants.Gear.Traits.Darkwood, 81, 90);
        }

        [Test]
        public void MasterworkPercentile()
        {
            AssertContent(ItemsConstants.Gear.Traits.Masterwork, 91, 100);
        }
    }
}