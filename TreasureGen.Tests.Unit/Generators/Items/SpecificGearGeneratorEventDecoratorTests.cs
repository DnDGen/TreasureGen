using EventGen;
using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpecificGearGeneratorEventDecoratorTests
    {
        private ISpecificGearGenerator decorator;
        private Mock<ISpecificGearGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<ISpecificGearGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();

            decorator = new SpecificGearGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEventsForSpecificGear()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.GenerateFrom("power", "gear type")).Returns(innerItem);

            var item = decorator.GenerateFrom("power", "gear type");
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning power specific gear type generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsForSpecificCursedItemFromTemplate()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            template.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template)).Returns(innerItem);

            var item = decorator.GenerateFrom(template);
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Beginning specific gear generation from template: {template.ItemType} {template.Name}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}"), Times.Once);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void LogEventsWhenCheckingIfSpecificGear(bool shouldBeSpecific)
        {
            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            template.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.TemplateIsSpecific(template)).Returns(shouldBeSpecific);

            var isSpecific = decorator.TemplateIsSpecific(template);
            Assert.That(isSpecific, Is.EqualTo(shouldBeSpecific));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Determining if {template.Name} is a specific gear"), Times.Once);

            if (shouldBeSpecific)
                mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"{template.Name} is a specific gear"), Times.Once);
            else
                mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"{template.Name} is not a specific gear"), Times.Once);
        }
    }
}
