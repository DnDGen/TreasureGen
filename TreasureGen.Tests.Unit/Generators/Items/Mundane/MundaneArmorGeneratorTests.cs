using DnDGen.Core.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneArmorGeneratorTests
    {
        private MundaneItemGenerator mundaneArmorGenerator;
        private Mock<ITreasurePercentileSelector> mockPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<IArmorDataSelector> mockArmorDataSelector;
        private ItemVerifier itemVerifier;
        private ArmorSelection armorSelection;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<ITreasurePercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            var generator = new IterativeGeneratorWithoutLogging(5);
            mockArmorDataSelector = new Mock<IArmorDataSelector>();
            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileSelector.Object, mockCollectionsSelector.Object, generator, mockArmorDataSelector.Object);
            itemVerifier = new ItemVerifier();
            armorSelection = new ArmorSelection();

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns("armor type");
            mockArmorDataSelector.Setup(s => s.Select("armor type")).Returns(armorSelection);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
        }

        [Test]
        public void ReturnArmor()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor, Is.Not.Null);
            Assert.That(armor, Is.InstanceOf<Armor>());
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
        public void GetArmorBonus()
        {
            armorSelection.ArmorBonus = 9266;

            var item = mundaneArmorGenerator.Generate();
            var armor = item as Armor;

            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
        }

        [Test]
        public void GetShieldArmorBonus()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockArmorDataSelector.Setup(s => s.Select("big shield")).Returns(armorSelection);

            armorSelection.ArmorBonus = 9266;

            var item = mundaneArmorGenerator.Generate();
            var armor = item as Armor;

            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
        }

        [Test]
        public void GetArmorCheckPenalty()
        {
            armorSelection.ArmorCheckPenalty = -9266;

            var item = mundaneArmorGenerator.Generate();
            var armor = item as Armor;

            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-9266));
        }

        [Test]
        public void GetShieldArmorCheckPenalty()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockArmorDataSelector.Setup(s => s.Select("big shield")).Returns(armorSelection);

            armorSelection.ArmorCheckPenalty = -9266;

            var item = mundaneArmorGenerator.Generate();
            var armor = item as Armor;

            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-9266));
        }

        [Test]
        public void GetMaxDexterityBonus()
        {
            armorSelection.MaxDexterityBonus = 9266;

            var item = mundaneArmorGenerator.Generate();
            var armor = item as Armor;

            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(9266));
        }

        [Test]
        public void GetShieldMaxDexterityBonus()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockArmorDataSelector.Setup(s => s.Select("big shield")).Returns(armorSelection);

            armorSelection.MaxDexterityBonus = 9266;

            var item = mundaneArmorGenerator.Generate();
            var armor = item as Armor;

            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(9266));
        }

        [Test]
        public void SetMasterworkTraitIfMasterwork()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void DoNotSetMasterworkTraitIfNotMasterwork()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(false);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
        }

        [Test]
        public void GetShieldTypeIfResultIsShield()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockArmorDataSelector.Setup(s => s.Select("big shield")).Returns(armorSelection);

            var shield = mundaneArmorGenerator.Generate();
            Assert.That(shield.Name, Is.EqualTo("big shield"));
        }

        [Test]
        public void GetShieldBaseNames()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockArmorDataSelector.Setup(s => s.Select("big shield")).Returns(armorSelection);

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

            var item = mundaneArmorGenerator.Generate();
            var armor = item as Armor;

            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
        }

        [Test]
        public void GetAttributesForMundaneShields()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockArmorDataSelector.Setup(s => s.Select("big shield")).Returns(armorSelection);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
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
            mockArmorDataSelector.Setup(s => s.Select("big shield")).Returns(armorSelection);

            var item = mundaneArmorGenerator.Generate();
            var armor = item as Armor;

            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
        }

        [Test]
        public void GetMasterworkMundaneShield()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);
            mockArmorDataSelector.Setup(s => s.Select("big shield")).Returns(armorSelection);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void DoNotGetMasterworkMundaneShield()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("big shield");
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(false);
            mockArmorDataSelector.Setup(s => s.Select("big shield")).Returns(armorSelection);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Is.Not.Contains(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateCustomMundaneArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomArmorTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select(name)).Returns(armorSelection);

            var item = mundaneArmorGenerator.GenerateFrom(template);
            var armor = item as Armor;

            itemVerifier.AssertMundaneItemFromTemplate(armor, template);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
        }

        [Test]
        public void GenerateCustomMundaneArmorFromNonArmorTemplate()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select(name)).Returns(armorSelection);

            var item = mundaneArmorGenerator.GenerateFrom(template);
            var armor = item as Armor;

            itemVerifier.AssertMundaneItemFromTemplate(armor, template);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
        }

        [Test]
        public void GenerateRandomCustomMundaneArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomArmorTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select(name)).Returns(armorSelection);

            var item = mundaneArmorGenerator.GenerateFrom(template, true);
            var armor = item as Armor;

            itemVerifier.AssertMundaneItemFromTemplate(armor, template);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
        }

        [Test]
        public void DoNotAddSizeToCustomItemIfItAlreadyHasOne()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomArmorTemplate(name);
            template.Traits.Add("custom size");

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var sizes = new[] { "size", "custom size", "other size" };
            mockPercentileSelector.Setup(s => s.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns(sizes);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("other size");
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select(name)).Returns(armorSelection);

            var item = mundaneArmorGenerator.GenerateFrom(template);
            var armor = item as Armor;

            itemVerifier.AssertMundaneItemFromTemplate(armor, template);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("custom size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("other size"));
            Assert.That(armor.Size, Is.EqualTo("custom size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
        }

        [Test]
        public void DoNotAddSizeToCustomArmorIfItAlreadyHasOne()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomArmorTemplate(name);
            template.Size = "custom size";

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var sizes = new[] { "size", "custom size", "other size" };
            mockPercentileSelector.Setup(s => s.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns(sizes);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("other size");
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select(name)).Returns(armorSelection);

            var item = mundaneArmorGenerator.GenerateFrom(template);
            var armor = item as Armor;

            itemVerifier.AssertMundaneItemFromTemplate(armor, template);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("custom size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("other size"));
            Assert.That(armor.Size, Is.EqualTo("custom size"));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
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
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(false);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor")).Returns(attributes);

            var subset = new[] { "other armor", "armor" };

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select("armor")).Returns(armorSelection);
            mockArmorDataSelector.Setup(s => s.Select("wrong armor")).Returns(new ArmorSelection());

            var item = mundaneArmorGenerator.GenerateFrom(subset);
            var armor = item as Armor;

            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("armor"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
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
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor")).Returns(attributes);

            var subset = new[] { "other armor", "armor" };

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select("armor")).Returns(armorSelection);
            mockArmorDataSelector.Setup(s => s.Select("wrong armor")).Returns(new ArmorSelection());

            var item = mundaneArmorGenerator.GenerateFrom(subset);
            var armor = item as Armor;

            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("armor"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
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
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(false);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "shield")).Returns(attributes);

            var subset = new[] { "other shield", "shield" };

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select("shield")).Returns(armorSelection);
            mockArmorDataSelector.Setup(s => s.Select("wrong shield")).Returns(new ArmorSelection());

            var item = mundaneArmorGenerator.GenerateFrom(subset);
            var armor = item as Armor;

            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("shield"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
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
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "shield")).Returns(attributes);

            var subset = new[] { "other armor", "shield" };

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select("shield")).Returns(armorSelection);
            mockArmorDataSelector.Setup(s => s.Select("wrong shield")).Returns(new ArmorSelection());

            var item = mundaneArmorGenerator.GenerateFrom(subset);
            var armor = item as Armor;

            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("shield"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns("wrong armor");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor")).Returns(baseNames);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor")).Returns(attributes);

            var subset = new[] { "other armor", "armor" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select("armor")).Returns(armorSelection);
            mockArmorDataSelector.Setup(s => s.Select("wrong armor")).Returns(new ArmorSelection());

            var item = mundaneArmorGenerator.GenerateFrom(subset);
            var armor = item as Armor;

            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("armor"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
        }

        [Test]
        public void GenerateDefaultShieldFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(AttributeConstants.Shield);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields)).Returns("wrong shield");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "shield")).Returns(baseNames);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockPercentileSelector.Setup(p => p.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "shield")).Returns(attributes);

            var subset = new[] { "other shield", "shield" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;
            mockArmorDataSelector.Setup(s => s.Select("shield")).Returns(armorSelection);
            mockArmorDataSelector.Setup(s => s.Select("wrong shield")).Returns(new ArmorSelection());

            var item = mundaneArmorGenerator.GenerateFrom(subset);
            var armor = item as Armor;

            Assert.That(armor, Is.Not.Null);
            Assert.That(armor.Name, Is.EqualTo("shield"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(armor.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(armor.Size, Is.EqualTo("size"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
        }

        [Test]
        public void GenerateFromEmptySubset()
        {
            Assert.That(() => mundaneArmorGenerator.GenerateFrom(Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot generate from an empty collection subset"));
        }
    }
}