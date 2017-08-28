using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests
    {
        private MagicalItemGenerator magicalWeaponGenerator;
        private Mock<ITreasurePercentileSelector> mockPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<ISpecificGearGenerator> mockSpecificGearGenerator;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<MundaneItemGenerator> mockMundaneWeaponGenerator;
        private string power;
        private ItemVerifier itemVerifier;
        private Weapon mundaneWeapon;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<ITreasurePercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            var generator = new IterativeGeneratorWithoutLogging(5);
            mockMundaneWeaponGenerator = new Mock<MundaneItemGenerator>();
            var mockJustInTimeFactory = new Mock<JustInTimeFactory>();
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon)).Returns(mockMundaneWeaponGenerator.Object);

            magicalWeaponGenerator = new MagicalWeaponGenerator(
                mockCollectionsSelector.Object,
                mockPercentileSelector.Object,
                mockSpecialAbilitiesGenerator.Object,
                mockSpecificGearGenerator.Object,
                mockSpellGenerator.Object,
                generator,
                mockJustInTimeFactory.Object);

            itemVerifier = new ItemVerifier();

            power = "power";
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MagicalWeaponTypes)).Returns("weapon type");
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("weapon name");

            mundaneWeapon = new Weapon();
            mundaneWeapon.Name = "weapon name";
            mundaneWeapon.Quantity = 600;
            mundaneWeapon.Ammunition = "ammo";
            mundaneWeapon.CriticalMultiplier = "crit";
            mundaneWeapon.Damage = "hurty mchurtface";
            mundaneWeapon.DamageType = "spiritual";
            mundaneWeapon.Size = "enormous";
            mundaneWeapon.ThreatRange = "err'where";
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.IsAny<Item>(), It.IsAny<bool>())).Returns(new Weapon());
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.NameMatches("weapon name")), true)).Returns(mundaneWeapon);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("9266");
            mockPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[] { "9266", "90210", "42", "SpecialAbility", ItemTypeConstants.Weapon });
        }

        [Test]
        public void GenerateWeapon()
        {
            var item = magicalWeaponGenerator.GenerateFrom(power);
            Assert.That(item, Is.EqualTo(mundaneWeapon));
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Quantity, Is.EqualTo(600));
            Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork));

            var weapon = item as Weapon;
            Assert.That(weapon.Ammunition, Is.EqualTo("ammo"));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("crit"));
            Assert.That(weapon.Damage, Is.EqualTo("hurty mchurtface"));
            Assert.That(weapon.DamageType, Is.EqualTo("spiritual"));
            Assert.That(weapon.Size, Is.EqualTo("enormous"));
            Assert.That(weapon.ThreatRange, Is.EqualTo("err'where"));
        }

        [Test]
        public void GetSpecificItemsFromGenerator()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(ItemTypeConstants.Weapon);

            var specificWeapon = new Weapon();
            specificWeapon.Name = Guid.NewGuid().ToString();

            mockSpecificGearGenerator.Setup(g => g.GenerateRandomPrototypeFrom(power, ItemTypeConstants.Weapon)).Returns(specificWeapon);
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == specificWeapon.Name))).Returns(specificWeapon);
            mockSpecificGearGenerator.Setup(g => g.IsSpecific(It.Is<Item>(i => i.Name == specificWeapon.Name))).Returns(true);

            var weapon = magicalWeaponGenerator.GenerateFrom(power);
            Assert.That(weapon, Is.EqualTo(specificWeapon));
        }

        [Test]
        public void GetSpecialAbilitiesFromGenerator()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(mundaneWeapon, power, 2)).Returns(abilities);

            var weapon = magicalWeaponGenerator.GenerateFrom(power);
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void SpellStoringWeaponHasSpellIfSelectorSaysSo()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom<bool>(TableNameConstants.Percentiles.Set.SpellStoringContainsSpell)).Returns(true);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("9266");

            var abilities = new[] { new SpecialAbility { Name = SpecialAbilityConstants.SpellStoring } };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(It.IsAny<Item>(), power, 1)).Returns(abilities);

            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(1337);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1337)).Returns("spell");

            var weapon = magicalWeaponGenerator.GenerateFrom(power);
            Assert.That(weapon.Contents, Contains.Item("spell"));
        }

        [Test]
        public void SpellStoringWeaponDoesNotHaveSpellIfSelectorSaysSo()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom<bool>(TableNameConstants.Percentiles.Set.SpellStoringContainsSpell)).Returns(false);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("9266");

            var abilities = new[] { new SpecialAbility { Name = SpecialAbilityConstants.SpellStoring } };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(It.IsAny<Item>(), power, 1)).Returns(abilities);

            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(1337);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1337)).Returns("spell");

            var weapon = magicalWeaponGenerator.GenerateFrom(power);
            Assert.That(weapon.Contents, Is.Empty);
        }

        [Test]
        public void GenerateCustomWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);
            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var templateMundaneWeapon = new Weapon();
            templateMundaneWeapon.Name = name;
            templateMundaneWeapon.Quantity = 1337;
            templateMundaneWeapon.Attributes = new[] { "type 1", "type 2" };
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == name), false)).Returns(templateMundaneWeapon);

            var weapon = magicalWeaponGenerator.GenerateFrom(template);
            Assert.That(weapon, Is.EqualTo(templateMundaneWeapon));
            Assert.That(weapon.Quantity, Is.EqualTo(1337));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(template.Magic.Bonus));
            Assert.That(weapon.Magic.Charges, Is.EqualTo(template.Magic.Charges));
            Assert.That(weapon.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(weapon.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
            Assert.That(weapon.Magic.Intelligence.Ego, Is.Positive);
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(abilities));

            //INFO: Custom magic weapons should be masterwork
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateRandomCustomWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);
            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var templateMundaneWeapon = new Weapon();
            templateMundaneWeapon.Name = name;
            templateMundaneWeapon.Quantity = 1337;
            templateMundaneWeapon.Attributes = new[] { "type 1", "type 2" };
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == name), true)).Returns(templateMundaneWeapon);

            var weapon = magicalWeaponGenerator.GenerateFrom(template, true);
            Assert.That(weapon, Is.EqualTo(templateMundaneWeapon));
            Assert.That(weapon.Quantity, Is.EqualTo(1337));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(template.Magic.Bonus));
            Assert.That(weapon.Magic.Charges, Is.EqualTo(template.Magic.Charges));
            Assert.That(weapon.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(weapon.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
            Assert.That(weapon.Magic.Intelligence.Ego, Is.Positive);
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(abilities));

            //INFO: Custom magic weapons should be masterwork
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateCustomAmmunition()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);
            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var templateMundaneWeapon = new Weapon();
            templateMundaneWeapon.Name = name;
            templateMundaneWeapon.Quantity = 1337;
            templateMundaneWeapon.Attributes = new[] { "type 1", "type 2", AttributeConstants.Ammunition };
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == name), false)).Returns(templateMundaneWeapon);

            var weapon = magicalWeaponGenerator.GenerateFrom(template);
            Assert.That(weapon, Is.EqualTo(templateMundaneWeapon));
            Assert.That(weapon.Quantity, Is.EqualTo(1337));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(template.Magic.Bonus));
            Assert.That(weapon.Magic.Charges, Is.EqualTo(template.Magic.Charges));
            Assert.That(weapon.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(weapon.Magic.Intelligence, Is.Not.EqualTo(template.Magic.Intelligence));
            Assert.That(weapon.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(abilities));

            //INFO: Custom magic weapons should be masterwork
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateSpecificCustomWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specificWeapon = itemVerifier.CreateRandomWeaponTemplate(name);
            specificWeapon.ItemType = ItemTypeConstants.Weapon;
            specificWeapon.Magic.SpecialAbilities = new[] { new SpecialAbility(), new SpecialAbility() };
            specificWeapon.Attributes = new[] { "type 1", "type 2" };

            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == name))).Returns(specificWeapon);
            mockSpecificGearGenerator.Setup(g => g.IsSpecific(It.Is<Item>(i => i.Name == name))).Returns(true);

            var weapon = magicalWeaponGenerator.GenerateFrom(template, true);
            Assert.That(weapon.Name, Is.EqualTo(specificWeapon.Name));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(specificWeapon.BaseNames));
            Assert.That(weapon.Quantity, Is.EqualTo(specificWeapon.Quantity));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(specificWeapon.Magic.SpecialAbilities));
            Assert.That(weapon.Attributes, Is.EquivalentTo(specificWeapon.Attributes));
        }

        [Test]
        public void GenerateFromSubset()
        {
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MagicalWeaponTypes))
                .Returns("wrong weapon type")
                .Returns("weapon type")
                .Returns("other weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns("SpecialAbility").Returns("666")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("SpecialAbility").Returns("90210");

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(It.IsAny<Item>(), power, 2)).Returns(abilities);

            var subset = new[] { "other weapon name", "weapon name" };

            var weapon = magicalWeaponGenerator.GenerateFrom(power, subset);
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.Quantity, Is.EqualTo(600));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
            Assert.That(weapon, Is.EqualTo(mundaneWeapon));
        }

        [Test]
        public void GenerateFromBaseNameInSubset()
        {
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MagicalWeaponTypes))
                .Returns("wrong weapon type")
                .Returns("weapon type")
                .Returns("other weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns("SpecialAbility").Returns("666")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266")
                .Returns("SpecialAbility").Returns("SpecialAbility").Returns("SpecialAbility").Returns("90210");

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(It.IsAny<Item>(), power, 2)).Returns(abilities);

            var subset = new[] { "other weapon name", "base name" };
            mundaneWeapon.BaseNames = new[] { "base name", "other base name" };

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "weapon name")).Returns(mundaneWeapon.BaseNames);

            var weapon = magicalWeaponGenerator.GenerateFrom(power, subset);
            Assert.That(weapon, Is.EqualTo(mundaneWeapon));
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.Quantity, Is.EqualTo(600));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GenerateSpecificFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns(ItemTypeConstants.Weapon);

            var specificWeapon = new Weapon();
            specificWeapon.Name = "specific weapon name";
            specificWeapon.BaseNames = new[] { "base name", "other specific base name" };
            mockSpecificGearGenerator.Setup(g => g.GenerateRandomPrototypeFrom(power, ItemTypeConstants.Weapon)).Returns(specificWeapon);
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(specificWeapon);
            mockSpecificGearGenerator.Setup(g => g.IsSpecific(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(true);

            var subset = new[] { "other weapon name", "base name" };

            var weapon = magicalWeaponGenerator.GenerateFrom(power, subset);
            Assert.That(weapon.Name, Is.EqualTo("specific weapon name"));
            Assert.That(weapon, Is.EqualTo(specificWeapon));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MagicalWeaponTypes)).Returns("wrong weapon type");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");

            var subset = new[] { "other weapon name", "weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var templateMundaneWeapon = new Weapon();
            templateMundaneWeapon.Name = "weapon name";
            templateMundaneWeapon.Quantity = 1337;
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == "weapon name"), true)).Returns(templateMundaneWeapon);

            var weapon = magicalWeaponGenerator.GenerateFrom(power, subset);
            Assert.That(weapon, Is.EqualTo(templateMundaneWeapon));
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
            Assert.That(weapon.Quantity, Is.EqualTo(1337));
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(42));
            Assert.That(weapon.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void GenerateSpecificDefaultFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MagicalWeaponTypes)).Returns("wrong weapon type");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var specificWeapon = new Weapon();
            specificWeapon.Name = "specific weapon name";
            specificWeapon.BaseNames = new[] { "base name", "other specific base name" };
            specificWeapon.Quantity = 1337;
            mockSpecificGearGenerator.Setup(g => g.IsSpecific(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(true);
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(specificWeapon);

            var subset = new[] { "other weapon name", "specific weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var weapon = magicalWeaponGenerator.GenerateFrom(power, subset);
            Assert.That(weapon.Name, Is.EqualTo("specific weapon name"));
            Assert.That(weapon.Quantity, Is.EqualTo(1337));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(specificWeapon.BaseNames));
        }

        [Test]
        public void GenerateSpecificWithSpecialAbilitiesDefaultFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MagicalWeaponTypes)).Returns("wrong weapon type");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "wrong weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("weapon name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "other weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other weapon name");

            var specificWeapon = new Weapon();
            specificWeapon.Name = "specific weapon name";
            specificWeapon.BaseNames = new[] { "base name", "other specific base name" };
            specificWeapon.Quantity = 1337;
            specificWeapon.ItemType = ItemTypeConstants.Weapon;

            var abilities = new[] { new SpecialAbility(), new SpecialAbility() };
            specificWeapon.Magic.SpecialAbilities = abilities;

            mockSpecificGearGenerator.Setup(g => g.GenerateRandomPrototypeFrom(power, ItemTypeConstants.Weapon)).Returns(specificWeapon);
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(specificWeapon);
            mockSpecificGearGenerator.Setup(g => g.IsSpecific(It.Is<Item>(i => i.Name == "specific weapon name"))).Returns(true);

            var subset = new[] { "other weapon name", "specific weapon name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var weapon = magicalWeaponGenerator.GenerateFrom(power, subset);
            Assert.That(weapon.Name, Is.EqualTo("specific weapon name"));
            Assert.That(weapon.Quantity, Is.EqualTo(1337));
            Assert.That(weapon.BaseNames, Is.EquivalentTo(specificWeapon.BaseNames));
            Assert.That(weapon.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
        }
    }
}