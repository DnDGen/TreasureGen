using DnDGen.EventGen;
using DnDGen.TreasureGen.Generators;
using Moq;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit.Generators
{
    [TestFixture]
    public class TreasureGeneratorEventDecoratorTests
    {
        private ITreasureGenerator decorator;
        private Mock<ITreasureGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<ITreasureGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new TreasureGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEvents()
        {
            var innerTreasure = new Treasure();

            mockInnerGenerator.Setup(g => g.GenerateAtLevel(9266)).Returns(innerTreasure);

            var Treasure = decorator.GenerateAtLevel(9266);
            Assert.That(Treasure, Is.EqualTo(innerTreasure));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 treasure generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of level 9266 treasure"), Times.Once);
        }
    }
}
