using EventGen;
using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneItemGeneratorEventDecoratorTests
    {
        private MundaneItemGenerator decorator;
        private Mock<MundaneItemGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<MundaneItemGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new MundaneItemGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEvents()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.Generate()).Returns(innerItem);

            var item = decorator.Generate();
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning mundane item generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of {innerItem.ItemType} {innerItem.Name}"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsForTemplate()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            template.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, false)).Returns(innerItem);

            var item = decorator.GenerateFrom(template);
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Beginning mundane item generation from template: {template.ItemType} {template.Name}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of {innerItem.ItemType} {innerItem.Name}"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsForTemplateWithRandomDecoration()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            template.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, true)).Returns(innerItem);

            var item = decorator.GenerateFrom(template, true);
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Beginning mundane item generation from template: {template.ItemType} {template.Name}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of {innerItem.ItemType} {innerItem.Name}"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsFromSubset()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom(subset)).Returns(innerItem);

            var item = decorator.GenerateFrom(subset);
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Beginning mundane item generation from [{string.Join(", ", subset)}]"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of {innerItem.ItemType} {innerItem.Name}"), Times.Once);
        }
    }
}
