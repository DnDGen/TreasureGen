﻿using DnDGen.TreasureGen.Goods;
using Ninject;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Coins
{
    [TestFixture]
    public class GoodsGeneratorTests : StressTests
    {
        private IGoodsGenerator goodsGenerator;

        [SetUp]
        public void Setup()
        {
            goodsGenerator = GetNewInstanceOf<IGoodsGenerator>();
        }

        [Test]
        public void StressGoods()
        {
            stressor.Stress(GenerateAndAssertGoods);
        }

        private void GenerateAndAssertGoods()
        {
            var level = GetNewLevel();
            var goods = goodsGenerator.GenerateAtLevel(level);

            Assert.That(goods, Is.Not.Null);

            foreach (var good in goods)
            {
                Assert.That(good.Description, Is.Not.Empty);
                Assert.That(good.ValueInGold, Is.Positive);
            }
        }

        [Test]
        public async Task StressGoodsAsync()
        {
            await stressor.StressAsync(GenerateAndAssertGoodsAsync);
        }

        private async Task GenerateAndAssertGoodsAsync()
        {
            var level = GetNewLevel();
            var goods = await goodsGenerator.GenerateAtLevelAsync(level);

            Assert.That(goods, Is.Not.Null);

            foreach (var good in goods)
            {
                Assert.That(good.Description, Is.Not.Empty);
                Assert.That(good.ValueInGold, Is.Positive);
            }
        }
    }
}