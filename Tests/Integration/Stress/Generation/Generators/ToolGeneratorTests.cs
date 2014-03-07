using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class ToolGeneratorTests : StressTests
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
        public void StressedToolGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var tool = ToolGenerator.Generate();

                Assert.That(tool.Name, Is.Not.Empty);
                Assert.That(tool.Attributes, Is.Empty);
                Assert.That(tool.Magic, Is.Empty);
                Assert.That(tool.Quantity, Is.EqualTo(1));
                Assert.That(tool.Traits, Is.Empty);
            }

            AssertIterations();
        }
    }
}