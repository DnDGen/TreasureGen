using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Generators.Items;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
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
        private Mock<ICollectionSelector> mockCollectionSelector;

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
            mockCollectionSelector = new Mock<ICollectionSelector>();

            itemsGenerator = new ItemsGenerator(
                mockTypeAndAmountPercentileSelector.Object,
                mockJustInTimeFactory.Object,
                mockPercentileSelector.Object,
                mockRangeDataSelector.Object,
                mockCollectionSelector.Object);

            selection.Type = "power";
            selection.Amount = 42;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns(selection);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns(ItemTypeConstants.WondrousItem);

            var dummyMagicalMock = new Mock<MagicalItemGenerator>();
            dummyMagicalMock.Setup(m => m.GenerateRandom(It.IsAny<string>())).Returns(() => new Item { Name = "magical item" });
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>(It.IsAny<string>())).Returns(dummyMagicalMock.Object);

            var dummyMundaneMock = new Mock<MundaneItemGenerator>();
            dummyMundaneMock.Setup(m => m.GenerateRandom()).Returns(() => new Item { Name = "mundane item" });
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(It.IsAny<string>())).Returns(dummyMundaneMock.Object);

            var range = new RangeSelection { Maximum = 0, Minimum = 0 };
            mockRangeDataSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.EpicItems, It.IsAny<string>())).Returns(range);
        }

        [Test]
        public void GenerateRandomAtLevel_ItemsAreGenerated()
        {
            var items = itemsGenerator.GenerateRandomAtLevel(1);
            Assert.That(items, Is.Not.Null);
        }

        [Test]
        public void GenerateRandomAtLevel_GetItemTypeFromSelector()
        {
            itemsGenerator.GenerateRandomAtLevel(9266);
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 9266);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom(expectedTableName), Times.Once);
        }

        [Test]
        public void GenerateRandomAtLevel_GetAmountFromRoll()
        {
            var items = itemsGenerator.GenerateRandomAtLevel(1);
            Assert.That(items.Count(), Is.EqualTo(42));
        }

        [Test]
        public void GenerateRandomAtLevel_ReturnItems()
        {
            selection.Type = PowerConstants.Mundane;
            selection.Amount = 2;

            var firstItem = new Item();
            var secondItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(It.IsAny<string>())).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.SetupSequence(f => f.GenerateRandom()).Returns(firstItem).Returns(secondItem);

            var items = itemsGenerator.GenerateRandomAtLevel(1);
            Assert.That(items, Contains.Item(firstItem));
            Assert.That(items, Contains.Item(secondItem));
            Assert.That(items.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GenerateRandomAtLevel_IfSelectorReturnsEmptyResult_ItemsGeneratorReturnsEmptyEnumerable()
        {
            selection.Type = string.Empty;
            selection.Amount = 0;

            var items = itemsGenerator.GenerateRandomAtLevel(1);
            Assert.That(items, Is.Empty);
        }

        [Test]
        public void GenerateRandomAtLevel_GetMundaneItems()
        {
            selection.Type = PowerConstants.Mundane;
            selection.Amount = 1;

            var mundaneItem = new Item();
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, selection.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("mundane item type");
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("mundane item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(g => g.GenerateRandom()).Returns(mundaneItem);

            var items = itemsGenerator.GenerateRandomAtLevel(1);
            Assert.That(items.Single(), Is.EqualTo(mundaneItem));
        }

        [Test]
        public void GenerateRandomAtLevel_GetMagicalItems()
        {
            selection.Type = "power";
            selection.Amount = 1;

            var magicalItem = new Item();
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, selection.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("magic item type");
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("magic item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.GenerateRandom(selection.Type)).Returns(magicalItem);

            var items = itemsGenerator.GenerateRandomAtLevel(1);
            Assert.That(items.Single(), Is.EqualTo(magicalItem));
        }

        [Test]
        public void GenerateRandomAtLevel_GenerateEpicItems()
        {
            var range = new RangeSelection { Maximum = 600, Minimum = 600 };
            mockRangeDataSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.EpicItems, "9266")).Returns(range);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Major);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("epic");

            var epicMagicalMock = new Mock<MagicalItemGenerator>();
            epicMagicalMock.Setup(m => m.GenerateRandom(It.IsAny<string>())).Returns(() => new Item { Name = "epic item" });
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("epic")).Returns(epicMagicalMock.Object);

            var items = itemsGenerator.GenerateRandomAtLevel(9266);
            Assert.That(items.Count(), Is.EqualTo(642));
            Assert.That(items.Count(i => i.Name == "epic item"), Is.EqualTo(600));
            Assert.That(items.Count(i => i.Name == "magical item"), Is.EqualTo(42));
            Assert.That(items, Is.Unique);
        }

        [Test]
        public void GenerateRandomAtLevel_GenerateOnlyEpicItems()
        {
            selection.Type = string.Empty;
            selection.Amount = 0;

            var range = new RangeSelection { Maximum = 600, Minimum = 600 };
            mockRangeDataSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.EpicItems, "9266")).Returns(range);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Major);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("epic");

            var epicMagicalMock = new Mock<MagicalItemGenerator>();
            epicMagicalMock.Setup(m => m.GenerateRandom(It.IsAny<string>())).Returns(() => new Item { Name = "epic item" });
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("epic")).Returns(epicMagicalMock.Object);

            var items = itemsGenerator.GenerateRandomAtLevel(9266);
            Assert.That(items.Count(), Is.EqualTo(600));
            Assert.That(items.Count(i => i.Name == "epic item"), Is.EqualTo(600));
            Assert.That(items, Is.Unique);
        }

        [Test]
        public async Task GenerateRandomAtLevelAsync_ItemsAreGenerated()
        {
            var items = await itemsGenerator.GenerateRandomAtLevelAsync(1);
            Assert.That(items, Is.Not.Null);
        }

        [Test]
        public async Task GenerateRandomAtLevelAsync_GetItemTypeFromSelector()
        {
            await itemsGenerator.GenerateRandomAtLevelAsync(9266);
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 9266);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom(expectedTableName), Times.Once);
        }

        [Test]
        public async Task GenerateRandomAtLevelAsync_GetAmountFromRoll()
        {
            var items = await itemsGenerator.GenerateRandomAtLevelAsync(1);
            Assert.That(items.Count(), Is.EqualTo(42));
        }

        [Test]
        public async Task GenerateRandomAtLevelAsync_ReturnItems()
        {
            selection.Type = PowerConstants.Mundane;
            selection.Amount = 2;

            var firstItem = new Item();
            var secondItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(It.IsAny<string>())).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator
                .SetupSequence(f => f.GenerateRandom())
                .Returns(firstItem)
                .Returns(secondItem);

            var items = await itemsGenerator.GenerateRandomAtLevelAsync(1);
            Assert.That(items, Contains.Item(firstItem));
            Assert.That(items, Contains.Item(secondItem));
            Assert.That(items.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GenerateRandomAtLevelAsync_IfSelectorReturnsEmptyResult_ItemsGeneratorReturnsEmptyEnumerable()
        {
            selection.Type = string.Empty;
            selection.Amount = 0;

            var items = await itemsGenerator.GenerateRandomAtLevelAsync(1);
            Assert.That(items, Is.Empty);
        }

        [Test]
        public async Task GenerateRandomAtLevelAsync_GetMundaneItems()
        {
            selection.Type = PowerConstants.Mundane;
            selection.Amount = 1;

            var mundaneItem = new Item();
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, selection.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("mundane item type");
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("mundane item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(g => g.GenerateRandom()).Returns(mundaneItem);

            var items = await itemsGenerator.GenerateRandomAtLevelAsync(1);
            Assert.That(items.Single(), Is.EqualTo(mundaneItem));
        }

        [Test]
        public async Task GenerateRandomAtLevelAsync_GetMagicalItems()
        {
            selection.Type = "power";
            selection.Amount = 1;

            var magicalItem = new Item();
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, selection.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("magic item type");
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("magic item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.GenerateRandom(selection.Type)).Returns(magicalItem);

            var items = await itemsGenerator.GenerateRandomAtLevelAsync(1);
            Assert.That(items.Single(), Is.EqualTo(magicalItem));
        }

        [Test]
        public async Task GenerateRandomAtLevelAsync_GenerateEpicItems()
        {
            var range = new RangeSelection { Maximum = 600, Minimum = 600 };
            mockRangeDataSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.EpicItems, "9266")).Returns(range);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Major);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("epic");

            var epicMagicalMock = new Mock<MagicalItemGenerator>();
            epicMagicalMock.Setup(m => m.GenerateRandom(It.IsAny<string>())).Returns(() => new Item { Name = "epic item" });
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("epic")).Returns(epicMagicalMock.Object);

            var items = await itemsGenerator.GenerateRandomAtLevelAsync(9266);
            Assert.That(items.Count(), Is.EqualTo(642));
            Assert.That(items.Count(i => i.Name == "epic item"), Is.EqualTo(600));
            Assert.That(items.Count(i => i.Name == "magical item"), Is.EqualTo(42));
            Assert.That(items, Is.Unique);
        }

        [Test]
        public async Task GenerateRandomAtLevelAsync_GenerateOnlyEpicItems()
        {
            selection.Type = string.Empty;
            selection.Amount = 0;

            var range = new RangeSelection { Maximum = 600, Minimum = 600 };
            mockRangeDataSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.EpicItems, "9266")).Returns(range);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Major);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("epic");

            var epicMagicalMock = new Mock<MagicalItemGenerator>();
            epicMagicalMock.Setup(m => m.GenerateRandom(It.IsAny<string>())).Returns(() => new Item { Name = "epic item" });
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("epic")).Returns(epicMagicalMock.Object);

            var items = await itemsGenerator.GenerateRandomAtLevelAsync(9266);
            Assert.That(items.Count(), Is.EqualTo(600));
            Assert.That(items.Count(i => i.Name == "epic item"), Is.EqualTo(600));
            Assert.That(items, Is.Unique);
        }

        [Test]
        public void GenerateAtLevel_Named_GetMundaneItem()
        {
            selection.Type = PowerConstants.Mundane;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var firstItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(f => f.Generate("item name")).Returns(firstItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(firstItem));
        }

        [Test]
        public void BUG_GenerateAtLevel_Named_GetMundaneItem_WhenNoPowerSpecified()
        {
            selection.Type = string.Empty;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var firstItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(f => f.Generate("item name")).Returns(firstItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(firstItem));
        }

        [Test]
        public void BUG_GenerateAtLevel_Named_GetSpecificItem_WhenMundaneSpecified()
        {
            Assert.Fail("not yet written");
        }

        [Test]
        public void BUG_GenerateAtLevel_Named_GetMagicalItem_WhenNoPowerSpecified()
        {
            selection.Type = string.Empty;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { "power", "more power", "wrong power" });

            var magicalItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.Generate("power", "item name")).Returns(magicalItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public void BUG_GenerateAtLevel_Named_GetMundaneItem_WhenPowerIsMagical_ButItemTypeIsMundane()
        {
            selection.Type = "power";

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane });

            var firstItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(f => f.Generate("item name")).Returns(firstItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(firstItem));
        }

        [Test]
        public void BUG_GenerateAtLevel_Named_GetMagicalItem_WhenPowerIsMundane_ButItemTypeIsMagical()
        {
            selection.Type = PowerConstants.Mundane;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { "power", "more power", "wrong power" });

            var magicalItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.Generate("power", "item name")).Returns(magicalItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public void BUG_GenerateAtLevel_Named_GetMagicalItem_WhenPowerIsMagical_ButItemTypeIsHigherMagical()
        {
            selection.Type = "power";

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { "more power", "wrong power" });

            var magicalItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.Generate("more power", "item name")).Returns(magicalItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public void GenerateAtLevel_Named_GetMundaneItem_WithTraits()
        {
            selection.Type = PowerConstants.Mundane;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var firstItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(f => f.Generate("item name", "trait 1", "trait 2")).Returns(firstItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name", "trait 1", "trait 2");
            Assert.That(item, Is.EqualTo(firstItem));
        }

        [Test]
        public void GenerateAtLevel_Named_GetMagicalItem()
        {
            selection.Type = "power";

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var magicalItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.Generate("power", "item name")).Returns(magicalItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public void GenerateAtLevel_Named_GetMagicalItem_WithTraits()
        {
            selection.Type = "power";

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var magicalItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.Generate("power", "item name", "trait 1", "trait 2")).Returns(magicalItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name", "trait 1", "trait 2");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public void GenerateAtLevel_Named_GetPowerFromSelector()
        {
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            itemsGenerator.GenerateAtLevel(9266, "item type", "item name");
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 9266);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom(expectedTableName), Times.Once);
        }

        [Test]
        public void GenerateAtLevel_Named_ReturnItem()
        {
            selection.Type = PowerConstants.Mundane;
            selection.Amount = 2;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var generatedItem = new Item();
            mockJustInTimeFactory
                .Setup(f => f.Build<MundaneItemGenerator>("item type"))
                .Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator
                .Setup(f => f.Generate("item name"))
                .Returns(generatedItem);

            var item = itemsGenerator.GenerateAtLevel(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(generatedItem));
        }

        [Test]
        public async Task GenerateAtLevelAsync_Named_GetPowerFromSelector()
        {
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            await itemsGenerator.GenerateAtLevelAsync(9266, "item type", "item name");
            var expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 9266);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom(expectedTableName), Times.Once);
        }

        [Test]
        public async Task GenerateAtLevelAsync_Named_ReturnItem()
        {
            selection.Type = PowerConstants.Mundane;
            selection.Amount = 2;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var generatedItem = new Item();
            mockJustInTimeFactory
                .Setup(f => f.Build<MundaneItemGenerator>("item type"))
                .Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator
                .Setup(f => f.Generate("item name"))
                .Returns(generatedItem);

            var item = await itemsGenerator.GenerateAtLevelAsync(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(generatedItem));
        }

        [Test]
        public async Task GenerateAtLevelAsync_Named_GetMundaneItem()
        {
            selection.Type = PowerConstants.Mundane;
            selection.Amount = 1;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var mundaneItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(g => g.Generate("item name")).Returns(mundaneItem);

            var item = await itemsGenerator.GenerateAtLevelAsync(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(mundaneItem));
        }

        [Test]
        public async Task BUG_GenerateAtLevelAsync_Named_GetMundaneItem_WithNoPower()
        {
            selection.Type = string.Empty;
            selection.Amount = 1;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var mundaneItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(g => g.Generate("item name")).Returns(mundaneItem);

            var item = await itemsGenerator.GenerateAtLevelAsync(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(mundaneItem));
        }

        [Test]
        public async Task BUG_GenerateAtLevelAsync_Named_GetMagicalItem_WithNoPower()
        {
            selection.Type = string.Empty;
            selection.Amount = 1;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { "power", "more power", "wrong power" });

            var magicalItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.Generate("power", "item name")).Returns(magicalItem);

            var item = await itemsGenerator.GenerateAtLevelAsync(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public async Task BUG_GenerateAtLevelAsync_Named_GetMundaneItem_WhenPowerIsMagical_ButItemTypeIsMundane()
        {
            selection.Type = "power";

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane });

            var firstItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGenerator.Setup(f => f.Generate("item name")).Returns(firstItem);

            var item = await itemsGenerator.GenerateAtLevelAsync(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(firstItem));
        }

        [Test]
        public async Task BUG_GenerateAtLevelAsync_Named_GetMagicalItem_WhenPowerIsMundane_ButItemTypeIsMagical()
        {
            selection.Type = PowerConstants.Mundane;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { "power", "more power", "wrong power" });

            var magicalItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.Generate("power", "item name")).Returns(magicalItem);

            var item = await itemsGenerator.GenerateAtLevelAsync(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public async Task BUG_GenerateAtLevelAsync_Named_GetMagicalItem_WhenPowerIsMagical_ButItemTypeIsHigherMagical()
        {
            selection.Type = "power";

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { "more power", "wrong power" });

            var magicalItem = new Item();
            mockJustInTimeFactory.Setup(f => f.Build<MagicalItemGenerator>("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator.Setup(g => g.Generate("more power", "item name")).Returns(magicalItem);

            var item = await itemsGenerator.GenerateAtLevelAsync(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public async Task GenerateAtLevelAsync_Named_GetMagicalItem()
        {
            selection.Type = "power";
            selection.Amount = 1;

            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, "item type"))
                .Returns(new[] { PowerConstants.Mundane, "power", "more power", "wrong power" });

            var magicalItem = new Item();
            mockJustInTimeFactory
                .Setup(f => f.Build<MagicalItemGenerator>("item type"))
                .Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGenerator
                .Setup(g => g.Generate(selection.Type, "item name"))
                .Returns(magicalItem);

            var item = await itemsGenerator.GenerateAtLevelAsync(1, "item type", "item name");
            Assert.That(item, Is.EqualTo(magicalItem));
        }
    }
}