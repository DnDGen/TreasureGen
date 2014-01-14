using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Factories
{
    [TestFixture]
    public class TreasureFactoryTests : StressTest
    {
        [Inject]
        public ITreasureFactory TreasureFactory { get; set; }

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
        public void TreasureFactoryReturnsTreasure()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var treasure = TreasureFactory.CreateAtLevel(level);

                Assert.That(treasure, Is.Not.Null);
            }

            AssertIterations();
        }

        [Test]
        public void TreasureFactoryReturnsTreasureWithCoin()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var treasure = TreasureFactory.CreateAtLevel(level);

                Assert.That(treasure.Coin, Is.Not.Null);
            }

            AssertIterations();
        }

        [Test]
        public void TreasureFactoryReturnsTreasureWithGoods()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var treasure = TreasureFactory.CreateAtLevel(level);

                Assert.That(treasure.Goods, Is.Not.Null);
            }

            AssertIterations();
        }

        [Test]
        public void TreasureFactoryReturnsTreasureWithItems()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var treasure = TreasureFactory.CreateAtLevel(level);

                Assert.That(treasure.Items, Is.Not.Null);
            }

            AssertIterations();
        }
    }
}