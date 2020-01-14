using DnDGen.EventGen;
using DnDGen.TreasureGen.Generators.Items;
using DnDGen.TreasureGen.Items;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

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

            mockInnerGenerator.Setup(g => g.GenerateAtLevel(9266)).Returns(innerItems);

            var Items = decorator.GenerateAtLevel(9266);
            Assert.That(Items, Is.EqualTo(innerItems));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 items generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of 2 level 9266 items"), Times.Once);
        }
    }
}
