using Moq;
using NUnit.Framework;
using RollGen;
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
    public class MundaneWeaponGeneratorTests
    {
        private MundaneItemGenerator mundaneWeaponGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAmmunitionGenerator> mockAmmunitionGenerator;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private string expectedTableName;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<Dice> mockDice;
        private ItemVerifier itemVerifier;
        private Generator generator;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockDice = new Mock<Dice>();
            generator = new ConfigurableIterativeGenerator(5);
            mundaneWeaponGenerator = new MundaneWeaponGenerator(mockPercentileSelector.Object, mockAmmunitionGenerator.Object, mockCollectionsSelector.Object, mockBooleanPercentileSelector.Object, mockDice.Object, generator);
            itemVerifier = new ItemVerifier();

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeapons)).Returns("weapon type");
            expectedTableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("weapon name");
        }

        [Test]
        public void GenerateWeapon()
        {
            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(baseNames));
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
        public void GetWeaponSize()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("size"));
        }

        [Test]
        public void GetAmmunition()
        {
            var ammo = new Item();
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns(AttributeConstants.Ammunition);
            mockAmmunitionGenerator.Setup(p => p.Generate()).Returns(ammo);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void GetMasterworkAmmunition()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var ammo = new Item();
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns(AttributeConstants.Ammunition);
            mockAmmunitionGenerator.Setup(p => p.Generate()).Returns(ammo);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.EqualTo(ammo));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetNonMasterworkAmmunition()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork))
                .Returns(false);

            var ammo = new Item();
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns(AttributeConstants.Ammunition);
            mockAmmunitionGenerator.Setup(p => p.Generate()).Returns(ammo);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.EqualTo(ammo));
            Assert.That(weapon.Traits, Is.Not.Contains(TraitConstants.Masterwork));
        }

        [Test]
        public void GetAmmunitionSize()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var ammo = new Item();
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns(AttributeConstants.Ammunition);
            mockAmmunitionGenerator.Setup(p => p.Generate()).Returns(ammo);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.EqualTo(ammo));
            Assert.That(weapon.Traits, Contains.Item("size"));
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

        [Test]
        public void GenerateCustomMundaneWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var weapon = mundaneWeaponGenerator.Generate(template);
            itemVerifier.AssertMundaneItemFromTemplate(weapon, template);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Attributes, Is.EquivalentTo(attributes));
            Assert.That(weapon.Traits, Contains.Item("size"));
            Assert.That(weapon.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(weapon.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.BaseNames, Is.EquivalentTo(baseNames));
        }

        [Test]
        public void GenerateRandomCustomMundaneWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var weapon = mundaneWeaponGenerator.Generate(template, true);
            itemVerifier.AssertMundaneItemFromTemplate(weapon, template);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Attributes, Is.EquivalentTo(attributes));
            Assert.That(weapon.Traits, Contains.Item("size"));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(weapon.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.BaseNames, Is.EquivalentTo(baseNames));
        }

        [Test]
        public void DoNotAddSizeToCustomWeaponIfItAlreadyHasOne()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.Traits.Add("size");

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var sizes = new[] { "size", "other size" };
            mockPercentileSelector.Setup(s => s.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns(sizes);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("other size");
            mockBooleanPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork)).Returns(true);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var weapon = mundaneWeaponGenerator.Generate(template);
            itemVerifier.AssertMundaneItemFromTemplate(weapon, template);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Attributes, Is.EquivalentTo(attributes));
            Assert.That(weapon.Traits, Contains.Item("size"));
            Assert.That(weapon.Traits, Is.All.Not.EqualTo("other size"));
            Assert.That(weapon.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(weapon.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.BaseNames, Is.EquivalentTo(baseNames));
        }

        [Test]
        public void GenerateCustomMundaneAmmunition()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Throws<ArgumentException>();

            var ammunition = itemVerifier.CreateRandomTemplate(name);
            mockAmmunitionGenerator.Setup(g => g.GenerateFrom(template)).Returns(ammunition);
            mockAmmunitionGenerator.Setup(g => g.TemplateIsAmmunition(template)).Returns(true);

            var weapon = mundaneWeaponGenerator.Generate(template, true);
            itemVerifier.AssertMundaneItemFromTemplate(weapon, ammunition);
            Assert.That(weapon.Quantity, Is.EqualTo(ammunition.Quantity));
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

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Name, Is.EqualTo(compositeBow));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Traits, Contains.Item($"+{bonus} Strength bonus"));
        }

        [Test]
        public void GenerateFromSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeapons))
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

            var weapon = mundaneWeaponGenerator.GenerateFromSubset(subset);
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.Contents, Is.Empty);
            Assert.That(weapon.Quantity, Is.EqualTo(1));
            Assert.That(weapon.Traits, Contains.Item("size"));
        }

        [Test]
        public void GenerateAmmunitionFromSubset()
        {
            var subset = new[] { "other ammunition", "ammunition" };

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeapons)).Returns("ammo weapon type");
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "ammo weapon type");

            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns("weapon name")
                .Returns(AttributeConstants.Ammunition)
                .Returns(AttributeConstants.Ammunition);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var ammo = new Item { Name = "ammunition" };
            var wrongAmmo = new Item { Name = "wrong ammunition" };
            mockAmmunitionGenerator.SetupSequence(p => p.Generate())
                .Returns(wrongAmmo)
                .Returns(ammo);

            var weapon = mundaneWeaponGenerator.GenerateFromSubset(subset);
            Assert.That(weapon.Name, Is.EqualTo("ammunition"));
            Assert.That(weapon.Traits, Contains.Item("size"));
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void GenerateThrownWeaponFromSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeapons))
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

            var weapon = mundaneWeaponGenerator.GenerateFromSubset(subset);
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.Contents, Is.Empty);
            Assert.That(weapon.Quantity, Is.EqualTo(9266));
            Assert.That(weapon.Traits, Contains.Item("size"));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeapons)).Returns("wrong weapon type");

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

            var weapon = mundaneWeaponGenerator.GenerateFromSubset(subset);
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EqualTo(baseNames));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.Contents, Is.Empty);
            Assert.That(weapon.Quantity, Is.EqualTo(1));
            Assert.That(weapon.Traits, Contains.Item("size"));
        }

        [Test]
        public void GenerateFromEmptySubset()
        {
            Assert.That(() => mundaneWeaponGenerator.GenerateFromSubset(Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot generate from an empty collection subset"));
        }
    }
}