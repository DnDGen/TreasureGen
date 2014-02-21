using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests : StressTest
    {
        [Inject]
        public IAlchemicalItemGenerator AlchemicalItemGenerator { get; set; }

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
        public void StressedAlchemicalItemGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var item = AlchemicalItemGenerator.Generate();

                Assert.That(item.Name, Is.Not.Empty);
                Assert.That(item.Quantity, Is.GreaterThan(0));
                Assert.That(item.Magic, Is.Empty);
                Assert.That(item.Attributes, Is.Empty);
                Assert.That(item.Traits, Is.Empty);
            }

            AssertIterations();
        }
    }
}