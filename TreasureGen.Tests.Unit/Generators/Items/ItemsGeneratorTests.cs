using DnDGen.Core.Generators;
using Moq;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Generators.Items;
using TreasureGen.Selectors.Collections;
using TreasureGen.Selectors.Percentiles;
using TreasureGen.Selectors.Selections;
using TreasureGen.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class ItemsGeneratorTests
    {
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<JustInTimeFactory> mockJustInTimeFactory;
        private Mock<MundaneItemGenerator> mockMundaneItemGenerator;
        private Mock<ITreasurePercentileSelector> mockPercentileSelector;
        private Mock<MagicalItemGenerator> mockMagicalItemGenerator;
        private Mock<IRangeDataSelector> mockRangeDataSelector;
        private IItemsGenerator itemsGenerator;
        private TypeAndAmountSelection selection;

        [SetUp]
        public void Setup()
        {
            selection = new TypeAndAmountSelection();
            mockJustInTimeFactory = new Mock<JustInTimeFactory>();
            mockPercentileSelector = new Mock<ITreasurePercentileSelector>();
            mockMagicalItemGenerator = new Mock<MagicalItemGenerator>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            mockRangeDataSelector = new Mock<IRangeDataSelector>();

            itemsGenerator = new ItemsGenerator(mockTypeAndAmountPercentileSelector.Object, mockJustInTimeFactory.Object, mockPercentileSelector.Object, mockRangeDataSelector.Object);

            selection.Type = "power";
            selection.Amount = 42;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns(selection);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns(ItemTypeConstants.WondrousItem);

            var dummyMagicalMock = new Mock<MagicalItemGenerator>();
            dummyMagicalMock.Setup(m => m.GenerateFrom(It.IsAny<string>())).Returns(() => new Item { Name = "magical item" });
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>(It.IsAny<string>())).Returns(dummyMagicalMock.Object);

            var dummyMundaneMock = new Mock<MundaneItemGenerator>();
            dummyMundaneMock.Setup(m => m.Generate()).Returns(() => new Item { Name = "mundane item" });
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(It.IsAny<string>())).Returns(dummyMundaneMock.Object);

            var range = new RangeSelection { Maximum = 0, Minimum = 0 };
            mockRangeDataSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.EpicItems, It.IsAny<string>())).Returns(range);
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
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 9266);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom(expectedTableName), Times.Once);
        }

        [Test]
        public void GetAmountFromRoll()
        {
            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items.Count(), Is.EqualTo(42));
        }

        [Test]
        public void ReturnItems()
        {
            selection.Type = PowerConstants.Mundane;
            selection.Amount = 2;

            var firstItem = new Item();
            var secondItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(It.IsAny<string>())).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.SetupSequence(f => f.Generate()).Returns(firstItem).Returns(secondItem);

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Contains.Item(firstItem));
            Assert.That(items, Contains.Item(secondItem));
            Assert.That(items.Count(), Is.EqualTo(2));
        }

        [Test]
        public void IfSelectorReturnsEmptyResult_ItemsGeneratorReturnsEmptyEnumerable()
        {
            selection.Type = string.Empty;
            selection.Amount = 0;

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Is.Empty);
        }

        [Test]
        public void GetMundaneItems()
        {
            selection.Type = PowerConstants.Mundane;
            selection.Amount = 1;

            var mundaneItem = new Item();
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, selection.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("mundane item type");
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("mundane item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(g => g.Generate()).Returns(mundaneItem);

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items.Single(), Is.EqualTo(mundaneItem));
        }

        [Test]
        public void GetMagicalItems()
        {
            selection.Type = "power";
            selection.Amount = 1;

            var magicalItem = new Item();
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, selection.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("magic item type");
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("magic item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.GenerateFrom(selection.Type)).Returns(magicalItem);

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items.Single(), Is.EqualTo(magicalItem));
        }

        [Test]
        public void GenerateEpicItems()
        {
            var range = new RangeSelection { Maximum = 600, Minimum = 600 };
            mockRangeDataSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.EpicItems, "9266")).Returns(range);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Major);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("epic");

            var epicMagicalMock = new Mock<MagicalItemGenerator>();
            epicMagicalMock.Setup(m => m.GenerateFrom(It.IsAny<string>())).Returns(() => new Item { Name = "epic item" });
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("epic")).Returns(epicMagicalMock.Object);

            var items = itemsGenerator.GenerateAtLevel(9266);
            Assert.That(items.Count(), Is.EqualTo(642));
            Assert.That(items.Count(i => i.Name == "epic item"), Is.EqualTo(600));
            Assert.That(items.Count(i => i.Name == "magical item"), Is.EqualTo(42));
            Assert.That(items, Is.Unique);
        }

        [Test]
        public void GenerateOnlyEpicItems()
        {
            selection.Type = string.Empty;
            selection.Amount = 0;

            var range = new RangeSelection { Maximum = 600, Minimum = 600 };
            mockRangeDataSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.EpicItems, "9266")).Returns(range);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Major);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("epic");

            var epicMagicalMock = new Mock<MagicalItemGenerator>();
            epicMagicalMock.Setup(m => m.GenerateFrom(It.IsAny<string>())).Returns(() => new Item { Name = "epic item" });
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("epic")).Returns(epicMagicalMock.Object);

            var items = itemsGenerator.GenerateAtLevel(9266);
            Assert.That(items.Count(), Is.EqualTo(600));
            Assert.That(items.Count(i => i.Name == "epic item"), Is.EqualTo(600));
            Assert.That(items, Is.Unique);
        }
    }
}