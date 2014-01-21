using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class PowerItemGeneratorTests : StressTest
    {
        [Inject]
        public IPowerItemGenerator PowerItemGenerator { get; set; }

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
        public void PowerItemGeneratorReturnsItem()
        {
            while (TestShouldKeepRunning())
            {
                var power = GetNewPower();
                var item = PowerItemGenerator.GenerateAtPower(power);

                Assert.That(item, Is.Not.Null);
                Assert.That(item.Name, Is.Not.Empty);
            }

            AssertIterations();
        }
    }
}