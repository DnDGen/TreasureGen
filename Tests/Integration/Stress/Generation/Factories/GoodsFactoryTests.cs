using System;
using System.Linq;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Factories
{
    [TestFixture]
    public class GoodsFactoryTests : StressTest
    {
        [Inject]
        public IGoodsFactory GoodsFactory { get; set; }

        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void GoodsFactoryReturnsGoods()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var goods = GoodsFactory.CreateAtLevel(level);

                Assert.That(goods, Is.Not.Null);
            }

            AssertIterations();
        }

        [Test]
        public void GoodsFactoryReturnsGoodsWithGoods()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var goods = GoodsFactory.CreateAtLevel(level);

                if (goods.Any())
                {
                    Assert.That(goods.Any(g => String.IsNullOrEmpty(g.Description)), Is.False);
                    Assert.That(goods.All(g => g.ValueInGold > 0), Is.True);
                }
            }

            AssertIterations();
        }
    }
}