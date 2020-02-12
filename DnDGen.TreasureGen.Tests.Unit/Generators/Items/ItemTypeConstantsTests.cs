using DnDGen.TreasureGen.Items;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class ItemTypeConstantsTests
    {
        [TestCase(ItemTypeConstants.AlchemicalItem, "Alchemical Item")]
        [TestCase(ItemTypeConstants.Armor, "Armor")]
        [TestCase(ItemTypeConstants.Weapon, "Weapon")]
        [TestCase(ItemTypeConstants.Tool, "Tool")]
        [TestCase(ItemTypeConstants.Potion, "Potion")]
        [TestCase(ItemTypeConstants.Ring, "Ring")]
        [TestCase(ItemTypeConstants.Rod, "Rod")]
        [TestCase(ItemTypeConstants.Scroll, "Scroll")]
        [TestCase(ItemTypeConstants.Staff, "Staff")]
        [TestCase(ItemTypeConstants.Wand, "Wand")]
        [TestCase(ItemTypeConstants.WondrousItem, "Wondrous Item")]
        public void ItemTypeConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}