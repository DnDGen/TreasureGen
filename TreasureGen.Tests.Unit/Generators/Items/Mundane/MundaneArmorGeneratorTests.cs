using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneArmorGeneratorTests
    {
        private MundaneItemGenerator mundaneArmorGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            var generator = new ConfigurableIterativeGenerator(5);
            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileSelector.Object, mockCollectionsSelector.Object, mockBooleanPercentileSelector.Object, generator);
            itemVerifier = new ItemVerifier();

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns("armor type");
        }

        [Test]
        public void ReturnArmor()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor, Is.Not.Null);
        }

        [Test]
        public void GetArmorTypeFromPercentileSelector()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("armor type"));
        }

        [Test]
        public void GetArmorBaseNames()
        {
            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor type")).Returns(baseNames);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void SetMasterworkTraitIfMasterwork()
        {
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void DoNotSetMasterworkTraitIfNotMasterwork()
        {
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(false);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
        }

        [Test]
        public void GetShieldTypeIfResultIsShield()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");

            var shield = mundaneArmorGenerator.Generate();
            Assert.That(shield.Name, Is.EqualTo("big shield"));
        }

        [Test]
        public void GetShieldBaseNames()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "big shield")).Returns(baseNames);

            var shield = mundaneArmorGenerator.Generate();
            Assert.That(shield.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor type")).Returns(attributes);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateSizeFromPercentileSelector()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAttributesForMundaneShields()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = String.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "big shield")).Returns(attributes);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetSizesForMundaneShields()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item("size"));
        }

        [Test]
        public void GetMasterworkMundaneShield()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork))
                .Returns(true);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void DoNotGetMasterworkMundaneShield()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork))
                .Returns(false);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Is.Not.Contains(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateCustomMundaneArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var armor = mundaneArmorGenerator.Generate(template);
            itemVerifier.AssertMundaneItemFromTemplate(armor, template);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GenerateRandomCustomMundaneArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var armor = mundaneArmorGenerator.Generate(template, true);
            itemVerifier.AssertMundaneItemFromTemplate(armor, template);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void DoNotAddSizeToCustomArmorIfItAlreadyHasOne()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.Traits.Add("size");

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var sizes = new[] { "size", "other size" };
            mockPercentileSelector.Setup(s => s.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns(sizes);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("other size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var armor = mundaneArmorGenerator.Generate(template);
            itemVerifier.AssertMundaneItemFromTemplate(armor, template);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("other size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GenerateFromSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors))
                .Returns("wrong armor")
                .Returns("armor")
                .Returns("other armor");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor")).Returns(baseNames);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(false);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor")).Returns(attributes);

            var subset = new[] { "other armor", "armor" };

            var armor = mundaneArmorGenerator.GenerateFromSubset(subset);
            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("armor"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateMasterworkFromSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors))
                .Returns("wrong armor")
                .Returns("armor")
                .Returns("other armor");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor")).Returns(baseNames);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor")).Returns(attributes);

            var subset = new[] { "other armor", "armor" };

            var armor = mundaneArmorGenerator.GenerateFromSubset(subset);
            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("armor"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateShieldFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields))
                .Returns("wrong shield")
                .Returns("shield")
                .Returns("other shield");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "shield")).Returns(baseNames);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(false);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "shield")).Returns(attributes);

            var subset = new[] { "other shield", "shield" };

            var armor = mundaneArmorGenerator.GenerateFromSubset(subset);
            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("shield"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateMasterworkShieldFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields))
                .Returns("wrong shield")
                .Returns("shield")
                .Returns("other shield");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "shield")).Returns(baseNames);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "shield")).Returns(attributes);

            var subset = new[] { "other armor", "shield" };

            var armor = mundaneArmorGenerator.GenerateFromSubset(subset);
            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("shield"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns("wrong armor");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor")).Returns(baseNames);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor")).Returns(attributes);

            var subset = new[] { "other armor", "armor" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var armor = mundaneArmorGenerator.GenerateFromSubset(subset);
            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("armor"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateDefaultShieldFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("wrong shield");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "shield")).Returns(baseNames);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "shield")).Returns(attributes);

            var subset = new[] { "other shield", "shield" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var armor = mundaneArmorGenerator.GenerateFromSubset(subset);
            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("shield"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Contains.Item("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateFromEmptySubset()
        {
            Assert.That(() => mundaneArmorGenerator.GenerateFromSubset(Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot generate from an empty collection subset"));
        }
    }
}