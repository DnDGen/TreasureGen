using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class ItemGeneratorTests : StressTest
    {
        [Inject]
        public IItemGenerator ItemGenerator { get; set; }

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
        public void StressedItemGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var power = GetNewPower(true);
                var item = ItemGenerator.GenerateAtPower(power);

                Assert.That(item.Name, Is.Not.Empty);
            }

            AssertIterations();
        }
    }
}