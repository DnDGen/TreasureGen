using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Factories
{
    [TestFixture]
    public class ItemsFactoryTests : StressTest
    {
        [Inject]
        public IItemsFactory ItemsFactory { get; set; }

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
        public void ItemsFactoryReturnsItems()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var items = ItemsFactory.CreateAtLevel(level);

                Assert.That(items, Is.Not.Null);

                foreach (var item in items)
                    Assert.That(item.Name, Is.Not.Empty);
            }

            AssertIterations();
        }
    }
}