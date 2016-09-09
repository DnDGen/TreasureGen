using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneItemGeneratorRuntimeFactoryTests
    {
        private IMundaneItemGeneratorRuntimeFactory factory;
        private Dictionary<string, Mock<MundaneItemGenerator>> mockMundaneItemGenerators;

        [SetUp]
        public void Setup()
        {
            mockMundaneItemGenerators = new Dictionary<string, Mock<MundaneItemGenerator>>();
            mockMundaneItemGenerators[ItemTypeConstants.Armor] = new Mock<MundaneItemGenerator>();
            mockMundaneItemGenerators[ItemTypeConstants.AlchemicalItem] = new Mock<MundaneItemGenerator>();
            mockMundaneItemGenerators[ItemTypeConstants.Tool] = new Mock<MundaneItemGenerator>();
            mockMundaneItemGenerators[ItemTypeConstants.Weapon] = new Mock<MundaneItemGenerator>();

            factory = new MundaneItemGeneratorRuntimeFactory(mockMundaneItemGenerators[ItemTypeConstants.Armor].Object, mockMundaneItemGenerators[ItemTypeConstants.Weapon].Object, mockMundaneItemGenerators[ItemTypeConstants.Tool].Object, mockMundaneItemGenerators[ItemTypeConstants.AlchemicalItem].Object);
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.AlchemicalItem)]
        [TestCase(ItemTypeConstants.Weapon)]
        [TestCase(ItemTypeConstants.Tool)]
        public void FactoryMakesGeneratorOf(string itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);
            Assert.That(generator, Is.EqualTo(mockMundaneItemGenerators[itemType].Object));
        }

        [TestCase(ItemTypeConstants.Potion)]
        [TestCase(ItemTypeConstants.Ring)]
        [TestCase(ItemTypeConstants.Rod)]
        [TestCase(ItemTypeConstants.Scroll)]
        [TestCase(ItemTypeConstants.Staff)]
        [TestCase(ItemTypeConstants.Wand)]
        [TestCase(ItemTypeConstants.WondrousItem)]
        [TestCase("item type")]
        public void InvalidItemType(string itemType)
        {
            Assert.That(() => factory.CreateGeneratorOf(itemType), Throws.ArgumentException.With.Message.EqualTo(itemType));
        }
    }
}