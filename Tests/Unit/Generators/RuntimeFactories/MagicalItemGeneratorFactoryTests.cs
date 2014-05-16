using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.RuntimeFactories;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.RuntimeFactories
{
    [TestFixture]
    public class MagicalItemGeneratorFactoryTests
    {
        private IMagicalItemGeneratorFactory factory;
        private Mock<IIntelligenceGenerator> mockIntelligenceGenerator;
        private Mock<ICurseGenerator> mockCurseGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ISpecialMaterialGenerator> mockMaterialGenerator;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            var mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            var mockAttributesSelector = new Mock<IAttributesSelector>();
            var mockChargesGenerator = new Mock<IChargesGenerator>();
            var mockDice = new Mock<IDice>();
            var mockSpellGenerator = new Mock<ISpellGenerator>();
            mockCurseGenerator = new Mock<ICurseGenerator>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            var mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMaterialGenerator = new Mock<ISpecialMaterialGenerator>();
            var mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            var mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            var result = new TypeAndAmountPercentileResult();

            result.Type = String.Empty;
            result.Amount = "0";
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<String>())).Returns(result);
            mockPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<String>())).Returns(result.Amount);

            factory = new MagicalItemGeneratorFactory(mockPercentileSelector.Object, mockTraitsGenerator.Object, mockIntelligenceGenerator.Object,
                mockAttributesSelector.Object, mockSpecialAbilitiesGenerator.Object, mockMaterialGenerator.Object, mockMagicItemTraitsGenerator.Object,
                mockChargesGenerator.Object, mockDice.Object, mockSpellGenerator.Object, mockCurseGenerator.Object, mockTypeAndAmountPercentileSelector.Object,
                mockSpecificGearGenerator.Object);
        }

        [Test]
        public void InvalidTypeThrowsException()
        {
            Assert.That(() => factory.CreateGeneratorOf("invalid type"), Throws.InstanceOf<ArgumentOutOfRangeException>());
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
        public void FactoryMakesGeneratorOf(String itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);
            var item = generator.GenerateAtPower(PowerConstants.Major);
            Assert.That(item.ItemType, Is.EqualTo(itemType));
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
        public void FactoryDecoratesGeneratorOf(String itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);
            var item = generator.GenerateAtPower(PowerConstants.Major);

            mockIntelligenceGenerator.Verify(g => g.IsIntelligent(itemType, It.IsAny<IEnumerable<String>>(), It.IsAny<Boolean>()), Times.Once);
            mockCurseGenerator.Verify(g => g.HasCurse(It.IsAny<Boolean>()), Times.Once);
            mockMaterialGenerator.Verify(g => g.HasSpecialMaterial(itemType, It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()),
                Times.Once);
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
        public void FactoryProxiesGeneratorOf(String itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);

            Assert.That(() => generator.GenerateAtPower(PowerConstants.Mundane), Throws.ArgumentException);
            mockIntelligenceGenerator.Verify(g => g.IsIntelligent(itemType, It.IsAny<IEnumerable<String>>(), It.IsAny<Boolean>()), Times.Never);
            mockCurseGenerator.Verify(g => g.HasCurse(It.IsAny<Boolean>()), Times.Never);
            mockPercentileSelector.Verify(s => s.SelectFrom(It.IsAny<String>()), Times.Never);
            mockTypeAndAmountPercentileSelector.Verify(s => s.SelectFrom(It.IsAny<String>()), Times.Never);
        }
    }
}