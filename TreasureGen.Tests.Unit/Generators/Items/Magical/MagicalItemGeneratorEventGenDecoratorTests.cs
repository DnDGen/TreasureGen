using EventGen;
using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class MagicalItemGeneratorEventGenDecoratorTests
    {
        private MagicalItemGenerator decorator;
        private Mock<MagicalItemGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<MagicalItemGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new MagicalItemGeneratorEventGenDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEvents()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.GenerateAtPower("power")).Returns(innerItem);

            var item = decorator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning power magical item generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of power {innerItem.ItemType} {innerItem.Name}"), Times.Once);
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

            var item = decorator.Generate(template);
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Beginning magical item generation from template: {template.ItemType} {template.Name}"), Times.Once);
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
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Beginning magical item generation from template: {template.ItemType} {template.Name}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of {innerItem.ItemType} {innerItem.Name}"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsForSubset()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFromSubset("power", subset)).Returns(innerItem);

            var item = decorator.GenerateFromSubset("power", subset);
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Beginning power magical item generation from [{string.Join(", ", subset)}]"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of power {innerItem.ItemType} {innerItem.Name}"), Times.Once);
        }
    }
}
