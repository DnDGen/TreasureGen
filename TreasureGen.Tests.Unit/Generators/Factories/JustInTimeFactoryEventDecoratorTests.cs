using EventGen;
using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Generators.Factories;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Factories
{
    [TestFixture]
    public class JustInTimeFactoryEventDecoratorTests
    {
        private JustInTimeFactory decorator;
        private Mock<JustInTimeFactory> mockInnerFactory;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerFactory = new Mock<JustInTimeFactory>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new JustInTimeFactoryEventDecorator(mockInnerFactory.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogEventsForBuild()
        {
            var mockMagicalItemGenerator = new Mock<MagicalItemGenerator>();
            mockInnerFactory.Setup(f => f.Build<MagicalItemGenerator>()).Returns(mockMagicalItemGenerator.Object);

            var generator = decorator.Build<MagicalItemGenerator>();
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockMagicalItemGenerator.Object));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Instantiating something just in time"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Finished instantiating something just in time"), Times.Once);
        }

        [Test]
        public void LogEventsForBuildWithName()
        {
            var mockMagicalItemGenerator = new Mock<MagicalItemGenerator>();
            mockInnerFactory.Setup(f => f.Build<MagicalItemGenerator>("name")).Returns(mockMagicalItemGenerator.Object);

            var generator = decorator.Build<MagicalItemGenerator>("name");
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockMagicalItemGenerator.Object));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Instantiating something named name just in time"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Finished instantiating something named name just in time"), Times.Once);
        }
    }
}
