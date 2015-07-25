using TreasureGen.Common.Items;
using TreasureGen.Generators.Interfaces.Items.Mundane;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Tables.Interfaces;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class ToolGeneratorTests
    {
        private IMundaneItemGenerator generator;
        private Mock<IPercentileSelector> mockPercentileSelector;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            generator = new ToolGenerator(mockPercentileSelector.Object);
        }

        [Test]
        public void GenerateTool()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Tools)).Returns("tool");

            var tool = generator.Generate();
            Assert.That(tool.Name, Is.EqualTo("tool"));
            Assert.That(tool.Attributes, Is.Empty);
            Assert.That(tool.ItemType, Is.EqualTo(ItemTypeConstants.Tool));
            Assert.That(tool.IsMagical, Is.False);
            Assert.That(tool.Contents, Is.Empty);
            Assert.That(tool.Quantity, Is.EqualTo(1));
            Assert.That(tool.Traits, Is.Empty);
        }
    }
}