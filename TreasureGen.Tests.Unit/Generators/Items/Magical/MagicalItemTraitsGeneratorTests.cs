using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemTraitsGeneratorTests
    {
        private IMagicalItemTraitsGenerator generator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private List<string> attributes;
        private string itemType;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            generator = new MagicalItemTraitsGenerator(mockPercentileSelector.Object);
            attributes = new List<string>();
            itemType = "item type";
        }

        [Test]
        public void GenerateTraits()
        {
            var traits = generator.GenerateFor(itemType, attributes);
            Assert.That(traits, Is.Not.Null);
        }

        [Test]
        public void GetTraitsFromPercentileSelector()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, "item type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("trait");
            var traits = generator.GenerateFor(itemType, attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void IMeleefWeapon_GetMeleeTraits()
        {
            attributes.Add(AttributeConstants.Melee);
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, AttributeConstants.Melee);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("trait");

            var traits = generator.GenerateFor(itemType, attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void IfRangedWeapon_GetRangedTraits()
        {
            attributes.Add(AttributeConstants.Ranged);
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, AttributeConstants.Ranged);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("trait");

            var traits = generator.GenerateFor(itemType, attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void IfMeleeAndRangedWeapon_GetMeleeTraits()
        {
            attributes.Add(AttributeConstants.Melee);
            attributes.Add(AttributeConstants.Ranged);
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, AttributeConstants.Melee);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("trait");

            var traits = generator.GenerateFor(itemType, attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void SplitsCommaDelimitedTraits()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, "item type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("trait,other trait");

            var traits = generator.GenerateFor(itemType, attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits, Contains.Item("other trait"));
            Assert.That(traits.Count(), Is.EqualTo(2));
        }

        [Test]
        public void DoNotAddEmptyTrait()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, "item type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(String.Empty);

            var traits = generator.GenerateFor(itemType, attributes);
            Assert.That(traits, Is.Empty);
        }
    }
}