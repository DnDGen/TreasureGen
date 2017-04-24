using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class ToolGeneratorTests
    {
        private MundaneItemGenerator toolGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private ItemVerifier itemVerifier;
        private Generator generator;
        private Mock<ICollectionsSelector> mockCollectionsSelector;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            generator = new ConfigurableIterativeGenerator(3);
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            toolGenerator = new ToolGenerator(mockPercentileSelector.Object, mockCollectionsSelector.Object, generator);
            itemVerifier = new ItemVerifier();
        }

        [Test]
        public void GenerateTool()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Tools)).Returns("tool");

            var tool = toolGenerator.Generate();
            Assert.That(tool.Name, Is.EqualTo("tool"));
            Assert.That(tool.BaseNames.Single(), Is.EqualTo("tool"));
            Assert.That(tool.Attributes, Is.Empty);
            Assert.That(tool.ItemType, Is.EqualTo(ItemTypeConstants.Tool));
            Assert.That(tool.IsMagical, Is.False);
            Assert.That(tool.Contents, Is.Empty);
            Assert.That(tool.Quantity, Is.EqualTo(1));
            Assert.That(tool.Traits, Is.Empty);
        }

        [Test]
        public void GenerateCustomTool()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var tool = toolGenerator.Generate(template);
            itemVerifier.AssertMundaneItemFromTemplate(tool, template);
            Assert.That(tool.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(tool.ItemType, Is.EqualTo(ItemTypeConstants.Tool));
            Assert.That(tool.Attributes, Is.Empty);
            Assert.That(tool.IsMagical, Is.False);
            Assert.That(tool.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GenerateRandomCustomTool()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var tool = toolGenerator.Generate(template, true);
            itemVerifier.AssertMundaneItemFromTemplate(tool, template);
            Assert.That(tool.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(tool.ItemType, Is.EqualTo(ItemTypeConstants.Tool));
            Assert.That(tool.Attributes, Is.Empty);
            Assert.That(tool.IsMagical, Is.False);
            Assert.That(tool.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "other tool", "tool" };
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Tools))
                .Returns("wrong tool")
                .Returns("tool")
                .Returns("other tool");

            var tool = toolGenerator.GenerateFromSubset(subset);
            Assert.That(tool.Name, Is.EqualTo("tool"));
            Assert.That(tool.BaseNames.Single(), Is.EqualTo("tool"));
            Assert.That(tool.Attributes, Is.Empty);
            Assert.That(tool.ItemType, Is.EqualTo(ItemTypeConstants.Tool));
            Assert.That(tool.IsMagical, Is.False);
            Assert.That(tool.Contents, Is.Empty);
            Assert.That(tool.Quantity, Is.EqualTo(1));
            Assert.That(tool.Traits, Is.Empty);
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            var subset = new[] { "other tool", "tool" };
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Tools)).Returns("wrong tool");
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns((IEnumerable<string> ss) => ss.Last());

            var tool = toolGenerator.GenerateFromSubset(subset);
            Assert.That(tool.Name, Is.EqualTo("tool"));
            Assert.That(tool.BaseNames.Single(), Is.EqualTo("tool"));
            Assert.That(tool.Attributes, Is.Empty);
            Assert.That(tool.ItemType, Is.EqualTo(ItemTypeConstants.Tool));
            Assert.That(tool.IsMagical, Is.False);
            Assert.That(tool.Contents, Is.Empty);
            Assert.That(tool.Quantity, Is.EqualTo(1));
            Assert.That(tool.Traits, Is.Empty);
        }

        [Test]
        public void GenerateFromEmptySubset()
        {
            Assert.That(() => toolGenerator.GenerateFromSubset(Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot generate from an empty collection subset"));
        }
    }
}