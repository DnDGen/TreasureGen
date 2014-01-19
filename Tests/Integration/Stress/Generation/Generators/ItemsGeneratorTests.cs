using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class ItemsGeneratorTests : StressTest
    {
        [Inject]
        public IItemsGenerator ItemsGenerator { get; set; }

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
        public void ItemsGeneratorReturnsItems()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var items = ItemsGenerator.GenerateAtLevel(level);

                Assert.That(items, Is.Not.Null);

                foreach (var item in items)
                    Assert.That(item.Name, Is.Not.Empty);
            }

            AssertIterations();
        }
    }
}