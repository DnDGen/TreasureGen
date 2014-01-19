using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests : DurationTest
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
        public void AlchemicalItemGeneratorDuration()
        {
            AlchemicalItemGenerator.Generate();
            AssertDuration();
        }
    }
}