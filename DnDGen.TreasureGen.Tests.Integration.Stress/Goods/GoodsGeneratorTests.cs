using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Goods;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Coins
{
    [TestFixture]
    public class GoodsGeneratorTests : StressTests
    {
        [Inject]
        public IGoodsGenerator GoodsGenerator { get; set; }

        [Test]
        public void StressGoods()
        {
            stressor.Stress(GenerateAndAssertGoods);
        }

        private void GenerateAndAssertGoods()
        {
            var goods = GenerateGoods();

            Assert.That(goods, Is.Not.Null);

            foreach (var good in goods)
            {
                Assert.That(good.Description, Is.Not.Empty);
                Assert.That(good.ValueInGold, Is.Positive);
            }
        }

        private IEnumerable<Good> GenerateGoods()
        {
            var level = GetNewLevel();
            return GoodsGenerator.GenerateAtLevel(level);
        }

        [Test]
        public void GoodsHappen()
        {
            var goods = stressor.GenerateOrFail(GenerateGoods, g => g.Any());
            Assert.That(goods, Is.Not.Empty);
        }

        [Test]
        public void GoodsDoNotHappen()
        {
            var goods = stressor.GenerateOrFail(GenerateGoods, g => !g.Any());
            Assert.That(goods, Is.Empty);
        }
    }
}