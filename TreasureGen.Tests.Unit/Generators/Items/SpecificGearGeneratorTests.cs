using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class SpecificGearGeneratorTests
    {
        private ISpecificGearGenerator specificGearGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<IArmorDataSelector> mockArmorDataSelector;
        private TypeAndAmountSelection selection;
        private string power;
        private string gearType;
        private Mock<Dice> mockDice;
        private ItemVerifier itemVerifier;
        private List<string> baseNames;
        private ArmorSelection armorSelection;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockDice = new Mock<Dice>();
            mockArmorDataSelector = new Mock<IArmorDataSelector>();
            specificGearGenerator = new SpecificGearGenerator(
                mockTypeAndAmountPercentileSelector.Object,
                mockCollectionsSelector.Object,
                mockChargesGenerator.Object,
                mockPercentileSelector.Object,
                mockSpellGenerator.Object,
                mockBooleanPercentileSelector.Object,
                mockDice.Object,
                mockSpecialAbilitiesGenerator.Object,
                mockArmorDataSelector.Object);
            selection = new TypeAndAmountSelection();
            itemVerifier = new ItemVerifier();

            power = "power";
            gearType = "gear type";

            selection.Type = "specific gear";
            selection.Amount = 1;
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<string>())).Returns(selection);

            baseNames = new List<string> { "base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            armorSelection = new ArmorSelection();
            armorSelection.ArmorBonus = 9266;
            armorSelection.ArmorCheckPenalty = -90210;
            armorSelection.MaxDexterityBonus = 42;

            mockArmorDataSelector.Setup(s => s.Select(baseNames[0])).Returns(armorSelection);
        }

        [Test]
        public void ReturnGear()
        {
            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear, Is.Not.Null);
        }

        [TestCase(ItemTypeConstants.Armor, ItemTypeConstants.Armor)]
        [TestCase(AttributeConstants.Shield, ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Weapon, ItemTypeConstants.Weapon)]
        public void CorrectItemType(string gearType, string itemType)
        {
            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.ItemType, Is.EqualTo(itemType));
        }

        [Test]
        public void GetGearNameAndBonusFromSelector()
        {
            var newResult = new TypeAndAmountSelection();
            newResult.Type = "new specific gear";
            newResult.Amount = 42;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, gearType);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(newResult);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, newResult.Type)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo("new specific gear"));
            Assert.That(gear.Magic.Bonus, Is.EqualTo(42));
        }

        [Test]
        public void GetBaseNames()
        {
            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GetMundaneGearNameAndBonusFromSelector()
        {
            var newResult = new TypeAndAmountSelection();
            newResult.Type = "new specific gear";
            newResult.Amount = 0;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, gearType);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(newResult);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, newResult.Type)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo("new specific gear"));
            Assert.That(gear.IsMagical, Is.False);
        }

        [Test]
        public void MagicGearIsMasterwork()
        {
            var traits = new[] { "trait 1", "trait 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(traits);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void SpecificMagicGearIsMasterwork()
        {
            var traits = new[] { "trait 1", "trait 2", TraitConstants.Masterwork };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(traits);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void NonMagicGearIsNotMasterwork()
        {
            var traits = new[] { "trait 1", "trait 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(traits);

            selection.Amount = 0;
            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
        }

        [Test]
        public void NonMagicSpecificGearIsMasterwork()
        {
            var traits = new[] { "trait 1", "trait 2", TraitConstants.Masterwork };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(traits);

            selection.Amount = 0;
            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetArmorProperties()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear, Is.InstanceOf<Armor>());

            var armor = gear as Armor;
            Assert.That(armor.ArmorBonus, Is.EqualTo(9266));
            Assert.That(armor.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(armor.MaxDexterityBonus, Is.EqualTo(42));
            Assert.That(armor.Size, Is.EqualTo("size"));
        }

        [Test]
        public void JavelinOfLightningIsMagical()
        {
            selection.Type = WeaponConstants.JavelinOfLightning;
            var gear = specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);
            Assert.That(gear.IsMagical, Is.True);
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetTraitsFromSelector()
        {
            var traits = new[] { "trait 1", "trait 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(traits);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Traits, Is.SupersetOf(traits));
        }

        [Test]
        public void GetSpecialAbilities()
        {
            var specialAbilityNames = new[] { "ability 1", "ability 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(specialAbilityNames);

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

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
        }

        [Test]
        public void IfCharged_GetChargesFromGenerator()
        {
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(gearType, selection.Type)).Returns(9266);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void IfNotCharged_DoNotGetChargesFromGenerator()
        {
            var attributes = new[] { "not charged" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, gearType);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(gearType, selection.Type)).Returns(9266);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void SilverDaggerRenamedDagger()
        {
            selection.Type = WeaponConstants.SilverDagger;
            var gear = specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.Dagger));
        }

        [TestCase(WeaponConstants.LuckBlade0)]
        [TestCase(WeaponConstants.LuckBlade1)]
        [TestCase(WeaponConstants.LuckBlade2)]
        [TestCase(WeaponConstants.LuckBlade3)]
        public void LuckBladeWithChargeRenamedLuckBlade(string luckBlade)
        {
            selection.Type = luckBlade;
            var gear = specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.LuckBlade));
        }

        [Test]
        public void CastersShieldHasNoSpellIfSelectorSaysSo()
        {
            selection.Type = ArmorConstants.CastersShield;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes)).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Medium)).Returns(42);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 42)).Returns("spell");
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell)).Returns(false);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo(ArmorConstants.CastersShield));
            Assert.That(gear.Contents, Is.Empty);
        }

        [Test]
        public void CastersShieldHasSpellIfSelectorSaysSo()
        {
            selection.Type = ArmorConstants.CastersShield;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes)).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Medium)).Returns(42);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 42)).Returns("spell");
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell)).Returns(true);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo(ArmorConstants.CastersShield));
            Assert.That(gear.Contents, Contains.Item("spell (spell type, 42)"));
        }

        [Test]
        public void SlayingArrowHasDesignatedFoe()
        {
            selection.Type = WeaponConstants.SlayingArrow;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes)).Returns("foe");

            var gear = specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.SlayingArrow));
            Assert.That(gear.Traits, Contains.Item("Designated Foe: foe"));
        }

        [Test]
        public void GreaterSlayingArrowHasDesignatedFoe()
        {
            selection.Type = WeaponConstants.GreaterSlayingArrow;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes)).Returns("foe");

            var gear = specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.GreaterSlayingArrow));
            Assert.That(gear.Traits, Contains.Item("Designated Foe: foe"));
        }

        [Test]
        public void SpecificAmmunitionReceivesQuantity()
        {
            var attributes = new[] { "attribute 1", AttributeConstants.Ammunition };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, "specific gear")).Returns(attributes);

            mockDice.Setup(d => d.Roll(1).d(50).AsSum()).Returns(9266);

            var gear = specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);
            Assert.That(gear.Quantity, Is.EqualTo(9266));
        }

        [Test]
        public void SpecificThrownWeaponsReceiveQuantity()
        {
            var attributes = new[] { "attribute 1", AttributeConstants.Thrown };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, "specific gear")).Returns(attributes);
            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(9266);

            var gear = specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);
            Assert.That(gear.Quantity, Is.EqualTo(9266));
        }

        [Test]
        public void SpecificMeleeThrownWeaponsReceiveQuantityOf1()
        {
            var attributes = new[] { "attribute 1", AttributeConstants.Thrown, AttributeConstants.Melee };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, "specific gear")).Returns(attributes);
            mockDice.Setup(d => d.Roll(1).d(20).AsSum()).Returns(9266);

            var gear = specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);
            Assert.That(gear.Quantity, Is.EqualTo(1));
        }

        //INFO: This has to be a weapon for now because armor handles sizes differently
        [Test]
        public void NonMagicalGearGetsSize()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var newResult = new TypeAndAmountSelection();
            newResult.Type = "new specific gear";
            newResult.Amount = 0;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(newResult);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, newResult.Type)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);
            Assert.That(gear.Name, Is.EqualTo("new specific gear"));
            Assert.That(gear.IsMagical, Is.False);
            Assert.That(gear.Traits, Contains.Item("size"));
        }

        [Test]
        public void MagicalGearDoesNotGetSize()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes)).Returns("size");

            var newResult = new TypeAndAmountSelection();
            newResult.Type = "new specific gear";
            newResult.Amount = 1;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, gearType);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(newResult);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, newResult.Type)).Returns(baseNames);

            var gear = specificGearGenerator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo("new specific gear"));
            Assert.That(gear.IsMagical, Is.True);
            Assert.That(gear.Traits, Is.Not.Contains("size"));
        }

        [Test]
        public void TemplateIsSpecific()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specificItems = new[] { "other item", name };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Specific)).Returns(specificItems);

            var isSpecific = specificGearGenerator.TemplateIsSpecific(template);
            Assert.That(isSpecific, Is.True);
        }

        [Test]
        public void TemplateIsNotSpecific()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specificItems = new[] { "other item", "item" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Specific)).Returns(specificItems);

            var isSpecific = specificGearGenerator.TemplateIsSpecific(template);
            Assert.That(isSpecific, Is.False);
        }

        [Test]
        public void GenerateCustomSpecificShield()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var shields = new[] { "other shield", name };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Shield)).Returns(shields);

            var armors = new[] { "other armor", "armor" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Armor)).Returns(armors);

            var weapons = new[] { "other weapon", "weapon" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Weapon)).Returns(weapons);

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

            var gear = specificGearGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(gear, template);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.EquivalentTo(traits.Union(template.Traits)));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
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

            var gear = specificGearGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(gear, template);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.EquivalentTo(traits.Union(template.Traits)));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
        }

        [Test]
        public void GenerateCustomSpecificWeapon()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var shields = new[] { "other shield", "shield" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Shield)).Returns(shields);

            var armors = new[] { "other armor", "armor" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Armor)).Returns(armors);

            var weapons = new[] { "other weapon", name };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Weapon)).Returns(weapons);

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

            var gear = specificGearGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(gear, template);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.EquivalentTo(traits.Union(template.Traits)));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
        }

        [Test]
        public void GenerateCustomSpecificAmmunition()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var shields = new[] { "other shield", "shield" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Shield)).Returns(shields);

            var armors = new[] { "other armor", "armor" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Armor)).Returns(armors);

            var weapons = new[] { "other weapon", name };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Weapon)).Returns(weapons);

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

            var gear = specificGearGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(gear, template);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
            Assert.That(gear.Traits, Is.EquivalentTo(traits.Union(template.Traits)));
            Assert.That(gear.Magic.SpecialAbilities, Is.EqualTo(specialAbilities));
        }
    }
}