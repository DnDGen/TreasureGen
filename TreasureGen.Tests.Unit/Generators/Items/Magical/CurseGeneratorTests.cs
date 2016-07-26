using Moq;
using NUnit.Framework;
using RollGen;
using System;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class CurseGeneratorTests
    {
        private ICurseGenerator curseGenerator;
        private Mock<Dice> mockDice;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<Dice>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();

            curseGenerator = new CurseGenerator(mockDice.Object, mockPercentileSelector.Object, mockBooleanPercentileSelector.Object,
                mockCollectionsSelector.Object);

            itemVerifier = new ItemVerifier();
        }

        [Test]
        public void NotCursedIfNoMagic()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsItemCursed)).Returns(true);
            var cursed = curseGenerator.HasCurse(false);
            Assert.That(cursed, Is.False);
        }

        [Test]
        public void NotCursedIfSelectorSaySo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsItemCursed)).Returns(false);
            var cursed = curseGenerator.HasCurse(true);
            Assert.That(cursed, Is.False);
        }

        [Test]
        public void CursedIfSelectorSaysSo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsItemCursed)).Returns(true);
            var cursed = curseGenerator.HasCurse(true);
            Assert.That(cursed, Is.True);
        }

        [Test]
        public void GenerateCurseGetsFromPercentileSelector()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("curse");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("curse"));
        }

        [Test]
        public void IfIntermittentFunctioning_1OnD3IsUnreliable()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).IndividualRolls(3)).Returns(new[] { 1 });

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Unreliable)"));
        }

        [Test]
        public void IfIntermittentFunctioning_2OnD3IsDependent()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).IndividualRolls(3)).Returns(new[] { 2 });
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CursedDependentSituations)).Returns("situation");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation)"));
        }

        [Test]
        public void IfIntermittentFunctioning_3OnD3IsUncontrolled()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).IndividualRolls(3)).Returns(new[] { 3 });

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Uncontrolled)"));
        }

        [Test]
        public void IfDrawback_GetDrawback()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Drawback");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CurseDrawbacks)).Returns("cursed drawback");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("cursed drawback"));
        }

        [Test]
        public void GetSpecificCursedItem()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.SpecificCursedItems)).Returns("specific cursed item");

            var itemType = new[] { "item type" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecificCursedItemItemTypes, "specific cursed item"))
                .Returns(itemType);

            var attributes = new[] { "attribute 1", "attribute 2" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecificCursedItemAttributes, "specific cursed item"))
                .Returns(attributes);

            var cursedItem = curseGenerator.GenerateSpecificCursedItem();
            Assert.That(cursedItem.Name, Is.EqualTo("specific cursed item"));
            Assert.That(cursedItem.IsMagical, Is.True);
            Assert.That(cursedItem.Magic.Curse, Is.EqualTo(CurseConstants.SpecificCursedItem));
            Assert.That(cursedItem.ItemType, Is.EqualTo("item type"));
            Assert.That(cursedItem.Attributes, Is.EquivalentTo(attributes));
        }

        [Test]
        public void TemplateHasCurse()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var cursedItems = new[] { "other cursed item", name };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, CurseConstants.SpecificCursedItem)).Returns(cursedItems);

            var isCursed = curseGenerator.IsSpecificCursedItem(template);
            Assert.That(isCursed, Is.True);
        }

        [Test]
        public void TemplateHasNoCurse()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var cursedItems = new[] { "other cursed item", "cursed item" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, CurseConstants.SpecificCursedItem)).Returns(cursedItems);

            var isCursed = curseGenerator.IsSpecificCursedItem(template);
            Assert.That(isCursed, Is.False);
        }

        [Test]
        public void GenerateCustomSpecificCursedItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var itemType = new[] { "item type" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecificCursedItemItemTypes, name))
                .Returns(itemType);

            var attributes = new[] { "attribute 1", "attribute 2" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecificCursedItemAttributes, name))
                .Returns(attributes);

            var cursedItem = curseGenerator.GenerateSpecificCursedItem(template);
            itemVerifier.AssertMagicalItemFromTemplate(cursedItem, template);
            Assert.That(cursedItem.Name, Is.EqualTo(name));
            Assert.That(cursedItem.IsMagical, Is.True);
            Assert.That(cursedItem.ItemType, Is.EqualTo("item type"));
            Assert.That(cursedItem.Attributes, Is.EquivalentTo(attributes));
            Assert.That(cursedItem.Magic.Curse, Is.EqualTo(CurseConstants.SpecificCursedItem));
            Assert.That(cursedItem.Magic.SpecialAbilities, Is.Empty);
        }
    }
}