using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Items;
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
    public class MundaneWeaponGeneratorTests
    {
        private MundaneItemGenerator mundaneWeaponGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private string expectedTableName;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<Dice> mockDice;
        private ItemVerifier itemVerifier;
        private Generator generator;
        private WeaponSelection weaponSelection;
        private Mock<IWeaponDataSelector> mockWeaponDataSelector;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockDice = new Mock<Dice>();
            generator = new ConfigurableIterativeGenerator(5);
            mockWeaponDataSelector = new Mock<IWeaponDataSelector>();
            mundaneWeaponGenerator = new MundaneWeaponGenerator(mockPercentileSelector.Object, mockCollectionsSelector.Object, mockBooleanPercentileSelector.Object, mockDice.Object, generator, mockWeaponDataSelector.Object);
            itemVerifier = new ItemVerifier();
            weaponSelection = new WeaponSelection();

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes)).Returns("weapon type");
            expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("weapon name");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            weaponSelection.CriticalMultiplier = "over 9000!!!";
            weaponSelection.DamageType = "emotional";
            weaponSelection.ThreatRange = "across the board";
            weaponSelection.DamageBySize["size"] = "normal amount";
            weaponSelection.DamageBySize["other size"] = "other amount";

            var defaultSelection = new WeaponSelection();
            defaultSelection.DamageBySize["size"] = string.Empty;

            mockWeaponDataSelector.Setup(s => s.Select(It.IsAny<string>())).Returns(defaultSelection);
            mockWeaponDataSelector.Setup(s => s.Select("weapon name")).Returns(weaponSelection);
        }

        [Test]
        public void GenerateWeapon()
        {
            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var item = mundaneWeaponGenerator.Generate();
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateMasterworkWeapon()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateNonMasterworkWeapon()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(false);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Is.Not.Contains(TraitConstants.Masterwork));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(6, 3)]
        [TestCase(7, 3)]
        [TestCase(8, 4)]
        [TestCase(9, 4)]
        [TestCase(10, 5)]
        [TestCase(11, 5)]
        [TestCase(12, 6)]
        [TestCase(13, 6)]
        [TestCase(14, 7)]
        [TestCase(15, 7)]
        [TestCase(16, 8)]
        [TestCase(17, 8)]
        [TestCase(18, 9)]
        [TestCase(19, 9)]
        [TestCase(20, 10)]
        [TestCase(21, 10)]
        [TestCase(22, 11)]
        [TestCase(23, 11)]
        [TestCase(24, 12)]
        [TestCase(25, 12)]
        [TestCase(26, 13)]
        [TestCase(27, 13)]
        [TestCase(28, 14)]
        [TestCase(29, 14)]
        [TestCase(30, 15)]
        [TestCase(31, 15)]
        [TestCase(32, 16)]
        [TestCase(33, 16)]
        [TestCase(34, 17)]
        [TestCase(35, 17)]
        [TestCase(36, 18)]
        [TestCase(37, 18)]
        [TestCase(38, 19)]
        [TestCase(39, 19)]
        [TestCase(40, 20)]
        [TestCase(41, 20)]
        [TestCase(42, 21)]
        [TestCase(43, 21)]
        [TestCase(44, 22)]
        [TestCase(45, 22)]
        [TestCase(46, 23)]
        [TestCase(47, 23)]
        [TestCase(48, 24)]
        [TestCase(49, 24)]
        [TestCase(50, 25)]
        [TestCase(51, 25)]
        [TestCase(52, 26)]
        [TestCase(53, 26)]
        [TestCase(54, 27)]
        [TestCase(55, 27)]
        [TestCase(56, 28)]
        [TestCase(57, 28)]
        [TestCase(58, 29)]
        [TestCase(59, 29)]
        [TestCase(60, 30)]
        [TestCase(61, 30)]
        [TestCase(62, 31)]
        [TestCase(63, 31)]
        [TestCase(64, 32)]
        [TestCase(65, 32)]
        [TestCase(66, 33)]
        [TestCase(67, 33)]
        [TestCase(68, 34)]
        [TestCase(69, 34)]
        [TestCase(70, 35)]
        [TestCase(71, 35)]
        [TestCase(72, 36)]
        [TestCase(73, 36)]
        [TestCase(74, 37)]
        [TestCase(75, 37)]
        [TestCase(76, 38)]
        [TestCase(77, 38)]
        [TestCase(78, 39)]
        [TestCase(79, 39)]
        [TestCase(80, 40)]
        [TestCase(81, 40)]
        [TestCase(82, 41)]
        [TestCase(83, 41)]
        [TestCase(84, 42)]
        [TestCase(85, 42)]
        [TestCase(86, 43)]
        [TestCase(87, 43)]
        [TestCase(88, 44)]
        [TestCase(89, 44)]
        [TestCase(90, 45)]
        [TestCase(91, 45)]
        [TestCase(92, 46)]
        [TestCase(93, 46)]
        [TestCase(94, 47)]
        [TestCase(95, 47)]
        [TestCase(96, 48)]
        [TestCase(97, 48)]
        [TestCase(98, 49)]
        [TestCase(99, 49)]
        [TestCase(100, 50)]
        public void AmmunitionQuantityRoll(int roll, int quantity)
        {
            var attributes = new[] { "type 1", AttributeConstants.Ammunition };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            mockDice.Setup(d => d.Roll(1).d(100).AsSum()).Returns(roll);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Quantity, Is.EqualTo(quantity));
        }

        [Test]
        public void ThrownWeaponReceivesQuantity()
        {
            var attributes = new[] { "type 1", AttributeConstants.Thrown };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);
            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(9266);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Quantity, Is.EqualTo(9266));
        }

        [Test]
        public void ThrownMeleeWeaponReceivesQuantityOf1()
        {
            var attributes = new[] { "type 1", AttributeConstants.Thrown, AttributeConstants.Melee };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);
            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(9266);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Quantity, Is.EqualTo(1));
        }

        [TestCase(WeaponConstants.CompositePlus0Longbow, WeaponConstants.CompositeLongbow, 0)]
        [TestCase(WeaponConstants.CompositePlus1Longbow, WeaponConstants.CompositeLongbow, 1)]
        [TestCase(WeaponConstants.CompositePlus2Longbow, WeaponConstants.CompositeLongbow, 2)]
        [TestCase(WeaponConstants.CompositePlus3Longbow, WeaponConstants.CompositeLongbow, 3)]
        [TestCase(WeaponConstants.CompositePlus4Longbow, WeaponConstants.CompositeLongbow, 4)]
        [TestCase(WeaponConstants.CompositePlus0Shortbow, WeaponConstants.CompositeShortbow, 0)]
        [TestCase(WeaponConstants.CompositePlus1Shortbow, WeaponConstants.CompositeShortbow, 1)]
        [TestCase(WeaponConstants.CompositePlus2Shortbow, WeaponConstants.CompositeShortbow, 2)]
        public void ChangeCompositeBowName(string compositeBowWithBonus, string compositeBow, int bonus)
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns(compositeBowWithBonus);

            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, compositeBow)).Returns(attributes);

            mockWeaponDataSelector.Setup(s => s.Select(compositeBow)).Returns(weaponSelection);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Name, Is.EqualTo(compositeBow));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Traits, Contains.Item($"+{bonus} Strength bonus"));
        }

        [Test]
        public void GenerateCustomMundaneWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);
            mockWeaponDataSelector.Setup(s => s.Select(name)).Returns(weaponSelection);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var item = mundaneWeaponGenerator.GenerateFrom(template);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Attributes, Is.EquivalentTo(attributes));
            Assert.That(item.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(item.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateCustomMundaneWeaponFromWeaponTemplate()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomWeaponTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);
            mockWeaponDataSelector.Setup(s => s.Select(name)).Returns(weaponSelection);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var item = mundaneWeaponGenerator.GenerateFrom(template);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Attributes, Is.EquivalentTo(attributes));
            Assert.That(item.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(item.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateCustomMundaneWeaponWithRandomQuantity()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.Quantity = 0;

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);
            mockWeaponDataSelector.Setup(s => s.Select(name)).Returns(weaponSelection);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var item = mundaneWeaponGenerator.GenerateFrom(template);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Attributes, Is.EquivalentTo(attributes));
            Assert.That(item.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateCustomThrownMundaneWeaponWithRandomQuantity()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.Quantity = 0;

            var attributes = new[] { "attribute 1", AttributeConstants.Thrown };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);
            mockWeaponDataSelector.Setup(s => s.Select(name)).Returns(weaponSelection);
            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(9266);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var item = mundaneWeaponGenerator.GenerateFrom(template);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Attributes, Is.EquivalentTo(attributes));
            Assert.That(item.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(item.Quantity, Is.EqualTo(9266));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateCustomAmmunitionWithRandomQuantity()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.Quantity = 0;

            var attributes = new[] { "attribute 1", AttributeConstants.Ammunition };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);
            mockWeaponDataSelector.Setup(s => s.Select(name)).Returns(weaponSelection);
            mockDice.Setup(d => d.Roll(1).d(100).AsSum()).Returns(9266);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var item = mundaneWeaponGenerator.GenerateFrom(template);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Attributes, Is.EquivalentTo(attributes));
            Assert.That(item.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(item.Quantity, Is.EqualTo(9266 / 2));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateRandomCustomMundaneWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);
            mockWeaponDataSelector.Setup(s => s.Select(name)).Returns(weaponSelection);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var item = mundaneWeaponGenerator.GenerateFrom(template, true);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Attributes, Is.EquivalentTo(attributes));
            Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(item.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void DoNotAddSizeToCustomWeaponIfItAlreadyHasOne()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.Traits.Add("custom size");
            weaponSelection.DamageBySize["custom size"] = "custom amount";

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var sizes = new[] { "size", "custom size", "other size" };
            mockPercentileSelector.Setup(s => s.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns(sizes);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("other size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);
            mockWeaponDataSelector.Setup(s => s.Select(name)).Returns(weaponSelection);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var item = mundaneWeaponGenerator.GenerateFrom(template);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Attributes, Is.EquivalentTo(attributes));
            Assert.That(item.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(item.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("custom size"));
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("other size"));
            Assert.That(weapon.Size, Is.EqualTo("custom size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("custom amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void DoNotAddSizeToCustomWeaponFromWeaponTemplateIfItAlreadyHasOne()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomWeaponTemplate(name);
            template.Size = "custom size";
            weaponSelection.DamageBySize["custom size"] = "custom amount";

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var sizes = new[] { "size", "custom size", "other size" };
            mockPercentileSelector.Setup(s => s.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns(sizes);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("other size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);
            mockWeaponDataSelector.Setup(s => s.Select(name)).Returns(weaponSelection);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var item = mundaneWeaponGenerator.GenerateFrom(template);
            itemVerifier.AssertMundaneItemFromTemplate(item, template);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Attributes, Is.EquivalentTo(attributes));
            Assert.That(item.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(item.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("custom size"));
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("other size"));
            Assert.That(weapon.Size, Is.EqualTo("custom size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("custom amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [TestCase(WeaponConstants.CompositePlus0Longbow, WeaponConstants.CompositeLongbow, 0)]
        [TestCase(WeaponConstants.CompositePlus1Longbow, WeaponConstants.CompositeLongbow, 1)]
        [TestCase(WeaponConstants.CompositePlus2Longbow, WeaponConstants.CompositeLongbow, 2)]
        [TestCase(WeaponConstants.CompositePlus3Longbow, WeaponConstants.CompositeLongbow, 3)]
        [TestCase(WeaponConstants.CompositePlus4Longbow, WeaponConstants.CompositeLongbow, 4)]
        [TestCase(WeaponConstants.CompositePlus0Shortbow, WeaponConstants.CompositeShortbow, 0)]
        [TestCase(WeaponConstants.CompositePlus1Shortbow, WeaponConstants.CompositeShortbow, 1)]
        [TestCase(WeaponConstants.CompositePlus2Shortbow, WeaponConstants.CompositeShortbow, 2)]
        public void ChangeCustomCompositeBowName(string compositeBowWithBonus, string compositeBow, int bonus)
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, compositeBow)).Returns(attributes);

            mockWeaponDataSelector.Setup(s => s.Select(compositeBow)).Returns(weaponSelection);

            var template = new Item();
            template.Name = compositeBowWithBonus;

            var weapon = mundaneWeaponGenerator.GenerateFrom(template);
            Assert.That(weapon.Name, Is.EqualTo(compositeBow));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Traits, Contains.Item($"+{bonus} Strength bonus"));
        }

        [TestCase(WeaponConstants.CompositeLongbow)]
        [TestCase(WeaponConstants.CompositeShortbow)]
        public void DoNotChangeCustomCompositeBowName(string compositeBow)
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, compositeBow)).Returns(attributes);

            mockWeaponDataSelector.Setup(s => s.Select(compositeBow)).Returns(weaponSelection);

            var template = new Item();
            template.Name = compositeBow;
            template.Traits.Add("+9266 Strength bonus");

            var weapon = mundaneWeaponGenerator.GenerateFrom(template);
            Assert.That(weapon.Name, Is.EqualTo(compositeBow));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Traits, Contains.Item("+9266 Strength bonus"));
        }

        [TestCase(WeaponConstants.CompositeLongbow)]
        [TestCase(WeaponConstants.CompositeShortbow)]
        public void DoNotChangeCustomCompositeBowNameWithoutStrengthBonus(string compositeBow)
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, compositeBow)).Returns(attributes);

            mockWeaponDataSelector.Setup(s => s.Select(compositeBow)).Returns(weaponSelection);

            var template = new Item();
            template.Name = compositeBow;

            var weapon = mundaneWeaponGenerator.GenerateFrom(template);
            Assert.That(weapon.Name, Is.EqualTo(compositeBow));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateFromSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes))
                .Returns("wrong weapon type")
                .Returns("weapon type")
                .Returns("other weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var subset = new[] { "other weapon name", "weapon name" };

            var item = mundaneWeaponGenerator.GenerateFrom(subset);
            Assert.That(item.Name, Is.EqualTo("weapon name"));
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.Quantity, Is.EqualTo(1));

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateFromBaseNameInSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes))
                .Returns("wrong weapon type")
                .Returns("weapon type")
                .Returns("other weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var subset = new[] { "other weapon name", "base name" };

            var item = mundaneWeaponGenerator.GenerateFrom(subset);
            Assert.That(item.Name, Is.EqualTo("weapon name"));
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.Quantity, Is.EqualTo(1));

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateAmmunitionFromSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes))
                .Returns("wrong weapon type")
                .Returns("weapon type")
                .Returns("other weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var attributes = new[] { "type 1", AttributeConstants.Ammunition };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            mockDice.Setup(d => d.Roll(1).d(100).AsSum()).Returns(9266);

            var subset = new[] { "other weapon name", "weapon name" };

            var item = mundaneWeaponGenerator.GenerateFrom(subset);
            Assert.That(item.Name, Is.EqualTo("weapon name"));
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.Quantity, Is.EqualTo(9266 / 2));

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateThrownWeaponFromSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes))
                .Returns("wrong weapon type")
                .Returns("weapon type")
                .Returns("other weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var attributes = new[] { "type 1", AttributeConstants.Thrown };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(9266);

            var subset = new[] { "other weapon name", "weapon name" };

            var item = mundaneWeaponGenerator.GenerateFrom(subset);
            Assert.That(item.Name, Is.EqualTo("weapon name"));
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.Quantity, Is.EqualTo(9266));

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes)).Returns("wrong weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var subset = new[] { "other weapon name", "weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns((IEnumerable<string> ss) => ss.Last());

            var item = mundaneWeaponGenerator.GenerateFrom(subset);
            Assert.That(item.Name, Is.EqualTo("weapon name"));
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.Quantity, Is.EqualTo(1));

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateDefaultAmmunitionFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes)).Returns("wrong weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var attributes = new[] { "type 1", AttributeConstants.Ammunition };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            mockDice.Setup(d => d.Roll(1).d(100).AsSum()).Returns(9266);

            var subset = new[] { "other weapon name", "weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns((IEnumerable<string> ss) => ss.Last());

            var item = mundaneWeaponGenerator.GenerateFrom(subset);
            Assert.That(item.Name, Is.EqualTo("weapon name"));
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.Quantity, Is.EqualTo(9266 / 2));

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateDefaultThrownWeaponFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes)).Returns("wrong weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var attributes = new[] { "type 1", AttributeConstants.Thrown };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(9266);

            var subset = new[] { "other weapon name", "weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns((IEnumerable<string> ss) => ss.Last());

            var item = mundaneWeaponGenerator.GenerateFrom(subset);
            Assert.That(item.Name, Is.EqualTo("weapon name"));
            Assert.That(item.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.Quantity, Is.EqualTo(9266));

            var weapon = item as Weapon;
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("size"));
            Assert.That(weapon.Size, Is.EqualTo("size"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(weapon.Damage, Is.EqualTo("normal amount"));
            Assert.That(weapon.DamageType, Is.EqualTo("emotional"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("across the board"));
        }

        [Test]
        public void GenerateFromEmptySubset()
        {
            Assert.That(() => mundaneWeaponGenerator.GenerateFrom(Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot generate from an empty collection subset"));
        }
    }
}