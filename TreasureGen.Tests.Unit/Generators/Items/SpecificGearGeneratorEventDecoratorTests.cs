using EventGen;
using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Generators.Items;
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
        public void DoNotLogGenerationEventsForSpecificGearPrototype()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.GenerateRandomPrototypeFrom("power", "gear type")).Returns(innerItem);

            var item = decorator.GenerateRandomPrototypeFrom("power", "gear type");
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void LogGenerationEventsForSpecificGearFromTemplate()
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
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generating specific gear from template: {template.ItemType} {template.Name}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}"), Times.Once);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void DoNotLogEventsWhenCheckingIfSpecificGear(bool shouldBeSpecific)
        {
            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            template.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.IsSpecific(template)).Returns(shouldBeSpecific);

            var isSpecific = decorator.IsSpecific(template);
            Assert.That(isSpecific, Is.EqualTo(shouldBeSpecific));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
