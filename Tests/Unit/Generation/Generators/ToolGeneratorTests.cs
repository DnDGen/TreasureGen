using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class ToolGeneratorTests
    {
        private IToolGenerator generator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            generator = new ToolGenerator(mockPercentileResultProvider.Object);
        }

        [Test]
        public void ToolGeneratorReturnsTool()
        {
            var tool = generator.Generate();
            Assert.That(tool, Is.Not.Null);
        }

        [Test]
        public void ToolGeneratorSetsToolNameByPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("Tools")).Returns("tool");
            var tool = generator.Generate();
            Assert.That(tool.Name, Is.EqualTo("tool"));
        }
    }
}