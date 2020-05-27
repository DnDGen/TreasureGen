using DnDGen.EventGen;
using DnDGen.TreasureGen.Generators.Items;
using DnDGen.TreasureGen.Items;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class ItemsGeneratorEventDecoratorTests
    {
        private IItemsGenerator decorator;
        private Mock<IItemsGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<IItemsGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new ItemsGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEvents()
        {
            var innerItems = new List<Item>();
            innerItems.Add(new Item());
            innerItems.Add(new Item());

            mockInnerGenerator.Setup(g => g.GenerateRandomAtLevel(9266)).Returns(innerItems);

            var items = decorator.GenerateRandomAtLevel(9266);
            Assert.That(items, Is.EqualTo(innerItems));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 items generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of 2 level 9266 items"), Times.Once);
        }

        [Test]
        public void LogNamedGenerationEvents()
        {
            var innerItem = new Item();
            innerItem.ItemType = "my item type";
            innerItem.Name = "my item name";

            mockInnerGenerator
                .Setup(g => g.GenerateAtLevel(9266, "item type", "item name", "trait 1", "trait 2"))
                .Returns(innerItem);

            var item = decorator.GenerateAtLevel(9266, "item type", "item name", "trait 1", "trait 2");
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 item type generation (item name)"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of my item type my item name"), Times.Once);
        }

        [Test]
        public async Task LogGenerationEventsAsync()
        {
            var innerItems = new List<Item>();
            innerItems.Add(new Item());
            innerItems.Add(new Item());

            mockInnerGenerator.Setup(g => g.GenerateRandomAtLevelAsync(9266)).ReturnsAsync(innerItems);

            var items = await decorator.GenerateRandomAtLevelAsync(9266);
            Assert.That(items, Is.EqualTo(innerItems));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 items generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of 2 level 9266 items"), Times.Once);
        }

        [Test]
        public async Task LogNamedGenerationEventsAsync()
        {
            var innerItem = new Item();
            innerItem.ItemType = "my item type";
            innerItem.Name = "my item name";

            mockInnerGenerator
                .Setup(g => g.GenerateAtLevelAsync(9266, "item type", "item name"))
                .ReturnsAsync(innerItem);

            var item = await decorator.GenerateAtLevelAsync(9266, "item type", "item name");
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 item type generation (item name)"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of my item type my item name"), Times.Once);
        }
    }
}
