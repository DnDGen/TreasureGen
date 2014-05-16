using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
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

        [Test]
        public void InvalidTypeThrowsException()
        {
            Assert.That(() => factory.CreateGeneratorOf("invalid type"), Throws.InstanceOf<ArgumentOutOfRangeException>());
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

            mockMaterialGenerator.Verify(g => g.HasSpecialMaterial(itemType, It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()),
                Times.Once);
        }
    }
}