using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class ToolGeneratorTests : StressTest
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
        public void ToolGeneratorReturnsTool()
        {
            while (TestShouldKeepRunning())
            {
                var tool = ToolGenerator.Generate();

                Assert.That(tool, Is.Not.Null);
                Assert.That(tool.Name, Is.Not.Empty);
            }

            AssertIterations();
        }
    }
}