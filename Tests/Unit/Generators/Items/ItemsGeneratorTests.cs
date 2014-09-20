using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using EquipmentGen.Tables.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class ItemsGeneratorTests
    {
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IMundaneItemGeneratorFactory> mockMundaneItemGeneratorFactory;
        private Mock<IMundaneItemGenerator> mockMundaneItemGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IMagicalItemGeneratorFactory> mockMagicalItemGeneratorFactory;
        private Mock<IMagicalItemGenerator> mockMagicalItemGenerator;
        private Mock<IDice> mockDice;
        private IItemsGenerator itemsGenerator;
        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            result = new TypeAndAmountPercentileResult();
            mockMundaneItemGeneratorFactory = new Mock<IMundaneItemGeneratorFactory>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockMagicalItemGenerator = new Mock<IMagicalItemGenerator>();
            mockMagicalItemGeneratorFactory = new Mock<IMagicalItemGeneratorFactory>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockMundaneItemGenerator = new Mock<IMundaneItemGenerator>();

            result.Type = "power";
            result.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns(result);
            mockDice.Setup(d => d.Roll(1).d(result.Amount)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns(ItemTypeConstants.WondrousItem);

            var dummyMagicalMock = new Mock<IMagicalItemGenerator>();
            var item = new Item();
            dummyMagicalMock.Setup(m => m.GenerateAtPower(It.IsAny<String>())).Returns(item);
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateGeneratorOf(It.IsAny<String>())).Returns(dummyMagicalMock.Object);
            var dummyMundaneMock = new Mock<IMundaneItemGenerator>();
            dummyMundaneMock.Setup(m => m.Generate()).Returns(item);
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf(It.IsAny<String>())).Returns(dummyMundaneMock.Object);

            itemsGenerator = new ItemsGenerator(mockTypeAndAmountPercentileSelector.Object, mockMundaneItemGeneratorFactory.Object, mockPercentileSelector.Object, mockMagicalItemGeneratorFactory.Object);
        }

        [Test]
        public void ItemsAreGenerated()
        {
            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Is.Not.Null);
        }

        [Test]
        public void GetItemTypeFromSelector()
        {
            itemsGenerator.GenerateAtLevel(9266);
            var expectedTableName = String.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 9266);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom(expectedTableName), Times.Once);
        }

        [Test]
        public void GetAmountFromRoll()
        {
            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items.Count(), Is.EqualTo(9266));
        }

        [Test]
        public void ReturnItems()
        {
            result.Type = PowerConstants.Mundane;
            result.Amount = 2;
            mockDice.Setup(d => d.Roll(1).d(result.Amount)).Returns(2);

            var firstItem = new Item();
            var secondItem = new Item();
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf(It.IsAny<String>())).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.SetupSequence(f => f.Generate()).Returns(firstItem).Returns(secondItem);

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Contains.Item(firstItem));
            Assert.That(items, Contains.Item(secondItem));
            Assert.That(items.Count(), Is.EqualTo(2));
        }

        [Test]
        public void IfSelectorReturnsEmptyResult_ItemsGeneratorReturnsEmptyEnumerable()
        {
            result.Type = String.Empty;
            result.Amount = 0;
            mockDice.Setup(d => d.Roll(1).d(result.Amount)).Throws(new Exception());

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Is.Empty);
        }

        [Test]
        public void GetMundaneItemsFromMundaneItemGenerator()
        {
            result.Type = PowerConstants.Mundane;
            result.Amount = 1;

            var mundaneItem = new Item();
            var expectedTableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, result.Type, "Item");
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("mundane item type");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("mundane item type")).Returns(mockMagicalItemGenerator.Object);
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("mundane item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(g => g.Generate()).Returns(mundaneItem);

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items.Single(), Is.EqualTo(mundaneItem));
        }

        [Test]
        public void GetMagicalItemsFromMagicalItemGenerator()
        {
            result.Type = "power";
            result.Amount = 1;

            var magicalItem = new Item();
            var expectedTableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, result.Type, "Item");
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("magic item type");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("magic item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower(result.Type)).Returns(magicalItem);

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items.Single(), Is.EqualTo(magicalItem));
        }
    }
}