using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class TreasureGeneratorTests
    {
        private Mock<IDice> mockDice;
        private Mock<ICoinGenerator> mockCoinGenerator;
        private Mock<IGoodsGenerator> mockGoodsGenerator;
        private Mock<IItemsGenerator> mockItemsGenerator;
        private ITreasureGenerator generator;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockCoinGenerator = new Mock<ICoinGenerator>();
            mockGoodsGenerator = new Mock<IGoodsGenerator>();
            mockItemsGenerator = new Mock<IItemsGenerator>();
            generator = new TreasureGenerator(mockCoinGenerator.Object, mockGoodsGenerator.Object, mockItemsGenerator.Object);
        }

        [Test]
        public void TreasureGeneratorReturnsTreasure()
        {
            var treasure = generator.GenerateAtLevel(1);
            Assert.That(treasure, Is.Not.Null);
        }

        [Test]
        public void CoinIsSetByCoinGenerator()
        {
            var coin = new Coin();
            mockCoinGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(coin);

            var treasure = generator.GenerateAtLevel(1);
            Assert.That(treasure.Coin, Is.EqualTo(coin));
        }

        [Test]
        public void GoodsAreSetByGoodsGenerator()
        {
            var goods = new List<Good>();
            mockGoodsGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(goods);

            var treasure = generator.GenerateAtLevel(1);
            Assert.That(treasure.Goods, Is.EqualTo(goods));
        }

        [Test]
        public void ItemsAreSetByItemsGenerator()
        {
            var items = new List<Item>();
            mockItemsGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(items);

            var treasure = generator.GenerateAtLevel(1);
            Assert.That(treasure.Items, Is.EqualTo(items));
        }
    }
}