using EventGen;
using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class MundaneItemGeneratorEventGenDecoratorTests
    {
        private MundaneItemGenerator decorator;
        private Mock<MundaneItemGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<MundaneItemGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new MundaneItemGeneratorEventGenDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEvents()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.Generate()).Returns(innerItem);

            var Items = decorator.Generate();
            Assert.That(Items, Is.EqualTo(innerItem));
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

            mockInnerGenerator.Setup(g => g.Generate(template, false)).Returns(innerItem);

            var Items = decorator.Generate(template);
            Assert.That(Items, Is.EqualTo(innerItem));
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

            mockInnerGenerator.Setup(g => g.Generate(template, true)).Returns(innerItem);

            var Items = decorator.Generate(template, true);
            Assert.That(Items, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Beginning mundane item generation from template: {template.ItemType} {template.Name}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of {innerItem.ItemType} {innerItem.Name}"), Times.Once);
        }
    }
}
