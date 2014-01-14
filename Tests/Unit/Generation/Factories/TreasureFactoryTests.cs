using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class TreasureFactoryTests
    {
        private Mock<IDice> mockDice;
        private Mock<ICoinFactory> mockCoinFactory;
        private Mock<IGoodsFactory> mockGoodsFactory;
        private ITreasureFactory factory;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockCoinFactory = new Mock<ICoinFactory>();
            mockGoodsFactory = new Mock<IGoodsFactory>();
            factory = new TreasureFactory(mockDice.Object, mockCoinFactory.Object, mockGoodsFactory.Object);
        }

        [Test]
        public void TreasureFactoryReturnsTreasure()
        {
            var treasure = factory.CreateAtLevel(1);
            Assert.That(treasure, Is.Not.Null);
        }

        [Test]
        public void CoinIsSet()
        {
            var treasure = factory.CreateAtLevel(1);
            Assert.That(treasure.Coin, Is.Not.Null);
        }

        [Test]
        public void GoodsAreSet()
        {
            var treasure = factory.CreateAtLevel(1);
            Assert.That(treasure.Goods, Is.Not.Null);
        }

        [Test]
        public void ItemsAreSet()
        {
            var treasure = factory.CreateAtLevel(1);
            Assert.That(treasure.Items, Is.Not.Null);
        }
    }
}