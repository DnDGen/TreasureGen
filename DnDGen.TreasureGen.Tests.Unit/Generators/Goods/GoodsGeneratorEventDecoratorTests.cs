using DnDGen.EventGen;
using DnDGen.TreasureGen.Generators.Goods;
using DnDGen.TreasureGen.Goods;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Goods
{
    [TestFixture]
    public class GoodsGeneratorEventDecoratorTests
    {
        private IGoodsGenerator decorator;
        private Mock<IGoodsGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<IGoodsGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new GoodsGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEvents()
        {
            var innerGoods = new List<Good>();
            innerGoods.Add(new Good());
            innerGoods.Add(new Good());

            mockInnerGenerator.Setup(g => g.GenerateAtLevel(9266)).Returns(innerGoods);

            var goods = decorator.GenerateAtLevel(9266);
            Assert.That(goods, Is.EqualTo(innerGoods));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 goods generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of 2 level 9266 goods"), Times.Once);
        }

        [Test]
        public async Task LogGenerationEventsAsync()
        {
            var innerGoods = new List<Good>();
            innerGoods.Add(new Good());
            innerGoods.Add(new Good());

            mockInnerGenerator.Setup(g => g.GenerateAtLevelAsync(9266)).ReturnsAsync(innerGoods);

            var goods = await decorator.GenerateAtLevelAsync(9266);
            Assert.That(goods, Is.EqualTo(innerGoods));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Beginning level 9266 goods generation"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Completed generation of 2 level 9266 goods"), Times.Once);
        }
    }
}
