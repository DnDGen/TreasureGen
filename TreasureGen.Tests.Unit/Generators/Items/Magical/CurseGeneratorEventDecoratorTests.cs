using EventGen;
using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class CurseGeneratorEventDecoratorTests
    {
        private ICurseGenerator decorator;
        private Mock<ICurseGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<ICurseGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();

            decorator = new CurseGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEventsForSpecificCursedItem()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.Generate()).Returns(innerItem);

            var item = decorator.Generate();
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Generating a specific cursed item"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsForNoSpecificCursedItem()
        {
            Item innerItem = null;
            mockInnerGenerator.Setup(g => g.Generate()).Returns(innerItem);

            var item = decorator.Generate();
            Assert.That(item, Is.Null);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Generating a specific cursed item"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"No specific cursed item was generated"), Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void LogGenerationEventsForSpecificCursedItemFromTemplate(bool allowDecoration)
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            template.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, allowDecoration)).Returns(innerItem);

            var item = decorator.GenerateFrom(template, allowDecoration);
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generating a specific cursed item from template: {template.ItemType} {template.Name}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}"), Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void LogGenerationEventsForNoSpecificCursedItemFromTemplate(bool allowDecoration)
        {
            Item innerItem = null;

            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            template.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, allowDecoration)).Returns(innerItem);

            var item = decorator.GenerateFrom(template, allowDecoration);
            Assert.That(item, Is.Null);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generating a specific cursed item from template: {template.ItemType} {template.Name}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"No specific cursed item was generated"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsForSpecificCursedItemFromSubset()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom(subset)).Returns(innerItem);

            var item = decorator.GenerateFrom(subset);
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generating a specific cursed item from [{string.Join(", ", subset)}]"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsForNoSpecificCursedItemFromSubset()
        {
            Item innerItem = null;

            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom(subset)).Returns(innerItem);

            var item = decorator.GenerateFrom(subset);
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generating a specific cursed item from [{string.Join(", ", subset)}]"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"No specific cursed item was generated"), Times.Once);
        }

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void LogEventsWhenCheckingForCurse(bool isMagical, bool hasCurse)
        {
            mockInnerGenerator.Setup(g => g.HasCurse(isMagical)).Returns(hasCurse);

            var isCursed = decorator.HasCurse(isMagical);
            Assert.That(isCursed, Is.EqualTo(hasCurse));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Determining if item is cursed"), Times.Once);

            if (hasCurse)
                mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Item is cursed"), Times.Once);
            else
                mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Item is not cursed"), Times.Once);
        }

        [Test]
        public void LogEventsWhenGeneratingCurse()
        {
            mockInnerGenerator.Setup(g => g.GenerateCurse()).Returns("terrible curse of terribleness");

            var curse = decorator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("terrible curse of terribleness"));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Generating a curse"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generated a curse of terrible curse of terribleness"), Times.Once);
        }

        [Test]
        public void LogEventsWhenCheckingForSpecificCursedItem()
        {
            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            mockInnerGenerator.Setup(g => g.IsSpecificCursedItem(template)).Returns(true);

            var isCursed = decorator.IsSpecificCursedItem(template);
            Assert.That(isCursed, Is.True);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Determining if {template.Name} is a specific cursed item"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"{template.Name} is a specific cursed item"), Times.Once);
        }

        [Test]
        public void LogEventsWhenCheckingForNotSpecificCursedItem()
        {
            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            mockInnerGenerator.Setup(g => g.IsSpecificCursedItem(template)).Returns(false);

            var isCursed = decorator.IsSpecificCursedItem(template);
            Assert.That(isCursed, Is.False);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Determining if {template.Name} is a specific cursed item"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"{template.Name} is not a specific cursed item"), Times.Once);
        }
    }
}
