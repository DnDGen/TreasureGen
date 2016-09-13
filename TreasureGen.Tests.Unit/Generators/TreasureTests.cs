using NUnit.Framework;
using System.Linq;
using TreasureGen.Goods;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Generators
{
    [TestFixture]
    public class TreasureTests
    {
        private Treasure treasure;

        [SetUp]
        public void Setup()
        {
            treasure = new Treasure();
        }

        [Test]
        public void TreasureInitialized()
        {
            Assert.That(treasure.Coin, Is.Not.Null);
            Assert.That(treasure.Goods, Is.Empty);
            Assert.That(treasure.Items, Is.Empty);
            Assert.That(treasure.IsAny, Is.False);
        }

        [Test]
        public void IsTreasureIfCoinQuantity()
        {
            treasure.Coin.Quantity = 1;
            treasure.Coin.Currency = "currency";
            Assert.That(treasure.IsAny, Is.True);
        }

        [Test]
        public void IsTreasureIfGoods()
        {
            treasure.Goods = new[] { new Good() };
            Assert.That(treasure.IsAny, Is.True);
        }

        [Test]
        public void IsTreasureIfItems()
        {
            treasure.Items = new[] { new Item() };
            Assert.That(treasure.IsAny, Is.True);
        }

        [Test]
        public void IsNoTreasureIfNoCoinOrGoodsOrItems()
        {
            treasure.Coin.Quantity = 1;
            treasure.Coin.Currency = "currency";
            treasure.Goods = new[] { new Good() };
            treasure.Items = new[] { new Item() };

            Assert.That(treasure.IsAny, Is.True);

            treasure.Coin.Quantity = 0;
            treasure.Goods = Enumerable.Empty<Good>();
            treasure.Items = Enumerable.Empty<Item>();

            Assert.That(treasure.IsAny, Is.False);
        }
    }
}