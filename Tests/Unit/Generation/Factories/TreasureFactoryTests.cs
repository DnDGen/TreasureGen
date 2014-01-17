using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Data.Items;
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
        private Mock<IItemsFactory> mockItemsFactory;
        private ITreasureFactory factory;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockCoinFactory = new Mock<ICoinFactory>();
            mockGoodsFactory = new Mock<IGoodsFactory>();
            mockItemsFactory = new Mock<IItemsFactory>();
            factory = new TreasureFactory(mockCoinFactory.Object, mockGoodsFactory.Object, mockItemsFactory.Object);
        }

        [Test]
        public void TreasureFactoryReturnsTreasure()
        {
            var treasure = factory.CreateAtLevel(1);
            Assert.That(treasure, Is.Not.Null);
        }

        [Test]
        public void CoinIsSetByCoinFactory()
        {
            var coin = new Coin();
            mockCoinFactory.Setup(f => f.CreateAtLevel(1)).Returns(coin);

            var treasure = factory.CreateAtLevel(1);
            Assert.That(treasure.Coin, Is.EqualTo(coin));
        }

        [Test]
        public void GoodsAreSetByGoodsFactory()
        {
            var goods = new List<Good>();
            mockGoodsFactory.Setup(f => f.CreateAtLevel(1)).Returns(goods);

            var treasure = factory.CreateAtLevel(1);
            Assert.That(treasure.Goods, Is.EqualTo(goods));
        }

        [Test]
        public void ItemsAreSetByItemsFactory()
        {
            var items = new List<Item>();
            mockItemsFactory.Setup(f => f.CreateAtLevel(1)).Returns(items);

            var treasure = factory.CreateAtLevel(1);
            Assert.That(treasure.Items, Is.EqualTo(items));
        }
    }
}