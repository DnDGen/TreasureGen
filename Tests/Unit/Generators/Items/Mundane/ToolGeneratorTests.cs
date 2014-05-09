using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class ToolGeneratorTests
    {
        private IMundaneItemGenerator generator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<IDice>();
            generator = new ToolGenerator(mockPercentileSelector.Object, mockDice.Object);
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
            mockPercentileSelector.Setup(p => p.SelectFrom("Tools", 9266)).Returns("tool");
            var tool = generator.Generate();
            Assert.That(tool.Name, Is.EqualTo("tool"));
        }
    }
}