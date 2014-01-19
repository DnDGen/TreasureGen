using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class ToolGeneratorTests : DurationTest
    {
        [Inject]
        public IToolGenerator ToolGenerator { get; set; }

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
        public void ToolGeneratorDuration()
        {
            ToolGenerator.Generate();
            AssertDuration();
        }
    }
}