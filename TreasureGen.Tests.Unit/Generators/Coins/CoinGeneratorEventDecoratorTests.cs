using EventGen;
using Moq;
using NUnit.Framework;
using TreasureGen.Coins;
using TreasureGen.Generators.Coins;

namespace TreasureGen.Tests.Unit.Generators.Coins
{
    [TestFixture]
    public class CoinGeneratorEventDecoratorTests
    {
        private ICoinGenerator decorator;
        private Mock<ICoinGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<ICoinGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new CoinGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEvents()
        {
            var innerCoin = new Coin();
            innerCoin.Currency = "currency";
            innerCoin.Quantity = 90210;
            mockInnerGenerator.Setup(g => g.GenerateAtLevel(9266)).Returns(innerCoin);

            var coin = decorator.GenerateAtLevel(9266);
            Assert.That(coin, Is.EqualTo(innerCoin));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 coin generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of level 9266 coin: 90210 currency"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsOfNoCoin()
        {
            var innerCoin = new Coin();
            mockInnerGenerator.Setup(g => g.GenerateAtLevel(9266)).Returns(innerCoin);

            var coin = decorator.GenerateAtLevel(9266);
            Assert.That(coin, Is.EqualTo(innerCoin));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 coin generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of level 9266 coin: 0 "), Times.Once);
        }
    }
}
