using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common.Goods;
using TreasureGen.Generators.Goods;

namespace TreasureGen.Tests.Integration.Stress.Coins
{
    [TestFixture]
    public class GoodsGeneratorTests : StressTests
    {
        [Inject]
        public IGoodsGenerator GoodsGenerator { get; set; }

        [TestCase("Goods generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
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
            IEnumerable<Good> goods;

            do goods = GenerateGoods();
            while (TestShouldKeepRunning() && !goods.Any());

            Assert.That(goods, Is.Not.Empty);
        }

        [Test]
        public void GoodsDoNotHappen()
        {
            IEnumerable<Good> goods;

            do goods = GenerateGoods();
            while (TestShouldKeepRunning() && goods.Any());

            Assert.That(goods, Is.Empty);
        }
    }
}