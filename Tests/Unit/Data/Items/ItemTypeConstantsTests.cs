using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class ItemTypeConstantsTests
    {
        [Test]
        public void AlchemicalConstant()
        {
            Assert.That(ItemTypeConstants.AlchemicalItem, Is.EqualTo("Alchemical Item"));
        }

        [Test]
        public void ArmorConstant()
        {
            Assert.That(ItemTypeConstants.Armor, Is.EqualTo("Armor"));
        }

        [Test]
        public void WeaponConstant()
        {
            Assert.That(ItemTypeConstants.Weapon, Is.EqualTo("Weapon"));
        }

        [Test]
        public void ToolConstant()
        {
            Assert.That(ItemTypeConstants.Tool, Is.EqualTo("Tool"));
        }
        [Test]
        public void PotionItemTypeConstant()
        {
            Assert.That(ItemTypeConstants.Potion, Is.EqualTo("Potion"));
        }

        [Test]
        public void RingItemTypeConstant()
        {
            Assert.That(ItemTypeConstants.Ring, Is.EqualTo("Ring"));
        }

        [Test]
        public void RodItemTypeConstant()
        {
            Assert.That(ItemTypeConstants.Rod, Is.EqualTo("Rod"));
        }

        [Test]
        public void ScrollItemTypeConstant()
        {
            Assert.That(ItemTypeConstants.Scroll, Is.EqualTo("Scroll"));
        }

        [Test]
        public void StaffItemTypeConstant()
        {
            Assert.That(ItemTypeConstants.Staff, Is.EqualTo("Staff"));
        }

        [Test]
        public void WandItemTypeConstant()
        {
            Assert.That(ItemTypeConstants.Wand, Is.EqualTo("Wand"));
        }

        [Test]
        public void WondrousItemTypeConstant()
        {
            Assert.That(ItemTypeConstants.WondrousItem, Is.EqualTo("Wondrous item"));
        }
    }
}
