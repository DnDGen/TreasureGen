using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests
    {
        private MagicalItemGenerator magicalWeaponGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<ISpecificGearGenerator> mockSpecificGearGenerator;
        private Mock<IAmmunitionGenerator> mockAmmunitionGenerator;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private string power;
        private Mock<Dice> mockDice;
        private ItemVerifier itemVerifier;
        private string tableName;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockDice = new Mock<Dice>();
            var generator = new ConfigurableIterativeGenerator(5);
            magicalWeaponGenerator = new MagicalWeaponGenerator(
                mockCollectionsSelector.Object,
                mockPercentileSelector.Object,
                mockAmmunitionGenerator.Object,
                mockSpecialAbilitiesGenerator.Object,
                mockSpecificGearGenerator.Object,
                mockBooleanPercentileSelector.Object,
                mockSpellGenerator.Object,
                mockDice.Object,
                generator);

            itemVerifier = new ItemVerifier();

            power = "power";
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes)).Returns("weapon type");
            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("weapon name");
        }

        [Test]
        public void GenerateWeapon()
        {
            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.Positive);
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
        }

        [Test]
        public void GetBaseNames()
        {
            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GetBonusFromSelector()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("9266");

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(9266));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetSpecificItemsFromGenerator()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(ItemTypeConstants.Weapon);

            var specificWeapon = new Item();
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(power, ItemTypeConstants.Weapon)).Returns(specificWeapon);

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon, Is.EqualTo(specificWeapon));
        }

        [Test]
        public void GetSpecialAbilitiesFromGenerator()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes, power, 9266, 2)).Returns(abilities);

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GetAmmunition()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(AttributeConstants.Ammunition);

            var ammo = new Item();
            mockAmmunitionGenerator.Setup(g => g.Generate()).Returns(ammo);

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void SpellStoringWeaponHasSpellIfSelectorSaysSo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.SpellStoringContainsSpell)).Returns(true);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("0");

            var abilities = new[] { new SpecialAbility { Name = SpecialAbilityConstants.SpellStoring } };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, It.IsAny<IEnumerable<string>>(), power, It.IsAny<int>(), 1)).Returns(abilities);

            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(9266);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9266)).Returns("spell");

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Contents, Contains.Item("spell"));
        }

        [Test]
        public void SpellStoringWeaponDoesNotHaveSpellIfSelectorSaysSo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.SpellStoringContainsSpell)).Returns(false);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("0");

            var abilities = new[] { new SpecialAbility { Name = SpecialAbilityConstants.SpellStoring } };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, It.IsAny<IEnumerable<string>>(), power, It.IsAny<int>(), 1)).Returns(abilities);

            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(9266);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9266)).Returns("spell");

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Contents, Is.Empty);
        }

        [Test]
        public void ThrownWeaponReceivesQuantity()
        {
            var attributes = new[] { "type 1", AttributeConstants.Thrown };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);
            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(9266);

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Quantity, Is.EqualTo(9266));
        }

        [Test]
        public void ThrownMeleeWeaponReceivesQuantityOf1()
        {
            var attributes = new[] { "type 1", AttributeConstants.Thrown, AttributeConstants.Melee };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);
            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(9266);

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GenerateCustomWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);
            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, template.Name)).Returns(baseNames);

            var weapon = magicalWeaponGenerator.Generate(template);
            itemVerifier.AssertMagicalItemFromTemplate(weapon, template);
            Assert.That(weapon.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Attributes, Is.EquivalentTo(attributes));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(baseNames));
        }

        [Test]
        public void GenerateRandomCustomWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, template.Name)).Returns(baseNames);

            var weapon = magicalWeaponGenerator.Generate(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(weapon, template);
            Assert.That(weapon.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Attributes, Is.EquivalentTo(attributes));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(baseNames));
        }

        [Test]
        public void GenerateSpecificCustomWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specificWeapon = itemVerifier.CreateRandomTemplate(name);
            specificWeapon.ItemType = ItemTypeConstants.Weapon;
            specificWeapon.Magic.SpecialAbilities = new[] { new SpecialAbility(), new SpecialAbility() };
            specificWeapon.Attributes = new[] { "type 1", "type 2" };
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(template)).Returns(specificWeapon);
            mockSpecificGearGenerator.Setup(g => g.TemplateIsSpecific(template)).Returns(true);

            var weapon = magicalWeaponGenerator.Generate(template, true);
            Assert.That(weapon.Name, Is.EqualTo(specificWeapon.Name));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(specificWeapon.BaseNames));
            Assert.That(weapon.Quantity, Is.EqualTo(specificWeapon.Quantity));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(specificWeapon.Magic.SpecialAbilities));
            Assert.That(weapon.Attributes, Is.EquivalentTo(specificWeapon.Attributes));
        }

        [Test]
        public void GenerateCustomAmmunition()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Throws<ArgumentException>();

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var ammunition = itemVerifier.CreateRandomTemplate(name);
            ammunition.ItemType = ItemTypeConstants.Weapon;
            mockAmmunitionGenerator.Setup(g => g.TemplateIsAmmunition(template)).Returns(true);
            mockAmmunitionGenerator.Setup(g => g.GenerateFrom(template)).Returns(ammunition);

            var weapon = magicalWeaponGenerator.Generate(template, true);
            Assert.That(weapon.Name, Is.EqualTo(ammunition.Name));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(ammunition.BaseNames));
            Assert.That(weapon.Quantity, Is.EqualTo(ammunition.Quantity));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
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
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(compositeBowWithBonus);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, compositeBow)).Returns(attributes);

            var weapon = magicalWeaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Name, Is.EqualTo(compositeBow));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Traits, Contains.Item($"+{bonus} Strength bonus"));
        }

        [Test]
        public void GenerateFromSubset()
        {
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes))
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

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns("SpecialAbility").Returns("666")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("SpecialAbility").Returns("90210");

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes, power, 9266, 2)).Returns(abilities);

            var subset = new[] { "other weapon name", "weapon name" };

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.EqualTo(1));
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EqualTo(baseNames));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GenerateFromBaseNameInSubset()
        {
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes))
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

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns("SpecialAbility").Returns("666")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("SpecialAbility").Returns("90210");

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes, power, 9266, 2)).Returns(abilities);

            var subset = new[] { "other weapon name", "base name" };

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.EqualTo(1));
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EqualTo(baseNames));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GenerateSpecificFromSubset()
        {
            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns(ItemTypeConstants.Weapon);

            var specificWeapon = new Item();
            specificWeapon.Name = "specific weapon name";
            specificWeapon.BaseNames = new[] { "base name", "other specific base name" };
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(power, ItemTypeConstants.Weapon)).Returns(specificWeapon);

            var subset = new[] { "other weapon name", "base name" };

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon, Is.EqualTo(specificWeapon));
            Assert.That(weapon.Name, Is.EqualTo("specific weapon name"));
        }

        [Test]
        public void GenerateAmmunitionFromSubset()
        {
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes))
                .Returns("wrong weapon type")
                .Returns("weapon type")
                .Returns("other weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(AttributeConstants.Ammunition);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns("SpecialAbility").Returns("666")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("SpecialAbility").Returns("90210"); ;

            var ammo = new Item();
            ammo.Name = "ammunition";
            ammo.Quantity = 42;
            ammo.ItemType = ItemTypeConstants.Weapon;
            mockAmmunitionGenerator.Setup(g => g.Generate()).Returns(ammo);
            mockAmmunitionGenerator.Setup(g => g.TemplateIsAmmunition(It.Is<Item>(i => i.Name == "ammunition"))).Returns(true);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, ammo.Attributes, power, 9266, 2)).Returns(abilities);

            var subset = new[] { "other weapon name", "ammunition" };

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon, Is.EqualTo(ammo));
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.EqualTo(42));
            Assert.That(weapon.Name, Is.EqualTo("ammunition"));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GenerateThrownWeaponFromSubset()
        {
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes))
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

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns("SpecialAbility").Returns("666")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("SpecialAbility").Returns("90210");

            var attributes = new[] { "type 1", "type 2", AttributeConstants.Thrown };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes, power, 9266, 2)).Returns(abilities);

            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(90210);

            var subset = new[] { "other weapon name", "weapon name" };

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.EqualTo(90210));
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EqualTo(baseNames));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes)).Returns("wrong weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");
            mockPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[] { "9266", "90210", "42", "SpecialAbility", ItemTypeConstants.Weapon });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var subset = new[] { "other weapon name", "weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.EqualTo(1));
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EqualTo(baseNames));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(42));
            Assert.That(weapon.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void GenerateSpecificDefaultFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes)).Returns("wrong weapon type");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var specificWeapon = new Item();
            specificWeapon.Name = "specific weapon name";
            specificWeapon.BaseNames = new[] { "base name", "other specific base name" };
            mockSpecificGearGenerator.Setup(g => g.TemplateIsSpecific(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(true);
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(specificWeapon);

            var subset = new[] { "other weapon name", "specific weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon.Name, Is.EqualTo("specific weapon name"));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(specificWeapon.BaseNames));
        }

        [Test]
        public void GenerateSpecificWithSpecialAbilitiesDefaultFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes)).Returns("wrong weapon type");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var specificWeapon = new Item();
            specificWeapon.Name = "specific weapon name";
            specificWeapon.BaseNames = new[] { "base name", "other specific base name" };
            specificWeapon.ItemType = ItemTypeConstants.Weapon;
            var abilities = new[] { new SpecialAbility(), new SpecialAbility() };
            specificWeapon.Magic.SpecialAbilities = abilities;
            mockSpecificGearGenerator.Setup(g => g.TemplateIsSpecific(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(true);
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(specificWeapon);

            var subset = new[] { "other weapon name", "specific weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon.Name, Is.EqualTo("specific weapon name"));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(specificWeapon.BaseNames));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
        }

        [Test]
        public void GenerateAmmunitionDefaultFromSubset()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes)).Returns("wrong weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");
            mockPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[] { "9266", "90210", "42", "SpecialAbility", ItemTypeConstants.Weapon });

            var ammo = new Item();
            ammo.Name = "ammunition";
            ammo.ItemType = ItemTypeConstants.Weapon;
            ammo.Quantity = 600;
            mockAmmunitionGenerator.Setup(g => g.TemplateIsAmmunition(It.Is<Item>(i => i.Name == "ammunition"))).Returns(true);
            mockAmmunitionGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == "ammunition"))).Returns(ammo);

            var subset = new[] { "other weapon name", "ammunition" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon.Name, Is.EqualTo("ammunition"));
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.EqualTo(600));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(42));
            Assert.That(weapon.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void GenerateThrownDefaultFromSubset()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes)).Returns("wrong weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(baseNames);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");
            mockPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[] { "9266", "90210", "42", "SpecialAbility", ItemTypeConstants.Weapon });

            var attributes = new[] { "type 1", "type 2", AttributeConstants.Thrown };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes, power, 42, 2)).Returns(abilities);

            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(90210);

            var subset = new[] { "other weapon name", "weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var weapon = magicalWeaponGenerator.GenerateFromSubset(power, subset);
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.BaseNames, Is.EqualTo(baseNames));
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
            Assert.That(weapon.Quantity, Is.EqualTo(90210));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(42));
            Assert.That(weapon.Magic.SpecialAbilities, Is.Empty);
        }
    }
}