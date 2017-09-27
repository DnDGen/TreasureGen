using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
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
        private TypeAndAmountSelection selection;
        private ItemVerifier itemVerifier;
        private Generator generator;
        private Mock<ICollectionSelector> mockCollectionsSelector;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionSelector>();
            generator = new IterativeGeneratorWithoutLogging(5);
            alchemicalItemGenerator = new AlchemicalItemGenerator(mockTypeAndAmountPercentileSelector.Object, mockCollectionsSelector.Object, generator);
            selection = new TypeAndAmountSelection();
            itemVerifier = new ItemVerifier();
        }

        [Test]
        public void GenerateAlchemicalItem()
        {
            selection.Type = "alchemical item";
            selection.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems)).Returns(selection);

            var item = alchemicalItemGenerator.Generate();
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(selection.Type));
            Assert.That(item.Quantity, Is.EqualTo(9266));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
            Assert.That(item.Attributes, Is.Empty);
            Assert.That(item.IsMagical, Is.False);
        }

        [Test]
        public void GenerateCustomAlchemicalItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var item = alchemicalItemGenerator.GenerateFrom(template);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
            Assert.That(item.Attributes, Is.Empty);
        }

        [Test]
        public void GenerateRandomCustomAlchemicalItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var item = alchemicalItemGenerator.GenerateFrom(template, true);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
            Assert.That(item.Attributes, Is.Empty);
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "other alchemical item", "alchemical item" };

            selection.Type = "alchemical item";
            selection.Amount = 9266;
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems))
                .Returns(new TypeAndAmountSelection { Type = "wrong alchemical item", Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "alchemical item", Amount = 90210 })
                .Returns(new TypeAndAmountSelection { Type = "other alchemical item", Amount = 42 });

            var item = alchemicalItemGenerator.GenerateFrom(subset);
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

            selection.Type = "alchemical item";
            selection.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems))
                .Returns(new TypeAndAmountSelection { Type = "wrong alchemical item", Amount = 9266 });

            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns((IEnumerable<string> ss) => ss.Last());

            var item = alchemicalItemGenerator.GenerateFrom(subset);
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
            Assert.That(() => alchemicalItemGenerator.GenerateFrom(Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot generate from an empty collection subset"));
        }
    }
}