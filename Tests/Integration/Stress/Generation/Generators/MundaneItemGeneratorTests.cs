using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class MundaneItemGeneratorTests : StressTest
    {
        [Inject]
        public IMundaneItemGenerator MundaneItemGenerator { get; set; }

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
        public void StressedMundaneItemGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var item = MundaneItemGenerator.Generate();
                Assert.That(item.Name, Is.Not.Empty);
                Assert.That(item.Traits, Is.Not.Null);
                Assert.That(item.Attributes, Is.Not.Null);
                Assert.That(item.Quantity, Is.GreaterThan(0));
                Assert.That(item.Magic, Is.Empty);
            }

            AssertIterations();
        }
    }
}