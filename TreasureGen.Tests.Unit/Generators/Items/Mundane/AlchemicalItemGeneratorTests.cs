using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests
    {
        private MundaneItemGenerator alchemicalItemGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private TypeAndAmountPercentileResult result;
        private ItemVerifier itemVerifier;
        private Generator generator;
        private Mock<ICollectionsSelector> mockCollectionsSelector;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            generator = new ConfigurableIterativeGenerator(5);
            alchemicalItemGenerator = new AlchemicalItemGenerator(mockTypeAndAmountPercentileSelector.Object, mockCollectionsSelector.Object, generator);
            result = new TypeAndAmountPercentileResult();
            itemVerifier = new ItemVerifier();
        }

        [Test]
        public void GenerateAlchemicalItem()
        {
            result.Type = "alchemical item";
            result.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems)).Returns(result);

            var item = alchemicalItemGenerator.Generate();
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(result.Type));
            Assert.That(item.Quantity, Is.EqualTo(9266));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
        }

        [Test]
        public void GenerateCustomAlchemicalItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var item = alchemicalItemGenerator.Generate(template);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
        }

        [Test]
        public void GenerateRandomCustomAlchemicalItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var item = alchemicalItemGenerator.Generate(template, true);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "other alchemical item", "alchemical item" };

            result.Type = "alchemical item";
            result.Amount = 9266;
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems))
                .Returns(new TypeAndAmountPercentileResult { Type = "wrong alchemical item", Amount = 9266 })
                .Returns(new TypeAndAmountPercentileResult { Type = "alchemical item", Amount = 90210 })
                .Returns(new TypeAndAmountPercentileResult { Type = "other alchemical item", Amount = 42 });

            var item = alchemicalItemGenerator.GenerateFromSubset(subset);
            Assert.That(item.Name, Is.EqualTo("alchemical item"));
            Assert.That(item.BaseNames.Single(), Is.EqualTo("alchemical item"));
            Assert.That(item.Attributes, Is.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.Quantity, Is.EqualTo(90210));
            Assert.That(item.Traits, Is.Empty);
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            var subset = new[] { "other alchemical item", "alchemical item" };

            result.Type = "alchemical item";
            result.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems))
                .Returns(new TypeAndAmountPercentileResult { Type = "wrong alchemical item", Amount = 9266 });

            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns((IEnumerable<string> ss) => ss.Last());

            var item = alchemicalItemGenerator.GenerateFromSubset(subset);
            Assert.That(item.Name, Is.EqualTo("alchemical item"));
            Assert.That(item.BaseNames.Single(), Is.EqualTo("alchemical item"));
            Assert.That(item.Attributes, Is.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.That(item.Traits, Is.Empty);
        }

        [Test]
        public void GenerateFromEmptySubset()
        {
            Assert.That(() => alchemicalItemGenerator.GenerateFromSubset(Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot generate from an empty collection subset"));
        }
    }
}