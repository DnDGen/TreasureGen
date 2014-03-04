using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorTests
    {
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private Mock<ISpecialAbilityDataProvider> mockSpecialAbilityDataProvider;
        private Mock<IAttributesProvider> mockTypesProvider;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IDice> mockDice;
        private Mock<ISpellGenerator> mockSpellGenerator;

        private List<String> types;

        [SetUp]
        public void Setup()
        {
            types = new List<String>();
            types.Add(ItemTypeConstants.Armor);

            mockSpecialAbilityDataProvider = new Mock<ISpecialAbilityDataProvider>();
            mockTypesProvider = new Mock<IAttributesProvider>();
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockDice = new Mock<IDice>();
            mockSpellGenerator = new Mock<ISpellGenerator>();

            specialAbilitiesGenerator = new SpecialAbilitiesGenerator(mockSpecialAbilityDataProvider.Object,
                mockTypesProvider.Object, mockPercentileResultProvider.Object, mockDice.Object, mockSpellGenerator.Object);
        }

        [Test]
        public void ReturnEmptyIfBonusLessThanOne()
        {
            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 0, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void GetShieldAbilityIfShield()
        {
            types.Add(AttributeConstants.Shield);
            var shieldAbility = CreateSpecialAbility("shield ability");

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerShieldSpecialAbilities")).Returns(shieldAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(shieldAbility.Name)).Returns(shieldAbility);

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability, Is.EqualTo(shieldAbility));
        }

        [Test]
        public void GetMeleeWeaponAbilityIfMeleeWeapon()
        {
            types.Add(AttributeConstants.Melee);
            var meleeWeaponAbility = CreateSpecialAbility("melee weapon ability");

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerMeleeWeaponSpecialAbilities")).Returns(meleeWeaponAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(meleeWeaponAbility.Name)).Returns(meleeWeaponAbility);

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability, Is.EqualTo(meleeWeaponAbility));
        }

        [Test]
        public void GetRangedWeaponAbilityIfRangedWeapon()
        {
            types.Add(AttributeConstants.Ranged);
            var rangedWeaponAbility = CreateSpecialAbility("ranged weapon ability");

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRangedWeaponSpecialAbilities")).Returns(rangedWeaponAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(rangedWeaponAbility.Name)).Returns(rangedWeaponAbility);

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability, Is.EqualTo(rangedWeaponAbility));
        }

        [Test]
        public void GetArmorAbilityIfArmor()
        {
            var armorAbility = CreateSpecialAbility("armor ability");

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerArmorSpecialAbilities")).Returns(armorAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(armorAbility.Name)).Returns(armorAbility);

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability.Name, Is.EqualTo(armorAbility.Name));
        }

        [Test]
        public void ThrowErrorIfNotValidTypes()
        {
            Assert.That(() => specialAbilitiesGenerator.GenerateFor(new[] { "invalid type" }, "power"), Throws.ArgumentException);
        }

        [Test]
        public void SetAbilityByResult()
        {
            var abilityResult = new SpecialAbility();
            abilityResult.BonusEquivalent = 92;
            abilityResult.CoreName = "core name";
            abilityResult.Name = "name";
            abilityResult.Strength = 66;
            abilityResult.AttributeRequirements = types;

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerArmorSpecialAbilities")).Returns(abilityResult.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(abilityResult.Name)).Returns(abilityResult);

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability, Is.EqualTo(abilityResult));
        }

        [Test]
        public void GetAbilities()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            ability1.BonusEquivalent = 1;
            var ability2 = CreateSpecialAbility("ability 2");
            ability2.BonusEquivalent = 2;
            var ability3 = CreateSpecialAbility("ability 3");
            ability3.BonusEquivalent = 3;

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(ability1)
                .Returns(ability2).Returns(ability3);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 3);
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability3));
            Assert.That(abilities.Count(), Is.EqualTo(3));
        }

        private SpecialAbility CreateSpecialAbility(String name)
        {
            var ability = new SpecialAbility();
            ability.Name = name;
            ability.CoreName = name;
            ability.AttributeRequirements = types;
            return ability;
        }

        [Test]
        public void DoNotAllowAbilitiesAndMagicBonusToBeGreaterThan10()
        {
            var bigAbility = CreateSpecialAbility("big ability");
            bigAbility.BonusEquivalent = 2;
            var smallAbility = CreateSpecialAbility("small ability");
            smallAbility.BonusEquivalent = 1;

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(bigAbility)
                .Returns(smallAbility);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 9, 1);
            Assert.That(abilities, Contains.Item(smallAbility));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void AccumulateAbilities()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            ability1.BonusEquivalent = 1;
            var ability2 = CreateSpecialAbility("ability 2");
            ability2.BonusEquivalent = 2;
            var ability3 = CreateSpecialAbility("ability 3");
            ability3.BonusEquivalent = 3;
            var ability4 = CreateSpecialAbility("ability 4");
            ability4.BonusEquivalent = 0;

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(ability1)
                .Returns(ability2).Returns(ability3).Returns(ability4);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 5, 3);
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability4));
            Assert.That(abilities.Count(), Is.EqualTo(3));
        }

        [Test]
        public void ReplaceWeakWithStrong()
        {
            var strongAbility = CreateSpecialAbility("strong ability");
            strongAbility.CoreName = "ability";
            strongAbility.Strength = 2;
            var weakAbility = CreateSpecialAbility("weak ability");
            weakAbility.CoreName = "ability";
            weakAbility.Strength = 1;

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(weakAbility)
                .Returns(strongAbility);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 2);
            Assert.That(abilities, Contains.Item(strongAbility));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void DoNotReplaceStrongWithWeak()
        {
            var strongAbility = CreateSpecialAbility("strong ability");
            strongAbility.CoreName = "ability";
            strongAbility.Strength = 2;
            var weakAbility = CreateSpecialAbility("weak ability");
            weakAbility.CoreName = "ability";
            weakAbility.Strength = 1;
            var otherAbility = CreateSpecialAbility("other ability");

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(strongAbility)
                .Returns(weakAbility).Returns(otherAbility);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 2);
            Assert.That(abilities, Contains.Item(strongAbility));
            Assert.That(abilities, Is.Not.Contains(weakAbility));
        }

        [Test]
        public void AbilitiesMaxOutAtBonusOf10()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            ability1.BonusEquivalent = 3;
            var ability2 = CreateSpecialAbility("ability 2");
            ability2.BonusEquivalent = 3;
            var ability3 = CreateSpecialAbility("ability 3");
            ability3.BonusEquivalent = 3;
            var ability4 = CreateSpecialAbility("ability 4");
            ability4.BonusEquivalent = 1;

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(ability1)
                .Returns(ability2).Returns(ability3).Returns(ability4);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 4);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item(ability1.Name));
            Assert.That(names, Contains.Item(ability2.Name));
            Assert.That(names, Contains.Item(ability3.Name));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void DuplicateAbilitiesCannotBeAdded()
        {
            var ability = CreateSpecialAbility("ability");
            var otherAbility = CreateSpecialAbility("other ability");

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(ability)
                .Returns(ability).Returns(otherAbility);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item(ability.Name));
            Assert.That(names, Contains.Item(otherAbility.Name));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void AbilitiesFilteredByTypeRequirementsFromCoreName()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            ability1.CoreName = "core ability 1";
            ability1.AttributeRequirements = new[] { "other type", "type 1" };

            types.Add("type 1");
            types.Add("type 2");
            var ability2 = CreateSpecialAbility("ability 2");
            ability2.CoreName = "core ability 2";
            ability2.AttributeRequirements = types;

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(ability1)
                .Returns(ability2);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 1);
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ExtraTypesDoNotMatter()
        {
            var ability = CreateSpecialAbility("ability");
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(ability);

            types.Add("type 1");
            mockTypesProvider.Setup(p => p.GetAttributesFor(ability.Name, "SpecialAbilityTypes")).Returns(types);
            var inputTypes = types.Union(new[] { "other type" });

            var abilities = specialAbilitiesGenerator.GenerateFor(inputTypes, "power", 1, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(ability.Name));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void BonusSpecialAbilitiesAdded()
        {
            var bonusAbility = CreateSpecialAbility("BonusSpecialAbility");
            var ability1 = CreateSpecialAbility("ability 1");
            var ability2 = CreateSpecialAbility("ability 2");

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(bonusAbility)
                .Returns(ability1).Returns(ability2);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 1);
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities.Count(), Is.EqualTo(2));
        }

        [Test]
        public void BonusSpecialAbilityAbilityIsEmptyExceptForName()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerArmorSpecialAbilities")).Returns("BonusSpecialAbility");

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability.Name, Is.EqualTo("BonusSpecialAbility"));
            Assert.That(ability.AttributeRequirements, Is.Empty);
            Assert.That(ability.BonusEquivalent, Is.EqualTo(0));
            Assert.That(ability.CoreName, Is.Null.Or.Empty);
            Assert.That(ability.Strength, Is.EqualTo(0));
        }

        [Test]
        public void BaneAbilityGetsDesignatedFoe()
        {
            var bane = CreateSpecialAbility("Bane");
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(bane);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("DesignatedFoes")).Returns("designated foe");

            var result = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(result.CoreName, Is.EqualTo(bane.CoreName));
            Assert.That(result.Name, Is.EqualTo("designated foebane"));
        }

        [Test]
        public void SpellStoringAbilityDoesNotHaveSpellIfBelow51()
        {
            var spellStoring = CreateSpecialAbility("Spell storing");
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(spellStoring);
            mockSpellGenerator.Setup(g => g.GenerateOfTypeAtLevel(It.IsAny<String>(), It.IsAny<Int32>())).Returns("spell");

            for (var roll = 1; roll < 51; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var result = specialAbilitiesGenerator.GenerateFor(types, "power");
                Assert.That(result, Is.EqualTo(spellStoring));
                Assert.That(result.Name, Is.EqualTo("Spell storing"));
            }
        }

        [Test]
        public void SpellStoringAbilityHasSpellIfAbove50()
        {
            var spellStoring = CreateSpecialAbility("Spell storing");
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(spellStoring);
            mockSpellGenerator.Setup(g => g.GenerateOfTypeAtLevel(It.IsAny<String>(), It.IsAny<Int32>())).Returns("spell");

            for (var roll = 51; roll <= 100; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var result = specialAbilitiesGenerator.GenerateFor(types, "power");
                Assert.That(result, Is.EqualTo(spellStoring));
                Assert.That(result.Name, Is.EqualTo("Spell storing (contains spell)"));
            }
        }

        [Test]
        public void SpellStoringAbilityGetsTypeAndLevelOfSpell()
        {
            var spellStoring = CreateSpecialAbility("Spell storing");
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(spellStoring);
            mockDice.Setup(d => d.Percentile(1)).Returns(100);

            mockDice.Setup(d => d.d3(1)).Returns(9266);
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateOfTypeAtLevel("spell type", 9266)).Returns("spell");

            var result = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(result, Is.EqualTo(spellStoring));
            Assert.That(result.Name, Is.EqualTo("Spell storing (contains spell)"));
        }

        [Test]
        public void StopIfAllPossibleAbilitiesAcquired()
        {
            Assert.Fail();
        }

        [Test]
        public void ReturnEmptyIfNoCompatibleAbilities()
        {
            Assert.Fail();
        }
    }
}