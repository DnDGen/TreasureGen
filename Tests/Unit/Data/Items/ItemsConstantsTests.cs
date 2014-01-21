using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class ItemsConstantsTests
    {
        [Test]
        public void MundanePowerConstant()
        {
            Assert.That(ItemsConstants.Power.Mundane, Is.EqualTo("Mundane"));
        }

        [Test]
        public void MinorPowerConstant()
        {
            Assert.That(ItemsConstants.Power.Minor, Is.EqualTo("Minor"));
        }

        [Test]
        public void MediumPowerConstant()
        {
            Assert.That(ItemsConstants.Power.Medium, Is.EqualTo("Medium"));
        }

        [Test]
        public void MajorPowerConstant()
        {
            Assert.That(ItemsConstants.Power.Major, Is.EqualTo("Major"));
        }

        [Test]
        public void AlchemicalItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.AlchemicalItem, Is.EqualTo("Alchemical Item"));
        }

        [Test]
        public void ArmorItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Armor, Is.EqualTo("Armor"));
        }

        [Test]
        public void WeaponItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Weapon, Is.EqualTo("Weapon"));
        }

        [Test]
        public void ToolItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Tool, Is.EqualTo("Tool"));
        }

        [Test]
        public void MasterworkGearTraitConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Masterwork, Is.EqualTo("Masterwork"));
        }

        [Test]
        public void DarkwoodGearTraitConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Darkwood, Is.EqualTo("Darkwood"));
        }

        [Test]
        public void SmallGearTraitConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Small, Is.EqualTo("Small"));
        }

        [Test]
        public void MediumGearTraitConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Medium, Is.EqualTo("Medium"));
        }

        [Test]
        public void PotionItemTypeConstants()
        {
            Assert.That(ItemsConstants.ItemTypes.Potion, Is.EqualTo("Potion"));
        }

        [Test]
        public void RingItemTypeConstants()
        {
            Assert.That(ItemsConstants.ItemTypes.Ring, Is.EqualTo("Ring"));
        }

        [Test]
        public void RodItemTypeConstants()
        {
            Assert.That(ItemsConstants.ItemTypes.Rod, Is.EqualTo("Rod"));
        }

        [Test]
        public void ScrollItemTypeConstants()
        {
            Assert.That(ItemsConstants.ItemTypes.Scroll, Is.EqualTo("Scroll"));
        }

        [Test]
        public void StaffItemTypeConstants()
        {
            Assert.That(ItemsConstants.ItemTypes.Staff, Is.EqualTo("Staff"));
        }

        [Test]
        public void WandItemTypeConstants()
        {
            Assert.That(ItemsConstants.ItemTypes.Wand, Is.EqualTo("Wand"));
        }

        [Test]
        public void WondrousItemTypeConstants()
        {
            Assert.That(ItemsConstants.ItemTypes.WondrousItem, Is.EqualTo("Wondrous item"));
        }
    }
}