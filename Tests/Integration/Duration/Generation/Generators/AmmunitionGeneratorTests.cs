using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class AmmunitionGeneratorTests : DurationTest
    {
        [Inject]
        public IAmmunitionGenerator AmmunitionGenerator { get; set; }

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
        public void AmmunitionGeneratorDuration()
        {
            AmmunitionGenerator.Generate();
            AssertDuration();
        }
    }
}