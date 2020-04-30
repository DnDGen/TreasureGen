using DnDGen.TreasureGen.Coins;
using DnDGen.TreasureGen.Generators;
using DnDGen.TreasureGen.Goods;
using DnDGen.TreasureGen.Items;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Tests.Unit.Generators
{
    [TestFixture]
    public class TreasureGeneratorTests
    {
        private Mock<ICoinGenerator> mockCoinGenerator;
        private Mock<IGoodsGenerator> mockGoodsGenerator;
        private Mock<IItemsGenerator> mockItemsGenerator;
        private ITreasureGenerator generator;

        [SetUp]
        public void Setup()
        {
            mockCoinGenerator = new Mock<ICoinGenerator>();
            mockGoodsGenerator = new Mock<IGoodsGenerator>();
            mockItemsGenerator = new Mock<IItemsGenerator>();
            generator = new TreasureGenerator(mockCoinGenerator.Object, mockGoodsGenerator.Object, mockItemsGenerator.Object);
        }

        [Test]
        public void Generate_ReturnTreasure()
        {
            var treasure = generator.GenerateAtLevel(1);
            Assert.That(treasure, Is.Not.Null);
        }

        [Test]
        public void Generate_CoinIsSetByCoinGenerator()
        {
            var coin = new Coin();
            coin.Currency = "currency";
            coin.Quantity = 9266;

            mockCoinGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(coin);

            var treasure = generator.GenerateAtLevel(1);
            Assert.That(treasure.Coin, Is.EqualTo(coin));
        }

        [Test]
        public void Generate_GoodsAreSetByGoodsGenerator()
        {
            var goods = new List<Good>
            {
                new Good { Description = "description 1", ValueInGold = 9266 },
                new Good { Description = "description 2", ValueInGold = 90210 },
            };
            mockGoodsGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(goods);

            var treasure = generator.GenerateAtLevel(1);
            Assert.That(treasure.Goods, Is.EqualTo(goods));
        }

        [Test]
        public void Generate_ItemsAreSetByItemsGenerator()
        {
            var items = new List<Item>
            {
                new Item { Name = "item 1" },
                new Item { Name = "item 2" },
            };
            mockItemsGenerator.Setup(f => f.GenerateRandomAtLevel(1)).Returns(items);

            var treasure = generator.GenerateAtLevel(1);
            Assert.That(treasure.Items, Is.EqualTo(items));
        }

        [Test]
        public void Generate_All()
        {
            var coin = new Coin();
            coin.Currency = "currency";
            coin.Quantity = 9266;
            mockCoinGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(coin);

            var goods = new List<Good>
            {
                new Good { Description = "description 1", ValueInGold = 9266 },
                new Good { Description = "description 2", ValueInGold = 90210 },
            };
            mockGoodsGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(goods);

            var items = new List<Item>
            {
                new Item { Name = "item 1" },
                new Item { Name = "item 2" },
            };
            mockItemsGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(items);

            var treasure = generator.GenerateAtLevel(1);
            Assert.That(treasure.Coin, Is.EqualTo(coin));
            Assert.That(treasure.Goods, Is.EqualTo(goods));
            Assert.That(treasure.Items, Is.EqualTo(items));
        }

        [Test]
        public async Task GenerateAsync_ReturnTreasure()
        {
            var treasure = await generator.GenerateAtLevelAsync(1);
            Assert.That(treasure, Is.Not.Null);
        }

        [Test]
        public async Task GenerateAsync_CoinIsSetByCoinGenerator()
        {
            var coin = new Coin();
            coin.Currency = "currency";
            coin.Quantity = 9266;

            mockCoinGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(coin);

            var treasure = await generator.GenerateAtLevelAsync(1);
            Assert.That(treasure.Coin, Is.EqualTo(coin));
        }

        [Test]
        public async Task GenerateAsync_GoodsAreSetByGoodsGenerator()
        {
            var goods = new List<Good>
            {
                new Good { Description = "description 1", ValueInGold = 9266 },
                new Good { Description = "description 2", ValueInGold = 90210 },
            };
            mockGoodsGenerator.Setup(f => f.GenerateAtLevelAsync(1)).ReturnsAsync(goods);

            var treasure = await generator.GenerateAtLevelAsync(1);
            Assert.That(treasure.Goods, Is.EqualTo(goods));
        }

        [Test]
        public async Task GenerateAsync_ItemsAreSetByItemsGenerator()
        {
            var items = new List<Item>
            {
                new Item { Name = "item 1" },
                new Item { Name = "item 2" },
            };
            mockItemsGenerator.Setup(f => f.GenerateAtLevelAsync(1)).ReturnsAsync(items);

            var treasure = await generator.GenerateAtLevelAsync(1);
            Assert.That(treasure.Items, Is.EqualTo(items));
        }

        [Test]
        public async Task GenerateAsync_All()
        {
            var coin = new Coin();
            coin.Currency = "currency";
            coin.Quantity = 9266;
            mockCoinGenerator.Setup(f => f.GenerateAtLevel(1)).Returns(coin);

            var goods = new List<Good>
            {
                new Good { Description = "description 1", ValueInGold = 9266 },
                new Good { Description = "description 2", ValueInGold = 90210 },
            };
            mockGoodsGenerator.Setup(f => f.GenerateAtLevelAsync(1)).ReturnsAsync(goods);

            var items = new List<Item>
            {
                new Item { Name = "item 1" },
                new Item { Name = "item 2" },
            };
            mockItemsGenerator.Setup(f => f.GenerateAtLevelAsync(1)).ReturnsAsync(items);

            var treasure = await generator.GenerateAtLevelAsync(1);
            Assert.That(treasure.Coin, Is.EqualTo(coin));
            Assert.That(treasure.Goods, Is.EqualTo(goods));
            Assert.That(treasure.Items, Is.EqualTo(items));
        }
    }
}