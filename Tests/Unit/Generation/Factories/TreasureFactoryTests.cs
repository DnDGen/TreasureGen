using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Factories
{
    [TestFixture]
    public class TreasureFactoryTests
    {
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
        }

        [Test]
        public void TreasureFactoryReturnsTreasure()
        {
            var treasure = TreasureFactory.CreateUsing(mockDice.Object, 1);
            Assert.That(treasure, Is.Not.Null);
        }

        [Test]
        public void CoinIsSet()
        {
            var treasure = TreasureFactory.CreateUsing(mockDice.Object, 1);
            Assert.That(treasure.Coin, Is.Not.Null);
        }

        [Test]
        public void GoodsAreSet()
        {
            var treasure = TreasureFactory.CreateUsing(mockDice.Object, 1);
            Assert.That(treasure.Goods, Is.Not.Null);
        }

        [Test]
        public void ItemsAreSet()
        {
            var treasure = TreasureFactory.CreateUsing(mockDice.Object, 1);
            Assert.That(treasure.Items, Is.Not.Null);
        }
    }
}