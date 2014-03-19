using D20Dice;
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
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockDice = new Mock<IDice>();
            generator = new ToolGenerator(mockPercentileResultProvider.Object, mockDice.Object);
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
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Tools", 9266)).Returns("tool");
            var tool = generator.Generate();
            Assert.That(tool.Name, Is.EqualTo("tool"));
        }
    }
}