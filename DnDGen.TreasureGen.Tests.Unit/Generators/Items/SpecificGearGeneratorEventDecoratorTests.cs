using DnDGen.EventGen;
using DnDGen.TreasureGen.Generators.Items;
using DnDGen.TreasureGen.Items;
using Moq;
using NUnit.Framework;
using System;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
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

        [TestCase(false)]
        [TestCase(true)]
        public void DoNotLogEventsWhenCheckingIfCanBeSpecificGear(bool shouldBeSpecific)
        {
            mockInnerGenerator.Setup(g => g.CanBeSpecific("power", "gear type", "item name")).Returns(shouldBeSpecific);

            var isSpecific = decorator.CanBeSpecific("power", "gear type", "item name");
            Assert.That(isSpecific, Is.EqualTo(shouldBeSpecific));
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

        [Test]
        public void DoNotLogGenerationEventsForRandomName()
        {
            mockInnerGenerator.Setup(g => g.GenerateRandomNameFrom("power", "gear type")).Returns("random name");

            var name = decorator.GenerateRandomNameFrom("power", "gear type");
            Assert.That(name, Is.EqualTo("random name"));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void DoNotLogGenerationEventsForSpecificGearPrototype()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.GeneratePrototypeFrom("power", "gear type", "item name")).Returns(innerItem);

            var item = decorator.GeneratePrototypeFrom("power", "gear type", "item name");
            Assert.That(item, Is.EqualTo(innerItem));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void DoNotLogGenerationEventsForNameFrom()
        {
            mockInnerGenerator.Setup(g => g.GenerateNameFrom("power", "gear type", "item name")).Returns("specific name");

            var name = decorator.GenerateNameFrom("power", "gear type", "item name");
            Assert.That(name, Is.EqualTo("specific name"));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void DoNotLogEventsWhenCheckingIfSpecificGear_Template(bool shouldBeSpecific)
        {
            var template = new Item();
            template.Name = Guid.NewGuid().ToString();
            template.ItemType = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.IsSpecific(template)).Returns(shouldBeSpecific);

            var isSpecific = decorator.IsSpecific(template);
            Assert.That(isSpecific, Is.EqualTo(shouldBeSpecific));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void DoNotLogEventsWhenCheckingIfSpecificGear_Name(bool shouldBeSpecific)
        {
            mockInnerGenerator.Setup(g => g.IsSpecific("gear type", "item name")).Returns(shouldBeSpecific);

            var isSpecific = decorator.IsSpecific("gear type", "item name");
            Assert.That(isSpecific, Is.EqualTo(shouldBeSpecific));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void DoNotLogEventsWhenCheckingIfSpecificGear_NameAndPower(bool shouldBeSpecific)
        {
            mockInnerGenerator.Setup(g => g.IsSpecific("power", "gear type", "item name")).Returns(shouldBeSpecific);

            var isSpecific = decorator.IsSpecific("power", "gear type", "item name");
            Assert.That(isSpecific, Is.EqualTo(shouldBeSpecific));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
