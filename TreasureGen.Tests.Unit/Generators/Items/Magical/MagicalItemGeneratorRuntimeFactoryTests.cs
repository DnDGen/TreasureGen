using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemGeneratorRuntimeFactoryTests
    {
        private IMagicalItemGeneratorRuntimeFactory factory;
        private Dictionary<string, Mock<MagicalItemGenerator>> mockMagicalItemGenerators;

        [SetUp]
        public void Setup()
        {
            mockMagicalItemGenerators = new Dictionary<string, Mock<MagicalItemGenerator>>();
            mockMagicalItemGenerators[ItemTypeConstants.Armor] = new Mock<MagicalItemGenerator>();
            mockMagicalItemGenerators[ItemTypeConstants.Potion] = new Mock<MagicalItemGenerator>();
            mockMagicalItemGenerators[ItemTypeConstants.Ring] = new Mock<MagicalItemGenerator>();
            mockMagicalItemGenerators[ItemTypeConstants.Rod] = new Mock<MagicalItemGenerator>();
            mockMagicalItemGenerators[ItemTypeConstants.Scroll] = new Mock<MagicalItemGenerator>();
            mockMagicalItemGenerators[ItemTypeConstants.Staff] = new Mock<MagicalItemGenerator>();
            mockMagicalItemGenerators[ItemTypeConstants.Wand] = new Mock<MagicalItemGenerator>();
            mockMagicalItemGenerators[ItemTypeConstants.Weapon] = new Mock<MagicalItemGenerator>();
            mockMagicalItemGenerators[ItemTypeConstants.WondrousItem] = new Mock<MagicalItemGenerator>();

            factory = new MagicalItemGeneratorRuntimeFactory(mockMagicalItemGenerators[ItemTypeConstants.Armor].Object, mockMagicalItemGenerators[ItemTypeConstants.Potion].Object,
                mockMagicalItemGenerators[ItemTypeConstants.Ring].Object, mockMagicalItemGenerators[ItemTypeConstants.Rod].Object, mockMagicalItemGenerators[ItemTypeConstants.Scroll].Object,
                mockMagicalItemGenerators[ItemTypeConstants.Staff].Object, mockMagicalItemGenerators[ItemTypeConstants.Wand].Object, mockMagicalItemGenerators[ItemTypeConstants.Weapon].Object,
                mockMagicalItemGenerators[ItemTypeConstants.WondrousItem].Object);
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Potion)]
        [TestCase(ItemTypeConstants.Ring)]
        [TestCase(ItemTypeConstants.Rod)]
        [TestCase(ItemTypeConstants.Scroll)]
        [TestCase(ItemTypeConstants.Staff)]
        [TestCase(ItemTypeConstants.Wand)]
        [TestCase(ItemTypeConstants.Weapon)]
        [TestCase(ItemTypeConstants.WondrousItem)]
        public void FactoryMakesGeneratorOf(string itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);
            Assert.That(generator, Is.EqualTo(mockMagicalItemGenerators[itemType].Object));
        }

        [TestCase(ItemTypeConstants.AlchemicalItem)]
        [TestCase(ItemTypeConstants.Tool)]
        [TestCase("item type")]
        public void InvalidItemType(string itemType)
        {
            Assert.That(() => factory.CreateGeneratorOf(itemType), Throws.ArgumentException.With.Message.EqualTo(itemType));
        }
    }
}