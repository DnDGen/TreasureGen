using Moq;
using NUnit.Framework;
using RollGen;
using System.Collections.Generic;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.RuntimeFactories;
using TreasureGen.Generators.Domain.RuntimeFactories.Domain;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Tests.Unit.Generators.RuntimeFactories
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
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            var mockAttributesSelector = new Mock<IAttributesSelector>();
            var mockChargesGenerator = new Mock<IChargesGenerator>();
            var mockDice = new Mock<Dice>();
            var mockSpellGenerator = new Mock<ISpellGenerator>();
            mockCurseGenerator = new Mock<ICurseGenerator>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            var mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMaterialGenerator = new Mock<ISpecialMaterialGenerator>();
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            var mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            var result = new TypeAndAmountPercentileResult();
            var mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            var mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();

            result.Amount = 1;
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<string>())).Returns(result);
            mockPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<string>())).Returns("0");
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<bool>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            factory = new MagicalItemGeneratorFactory(mockPercentileSelector.Object, mockTraitsGenerator.Object, mockIntelligenceGenerator.Object,
                mockAttributesSelector.Object, mockSpecialAbilitiesGenerator.Object, mockMaterialGenerator.Object, mockTraitsGenerator.Object,
                mockChargesGenerator.Object, mockDice.Object, mockSpellGenerator.Object, mockCurseGenerator.Object, mockTypeAndAmountPercentileSelector.Object,
                mockSpecificGearGenerator.Object, mockAmmunitionGenerator.Object, mockBooleanPercentileSelector.Object);

            var mockPartialRoll = new Mock<PartialRoll>();
            mockDice.Setup(d => d.Roll(It.IsAny<int>())).Returns(mockPartialRoll.Object);
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
        public void FactoryDecoratesGeneratorOf(string itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);
            var item = generator.GenerateAtPower(PowerConstants.Major);

            mockIntelligenceGenerator.Verify(g => g.IsIntelligent(itemType, It.IsAny<IEnumerable<string>>(), It.IsAny<bool>()), Times.Once, itemType);
            mockCurseGenerator.Verify(g => g.HasCurse(It.IsAny<bool>()), Times.Once, itemType);
            mockMaterialGenerator.Verify(g => g.CanHaveSpecialMaterial(itemType, It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()),
                Times.Once, itemType);
            mockTraitsGenerator.Verify(g => g.GenerateFor(itemType, It.IsAny<IEnumerable<string>>()), Times.Once, itemType);
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
        public void FactoryProxiesGeneratorOf(string itemType)
        {
            var generator = factory.CreateGeneratorOf(itemType);

            Assert.That(() => generator.GenerateAtPower(PowerConstants.Mundane), Throws.ArgumentException);
            mockIntelligenceGenerator.Verify(g => g.IsIntelligent(itemType, It.IsAny<IEnumerable<string>>(), It.IsAny<bool>()), Times.Never);
            mockCurseGenerator.Verify(g => g.HasCurse(It.IsAny<bool>()), Times.Never);
            mockPercentileSelector.Verify(s => s.SelectFrom(It.IsAny<string>()), Times.Never);
            mockTypeAndAmountPercentileSelector.Verify(s => s.SelectFrom(It.IsAny<string>()), Times.Never);
            mockMaterialGenerator.Verify(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()),
                Times.Never);
            mockTraitsGenerator.Verify(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>()), Times.Never);
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