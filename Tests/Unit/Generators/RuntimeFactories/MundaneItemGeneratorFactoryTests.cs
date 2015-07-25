using System;
using System.Collections.Generic;
using D20Dice;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Interfaces.Items.Mundane;
using TreasureGen.Generators.RuntimeFactories;
using TreasureGen.Generators.RuntimeFactories.Interfaces;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Generators.RuntimeFactories
{
    [TestFixture]
    public class MundaneItemGeneratorFactoryTests
    {
        private IMundaneItemGeneratorFactory factory;
        private Mock<ISpecialMaterialGenerator> mockMaterialGenerator;

        [SetUp]
        public void Setup()
        {
            var mockPercentileSelector = new Mock<IPercentileSelector>();
            mockMaterialGenerator = new Mock<ISpecialMaterialGenerator>();
            var mockAttributesSelector = new Mock<IAttributesSelector>();
            var mockDice = new Mock<IDice>();
            var mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            var result = new TypeAndAmountPercentileResult();
            var mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();

            factory = new MundaneItemGeneratorFactory(mockPercentileSelector.Object, mockMaterialGenerator.Object, mockAttributesSelector.Object,
                mockDice.Object, mockTypeAndAmountPercentileSelector.Object, mockAmmunitionGenerator.Object);

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<String>())).Returns(result);
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.AlchemicalItem)]
        [TestCase(ItemTypeConstants.Weapon)]
        [TestCase(ItemTypeConstants.Tool)]
        public void FactoryMakesGeneratorOf(String itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);
            var item = generator.Generate();
            Assert.That(item.ItemType, Is.EqualTo(itemType));
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.AlchemicalItem)]
        [TestCase(ItemTypeConstants.Weapon)]
        [TestCase(ItemTypeConstants.Tool)]
        public void FactoryDecoratesGeneratorOf(String itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);
            var item = generator.Generate();

            mockMaterialGenerator.Verify(g => g.CanHaveSpecialMaterial(itemType, It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()),
                Times.Once);
        }

        [TestCase(ItemTypeConstants.Potion)]
        [TestCase(ItemTypeConstants.Ring)]
        [TestCase(ItemTypeConstants.Rod)]
        [TestCase(ItemTypeConstants.Scroll)]
        [TestCase(ItemTypeConstants.Staff)]
        [TestCase(ItemTypeConstants.Wand)]
        [TestCase(ItemTypeConstants.WondrousItem)]
        [TestCase("item type")]
        public void InvalidItemType(String itemType)
        {
            Assert.That(() => factory.CreateGeneratorOf(itemType), Throws.ArgumentException.With.Message.EqualTo(itemType));
        }
    }
}