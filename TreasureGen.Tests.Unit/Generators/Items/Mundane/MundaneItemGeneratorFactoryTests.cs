using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Collections.Generic;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
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
            var mockDice = new Mock<Dice>();
            var mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            var result = new TypeAndAmountPercentileResult();
            var mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            var mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();

            factory = new MundaneItemGeneratorFactory(mockPercentileSelector.Object, mockMaterialGenerator.Object, mockAttributesSelector.Object,
                mockDice.Object, mockTypeAndAmountPercentileSelector.Object, mockAmmunitionGenerator.Object, mockBooleanPercentileSelector.Object);

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<string>())).Returns(result);
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.AlchemicalItem)]
        [TestCase(ItemTypeConstants.Weapon)]
        [TestCase(ItemTypeConstants.Tool)]
        public void FactoryMakesGeneratorOf(string itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);
            var item = generator.Generate();
            Assert.That(item.ItemType, Is.EqualTo(itemType));
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.AlchemicalItem)]
        [TestCase(ItemTypeConstants.Weapon)]
        [TestCase(ItemTypeConstants.Tool)]
        public void FactoryDecoratesGeneratorOf(string itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);
            var item = generator.Generate();

            mockMaterialGenerator.Verify(g => g.CanHaveSpecialMaterial(itemType, It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<String>>()),
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
        public void InvalidItemType(string itemType)
        {
            Assert.That(() => factory.CreateGeneratorOf(itemType), Throws.ArgumentException.With.Message.EqualTo(itemType));
        }
    }
}