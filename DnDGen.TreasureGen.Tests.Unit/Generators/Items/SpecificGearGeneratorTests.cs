using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Generators.Items;
using DnDGen.TreasureGen.Generators.Items.Magical;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class SpecificGearGeneratorTests
    {
        private ISpecificGearGenerator specificGearGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionsSelector;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<ITreasurePercentileSelector> mockPercentileSelector;
        private Mock<MundaneItemGenerator> mockMundaneArmorGenerator;
        private Mock<MundaneItemGenerator> mockMundaneWeaponGenerator;
        private TypeAndAmountSelection selection;
        private string power;
        private string gearType;
        private ItemVerifier itemVerifier;
        private List<string> baseNames;
        private Armor mundaneArmor;
        private Weapon mundaneWeapon;
        private Item template;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockPercentileSelector = new Mock<ITreasurePercentileSelector>();
            mockMundaneArmorGenerator = new Mock<MundaneItemGenerator>();
            mockMundaneWeaponGenerator = new Mock<MundaneItemGenerator>();
            var mockJustInTimeFactory = new Mock<JustInTimeFactory>();

            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(ItemTypeConstants.Armor)).Returns(mockMundaneArmorGenerator.Object);
            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon)).Returns(mockMundaneWeaponGenerator.Object);

            specificGearGenerator = new SpecificGearGenerator(
                mockTypeAndAmountPercentileSelector.Object,
                mockCollectionsSelector.Object,
                mockChargesGenerator.Object,
                mockPercentileSelector.Object,
                mockSpellGenerator.Object,
                mockSpecialAbilitiesGenerator.Object,
                mockJustInTimeFactory.Object);

            selection = new TypeAndAmountSelection();
            itemVerifier = new ItemVerifier();
            baseNames = new List<string> { "base name" };
            mundaneArmor = itemVerifier.CreateRandomArmorTemplate(baseNames[0]);
            mundaneWeapon = itemVerifier.CreateRandomWeaponTemplate(baseNames[0]);
            template = new Item();

            mundaneArmor.Contents.Clear();
            mundaneWeapon.Contents.Clear();

            power = "power";
            gearType = "gear type";

            selection.Type = "specific gear";
            selection.Amount = 9266;

            template.Magic.Bonus = selection.Amount;
            template.Name = selection.Type;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, gearType);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(selection);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>())).Returns((string table, string name) => new[] { name });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            mockCollectionsSelector.Setup(s => s.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>(), AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon))
                .Returns(ItemTypeConstants.Armor);

            mockMundaneArmorGenerator.Setup(g => g.GenerateFrom(It.IsAny<Item>(), false)).Returns(new Armor());
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.IsAny<Item>(), false)).Returns(new Weapon());

            mockMundaneArmorGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == baseNames[0]), false)).Returns(mundaneArmor);
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == baseNames[0]), false)).Returns(mundaneWeapon);
        }

        [Test]
        public void ReturnPrototype()
        {
            var prototype = specificGearGenerator.GenerateRandomPrototypeFrom(power, gearType);
            Assert.That(prototype, Is.Not.Null);
            Assert.That(prototype.BaseNames, Is.EqualTo(baseNames));
            Assert.That(prototype.Name, Is.EqualTo("specific gear"));
            Assert.That(prototype.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(prototype.IsMagical, Is.True);
        }

        [TestCase(ItemTypeConstants.Armor, ItemTypeConstants.Armor)]
        [TestCase(AttributeConstants.Shield, ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Weapon, ItemTypeConstants.Weapon)]
        public void CorrectItemType(string gearType, string itemType)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, gearType);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(selection);

            var prototype = specificGearGenerator.GenerateRandomPrototypeFrom(power, gearType);
            Assert.That(prototype.ItemType, Is.EqualTo(itemType));
        }

        [Test]
        public void ReturnMundanePrototype()
        {
            selection.Amount = 0;

            var prototype = specificGearGenerator.GenerateRandomPrototypeFrom(power, gearType);
            Assert.That(prototype, Is.Not.Null);
            Assert.That(prototype.BaseNames, Is.EqualTo(baseNames));
            Assert.That(prototype.Name, Is.EqualTo("specific gear"));
            Assert.That(prototype.Magic.Bonus, Is.EqualTo(0));
            Assert.That(prototype.IsMagical, Is.False);
        }

        [Test]
        public void MagicGearIsMasterwork()
        {
            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.IsMagical, Is.True);
            Assert.That(gear.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(gear.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void SpecificallyMasterworkMagicGearIsMasterwork()
        {
            var traits = new[] { "trait 1", "trait 2", TraitConstants.Masterwork };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(traits);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.IsMagical, Is.True);
            Assert.That(gear.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(gear.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void NonMagicGearIsNotMasterwork()
        {
            template.Magic.Bonus = 0;

            var traits = new[] { "trait 1", "trait 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(traits);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.IsMagical, Is.False);
            Assert.That(gear.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
        }

        [Test]
        public void NonMagicSpecificallyMasterworkGearIsMasterwork()
        {
            template.Magic.Bonus = 0;

            var traits = new[] { "trait 1", "trait 2", TraitConstants.Masterwork };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(traits);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.IsMagical, Is.False);
            Assert.That(gear.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetTraitsFromSelector()
        {
            var traits = new[] { "trait 1", "trait 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(traits);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Traits, Is.SupersetOf(traits));
        }

        [Test]
        public void GetSpecificArmor()
        {
            template.ItemType = ItemTypeConstants.Armor;

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(attributes);

            var traits = new[] { "trait 1", "trait 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(traits);

            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(specialAbilityNames);

            var specialAbilities = new[]
            {
                new SpecialAbility(),
                new SpecialAbility()
            };

            mockSpecialAbilitiesGenerator.Setup(s => s.GenerateFor(
                It.Is<IEnumerable<SpecialAbility>>(aa =>
                    aa.First().Name == "ability 1"
                    && aa.Last().Name == "ability 2")
                )
            ).Returns(specialAbilities);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Name, Is.EqualTo(selection.Type));
            Assert.That(gear.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.SupersetOf(traits));
            Assert.That(gear.Magic.Bonus, Is.EqualTo(selection.Amount));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
            Assert.That(gear, Is.InstanceOf<Armor>());

            var armor = gear as Armor;
            Assert.That(armor.ArmorBonus, Is.EqualTo(mundaneArmor.ArmorBonus));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(mundaneArmor.ArmorCheckPenalty));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(mundaneArmor.MaxDexterityBonus));
            Assert.That(armor.Size, Is.EqualTo(mundaneArmor.Size));
        }

        [Test]
        public void GetSpecificWeapon()
        {
            mockCollectionsSelector.Setup(s => s.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>(), AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon))
                .Returns(ItemTypeConstants.Weapon);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Armor)).Returns(() => new[] { "wrong name" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Weapon)).Returns(() => new[] { template.Name });

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(attributes);

            var traits = new[] { "trait 1", "trait 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(traits);

            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(specialAbilityNames);

            var specialAbilities = new[]
            {
                new SpecialAbility(),
                new SpecialAbility()
            };

            mockSpecialAbilitiesGenerator.Setup(s => s.GenerateFor(
                It.Is<IEnumerable<SpecialAbility>>(aa =>
                    aa.First().Name == "ability 1"
                    && aa.Last().Name == "ability 2")
                )
            ).Returns(specialAbilities);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear, Is.Not.EqualTo(template));
            Assert.That(gear.Name, Is.EqualTo(template.Name));
            Assert.That(gear.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.SupersetOf(traits));
            Assert.That(gear.Magic.Bonus, Is.EqualTo(selection.Amount));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
            Assert.That(gear, Is.InstanceOf<Weapon>());

            var weapon = gear as Weapon;
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Quantity, Is.EqualTo(mundaneWeapon.Quantity));
            Assert.That(mundaneWeapon.Quantity, Is.AtLeast(2));
        }

        [Test]
        public void GetSpecificWeaponFromWeapon()
        {
            mockCollectionsSelector.Setup(s => s.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>(), AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon))
                .Returns(ItemTypeConstants.Weapon);

            var weaponTemplate = new Weapon();
            template.CloneInto(weaponTemplate);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Armor)).Returns(() => new[] { "wrong name" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Weapon)).Returns(() => new[] { weaponTemplate.Name });

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, weaponTemplate.Name)).Returns(attributes);

            var traits = new[] { "trait 1", "trait 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, weaponTemplate.Name)).Returns(traits);

            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, weaponTemplate.Name)).Returns(specialAbilityNames);

            var specialAbilities = new[]
            {
                new SpecialAbility(),
                new SpecialAbility()
            };

            mockSpecialAbilitiesGenerator.Setup(s => s.GenerateFor(
                It.Is<IEnumerable<SpecialAbility>>(aa =>
                    aa.First().Name == "ability 1"
                    && aa.Last().Name == "ability 2")
                )
            ).Returns(specialAbilities);

            var gear = specificGearGenerator.GenerateFrom(weaponTemplate);
            Assert.That(gear, Is.Not.EqualTo(weaponTemplate));
            Assert.That(gear, Is.Not.EqualTo(template));
            Assert.That(gear.Name, Is.EqualTo(weaponTemplate.Name));
            Assert.That(gear.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.SupersetOf(traits));
            Assert.That(gear.Magic.Bonus, Is.EqualTo(selection.Amount));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
            Assert.That(gear, Is.InstanceOf<Weapon>());

            var weapon = gear as Weapon;
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Quantity, Is.EqualTo(mundaneWeapon.Quantity));
            Assert.That(mundaneWeapon.Quantity, Is.AtLeast(2));
        }

        [Test]
        public void JavelinOfLightningIsMagical()
        {
            template.Name = WeaponConstants.JavelinOfLightning;

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.IsMagical, Is.True);
        }

        [Test]
        public void GetSpecialAbilities()
        {
            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(specialAbilityNames);

            var specialAbilities = new[]
            {
                new SpecialAbility(),
                new SpecialAbility()
            };

            mockSpecialAbilitiesGenerator.Setup(s => s.GenerateFor(
                It.Is<IEnumerable<SpecialAbility>>(aa =>
                    aa.First().Name == "ability 1"
                    && aa.Last().Name == "ability 2")
                )
            ).Returns(specialAbilities);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
        }

        [Test]
        public void IfCharged_GetChargesFromGenerator()
        {
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Armor, template.Name)).Returns(9266);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void IfNotCharged_DoNotGetChargesFromGenerator()
        {
            var attributes = new[] { "not charged" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, template.Name)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Armor, template.Name)).Returns(9266);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Magic.Charges, Is.EqualTo(0));
        }

        [TestCase(WeaponConstants.SilverDagger, WeaponConstants.Dagger)]
        [TestCase(WeaponConstants.LuckBlade0, WeaponConstants.LuckBlade)]
        [TestCase(WeaponConstants.LuckBlade1, WeaponConstants.LuckBlade)]
        [TestCase(WeaponConstants.LuckBlade2, WeaponConstants.LuckBlade)]
        [TestCase(WeaponConstants.LuckBlade3, WeaponConstants.LuckBlade)]
        public void SpecificGearIsRenamed(string originalName, string newName)
        {
            template.Name = originalName;
            template.ItemType = ItemTypeConstants.Weapon;

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Name, Is.EqualTo(newName));
        }

        [Test]
        public void CastersShieldHasNoSpellIfSelectorSaysSo()
        {
            mockCollectionsSelector.Setup(s => s.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>(), AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon))
                .Returns(AttributeConstants.Shield);

            template.Name = ArmorConstants.CastersShield;

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes)).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Medium)).Returns(42);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 42)).Returns("spell");
            mockPercentileSelector.Setup(s => s.SelectFrom<bool>(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell)).Returns(false);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Name, Is.EqualTo(ArmorConstants.CastersShield));
            Assert.That(gear.Contents, Is.Empty);
        }

        [Test]
        public void CastersShieldHasSpellIfSelectorSaysSo()
        {
            mockCollectionsSelector.Setup(s => s.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>(), AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon))
                .Returns(AttributeConstants.Shield);

            template.Name = ArmorConstants.CastersShield;

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes)).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Medium)).Returns(42);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 42)).Returns("spell");
            mockPercentileSelector.Setup(s => s.SelectFrom<bool>(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell)).Returns(true);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Name, Is.EqualTo(ArmorConstants.CastersShield));
            Assert.That(gear.Contents, Contains.Item("spell (spell type, 42)"));
        }

        [Test]
        public void SlayingArrowHasDesignatedFoe()
        {
            template.Name = WeaponConstants.SlayingArrow;
            template.ItemType = ItemTypeConstants.Weapon;

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes)).Returns("foe");

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.SlayingArrow));
            Assert.That(gear.Traits, Contains.Item("Designated Foe: foe"));
        }

        [Test]
        public void GreaterSlayingArrowHasDesignatedFoe()
        {
            template.Name = WeaponConstants.GreaterSlayingArrow;
            template.ItemType = ItemTypeConstants.Weapon;

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes)).Returns("foe");

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.GreaterSlayingArrow));
            Assert.That(gear.Traits, Contains.Item("Designated Foe: foe"));
        }

        [Test]
        public void TemplateIsSpecific()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specificItems = new[] { "other item", name };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Specific)).Returns(specificItems);

            var isSpecific = specificGearGenerator.IsSpecific(template);
            Assert.That(isSpecific, Is.True);
        }

        [Test]
        public void TemplateIsNotSpecific()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specificItems = new[] { "other item", "item" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Specific)).Returns(specificItems);

            var isSpecific = specificGearGenerator.IsSpecific(template);
            Assert.That(isSpecific, Is.False);
        }

        [Test]
        public void GenerateCustomSpecificShield()
        {
            mockCollectionsSelector.Setup(s => s.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>(), AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon))
                .Returns(AttributeConstants.Shield);

            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, AttributeConstants.Shield);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(attributes);

            var traits = new[] { "trait 1", "trait 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, AttributeConstants.Shield);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(traits);

            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, AttributeConstants.Shield);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(specialAbilityNames);

            var specialAbilities = new[]
            {
                new SpecialAbility { Name = template.Magic.SpecialAbilities.First().Name },
                new SpecialAbility { Name = template.Magic.SpecialAbilities.Last().Name }
            };

            mockSpecialAbilitiesGenerator.Setup(s =>
                s.GenerateFor(
                    It.Is<IEnumerable<SpecialAbility>>(aa =>
                        aa.First().Name == "ability 1"
                        && aa.Last().Name == "ability 2"
                    )
                )
            ).Returns(specialAbilities);

            mockMundaneArmorGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == name), false)).Returns(mundaneArmor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(gear, template);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.SupersetOf(traits));
            Assert.That(gear.Traits, Is.SupersetOf(template.Traits));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
            Assert.That(gear.BaseNames, Is.EquivalentTo(baseNames));
        }

        [Test]
        public void GenerateCustomSpecificArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var shields = new[] { "other shield", "shield" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Shield)).Returns(shields);

            var armors = new[] { "other armor", name };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Armor)).Returns(armors);

            var weapons = new[] { "other weapon", "weapon" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Weapon)).Returns(weapons);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(attributes);

            var traits = new[] { "trait 1", "trait 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(traits);

            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(specialAbilityNames);

            var specialAbilities = new[]
            {
                new SpecialAbility { Name = template.Magic.SpecialAbilities.First().Name },
                new SpecialAbility { Name = template.Magic.SpecialAbilities.Last().Name }
            };

            mockSpecialAbilitiesGenerator.Setup(s =>
                s.GenerateFor(
                    It.Is<IEnumerable<SpecialAbility>>(aa =>
                        aa.First().Name == "ability 1"
                        && aa.Last().Name == "ability 2"
                    )
                )
            ).Returns(specialAbilities);

            mockMundaneArmorGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == name), false)).Returns(mundaneArmor);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(gear, template);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.SupersetOf(traits));
            Assert.That(gear.Traits, Is.SupersetOf(template.Traits));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
            Assert.That(gear.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(gear, Is.InstanceOf<Armor>());

            var armor = gear as Armor;
            Assert.That(armor.ArmorBonus, Is.EqualTo(mundaneArmor.ArmorBonus));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(mundaneArmor.ArmorCheckPenalty));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(mundaneArmor.MaxDexterityBonus));
            Assert.That(armor.Size, Is.EqualTo(mundaneArmor.Size));
        }

        [Test]
        public void GenerateCustomSpecificWeapon()
        {
            mockCollectionsSelector.Setup(s => s.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>(), AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon))
                .Returns(ItemTypeConstants.Weapon);

            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(attributes);

            var traits = new[] { "trait 1", "trait 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(traits);

            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(specialAbilityNames);

            var specialAbilities = new[]
            {
                new SpecialAbility { Name = template.Magic.SpecialAbilities.First().Name },
                new SpecialAbility { Name = template.Magic.SpecialAbilities.Last().Name }
            };

            mockSpecialAbilitiesGenerator.Setup(s =>
                s.GenerateFor(
                    It.Is<IEnumerable<SpecialAbility>>(aa =>
                        aa.First().Name == "ability 1"
                        && aa.Last().Name == "ability 2"
                    )
                )
            ).Returns(specialAbilities);

            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == name), false)).Returns(mundaneWeapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(gear, template);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.SupersetOf(traits));
            Assert.That(gear.Traits, Is.SupersetOf(template.Traits));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
            Assert.That(gear.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(gear, Is.InstanceOf<Weapon>());

            var weapon = gear as Weapon;
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Quantity, Is.EqualTo(mundaneWeapon.Quantity));
            Assert.That(mundaneWeapon.Quantity, Is.AtLeast(2));
        }

        [Test]
        public void GenerateCustomSpecificAmmunition()
        {
            mockCollectionsSelector.Setup(s => s.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>(), AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon))
                .Returns(ItemTypeConstants.Weapon);

            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2", AttributeConstants.Ammunition };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(attributes);

            var traits = new[] { "trait 1", "trait 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(traits);

            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(specialAbilityNames);

            var specialAbilities = new[]
            {
                new SpecialAbility { Name = template.Magic.SpecialAbilities.First().Name },
                new SpecialAbility { Name = template.Magic.SpecialAbilities.Last().Name }
            };

            mockSpecialAbilitiesGenerator.Setup(s =>
                s.GenerateFor(
                    It.Is<IEnumerable<SpecialAbility>>(aa =>
                        aa.First().Name == "ability 1"
                        && aa.Last().Name == "ability 2"
                    )
                )
            ).Returns(specialAbilities);

            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == name), false)).Returns(mundaneWeapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.SupersetOf(traits));
            Assert.That(gear.Traits, Is.SupersetOf(template.Traits));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
            Assert.That(gear.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(gear, Is.InstanceOf<Weapon>());
            Assert.That(gear.Magic.Intelligence.Ego, Is.EqualTo(0));

            var weapon = gear as Weapon;
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Quantity, Is.EqualTo(mundaneWeapon.Quantity));
            Assert.That(mundaneWeapon.Quantity, Is.AtLeast(2));
        }

        [Test]
        public void GenerateCustomSpecificOneTimeUseWeapon()
        {
            mockCollectionsSelector.Setup(s => s.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, It.IsAny<string>(), AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon))
                .Returns(ItemTypeConstants.Weapon);

            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "attribute 1", "attribute 2", AttributeConstants.OneTimeUse };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(attributes);

            var traits = new[] { "trait 1", "trait 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(traits);

            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, name)).Returns(specialAbilityNames);

            var specialAbilities = new[]
            {
                new SpecialAbility { Name = template.Magic.SpecialAbilities.First().Name },
                new SpecialAbility { Name = template.Magic.SpecialAbilities.Last().Name }
            };

            mockSpecialAbilitiesGenerator.Setup(s =>
                s.GenerateFor(
                    It.Is<IEnumerable<SpecialAbility>>(aa =>
                        aa.First().Name == "ability 1"
                        && aa.Last().Name == "ability 2"
                    )
                )
            ).Returns(specialAbilities);

            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == name), false)).Returns(mundaneWeapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(template);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.SupersetOf(traits));
            Assert.That(gear.Traits, Is.SupersetOf(template.Traits));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
            Assert.That(gear.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(gear, Is.InstanceOf<Weapon>());
            Assert.That(gear.Magic.Intelligence.Ego, Is.EqualTo(0));

            var weapon = gear as Weapon;
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Quantity, Is.EqualTo(mundaneWeapon.Quantity));
            Assert.That(mundaneWeapon.Quantity, Is.AtLeast(2));
        }
    }
}