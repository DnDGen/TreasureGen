using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorTests
    {
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IDice> mockDice;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<ISpecialAbilityAttributesSelector> mockSpecialAbilityAttributesSelector;

        private List<String> attributes;

        [SetUp]
        public void Setup()
        {
            attributes = new List<String>();
            attributes.Add(ItemTypeConstants.Armor);

            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<IDice>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockSpecialAbilityAttributesSelector = new Mock<ISpecialAbilityAttributesSelector>();

            specialAbilitiesGenerator = new SpecialAbilitiesGenerator(mockAttributesSelector.Object, mockPercentileSelector.Object,
                mockDice.Object, mockSpellGenerator.Object, mockSpecialAbilityAttributesSelector.Object);
        }

        [Test]
        public void ReturnEmptyIfBonusLessThanOne()
        {
            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 0, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void GetShieldAbilityIfShield()
        {
            attributes.Add(AttributeConstants.Shield);
            specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            mockPercentileSelector.Verify(s => s.SelectAllFrom("powerShieldSpecialAbilities"), Times.Once);
        }

        [Test]
        public void GetMeleeWeaponAbilityIfMeleeWeapon()
        {
            attributes.Add(AttributeConstants.Melee);
            specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            mockPercentileSelector.Verify(s => s.SelectAllFrom("powerMeleeWeaponSpecialAbilities"), Times.Once);
        }

        [Test]
        public void GetRangedWeaponAbilityIfRangedWeapon()
        {
            attributes.Add(AttributeConstants.Ranged);
            specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            mockPercentileSelector.Verify(s => s.SelectAllFrom("powerRangedWeaponSpecialAbilities"), Times.Once);
        }

        [Test]
        public void GetArmorAbilityIfArmor()
        {
            specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            mockPercentileSelector.Verify(s => s.SelectAllFrom("powerArmorSpecialAbilities"), Times.Once);
        }

        [Test]
        public void ThrowErrorIfNotValidTypes()
        {
            Assert.That(() => specialAbilitiesGenerator.GenerateWith(new[] { "invalid type" }, "power", 1, 1), Throws.ArgumentException);
        }

        [Test]
        public void SetAbilityByResult()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectAllFrom("powerArmorSpecialAbilities")).Returns(new[] { "name" });
            mockPercentileSelector.Setup(p => p.SelectFrom("powerArmorSpecialAbilities", 9266)).Returns("name");
            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialAbilityAttributeRequirements", "base name")).Returns(attributes);

            var result = new SpecialAbilityAttributesResult();
            result.BaseName = "base name";
            result.BonusEquivalent = 9;
            result.Strength = 266;
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "name")).Returns(result);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var ability = abilities.First();
            Assert.That(ability.AttributeRequirements, Is.EqualTo(attributes));
            Assert.That(ability.Name, Is.EqualTo("name"));
            Assert.That(ability.BaseName, Is.EqualTo("core name"));
            Assert.That(ability.Strength, Is.EqualTo(266));
            Assert.That(ability.BonusEquivalent, Is.EqualTo(9));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAbilities()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "ability 1", "ability 2", "ability 3" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("ability 1");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("ability 2");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns("ability 3");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 3"));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        private SpecialAbility CreateSpecialAbility(String name)
        {
            var ability = new SpecialAbility();
            ability.Name = name;
            ability.BaseName = name;
            ability.AttributeRequirements = attributes;
            return ability;
        }

        [Test]
        public void DoNotAllowAbilitiesAndMagicBonusToBeGreaterThan10()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "big ability", "small ability", });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("big ability");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("small ability");

            var bigResult = new SpecialAbilityAttributesResult { BonusEquivalent = 2 };
            var smallResult = new SpecialAbilityAttributesResult { BonusEquivalent = 1 };
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "big ability")).Returns(bigResult);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "small ability")).Returns(smallResult);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 9, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("small ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void AccumulateAbilities()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "ability 1", "ability 2", "ability 3", "ability 4" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3).Returns(4);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("ability 1");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("ability 2");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns("ability 3");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 4)).Returns("ability 4");

            var result1 = new SpecialAbilityAttributesResult { BonusEquivalent = 2 };
            var result2 = new SpecialAbilityAttributesResult { BonusEquivalent = 2 };
            var result3 = new SpecialAbilityAttributesResult { BonusEquivalent = 3 };
            var result4 = new SpecialAbilityAttributesResult { BonusEquivalent = 0 };
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 1")).Returns(result1);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 2")).Returns(result2);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 3")).Returns(result3);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 4")).Returns(result4);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 5, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void ReplaceWeakWithStrong()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "weak ability", "strong ability" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("weak ability");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("strong ability");

            var weakResult = new SpecialAbilityAttributesResult { Strength = 1 };
            var strongResult = new SpecialAbilityAttributesResult { Strength = 2 };
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "weak ability")).Returns(weakResult);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "strong ability")).Returns(strongResult);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("strong ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void DoNotReplaceStrongWithWeak()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "weak ability", "strong ability", "other ability" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("strong ability");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("weak ability");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns("other ability");

            var weakResult = new SpecialAbilityAttributesResult { Strength = 1 };
            var strongResult = new SpecialAbilityAttributesResult { Strength = 2 };
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "weak ability")).Returns(weakResult);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "strong ability")).Returns(strongResult);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("strong ability"));
            Assert.That(names, Is.Not.Contains("weak ability"));
        }

        [Test]
        public void AbilitiesMaxOutAtBonusOf10()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "ability 1", "ability 2", "ability 3", "ability 4" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3).Returns(4);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("ability 1");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("ability 2");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns("ability 3");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 4)).Returns("ability 4");

            var result1 = new SpecialAbilityAttributesResult { BonusEquivalent = 2 };
            var result2 = new SpecialAbilityAttributesResult { BonusEquivalent = 2 };
            var result3 = new SpecialAbilityAttributesResult { BonusEquivalent = 3 };
            var result4 = new SpecialAbilityAttributesResult { BonusEquivalent = 0 };
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 1")).Returns(result1);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 2")).Returns(result2);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 3")).Returns(result3);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 4")).Returns(result4);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 4);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 3"));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void CanGetAbilitiesWithBonusOf0WhileAtBonusOf10()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "ability 1", "ability 2", "ability 3" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("ability 1");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("ability 2");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns("ability 3");

            var result1 = new SpecialAbilityAttributesResult { BonusEquivalent = 9 };
            var result2 = new SpecialAbilityAttributesResult { BonusEquivalent = 0 };
            var result3 = new SpecialAbilityAttributesResult { BonusEquivalent = 3 };
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 1")).Returns(result1);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 2")).Returns(result2);
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 3")).Returns(result3);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void DuplicateAbilitiesCannotBeAdded()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "ability", "other ability" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("ability");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("other ability");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability"));
            Assert.That(names, Contains.Item("other ability"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void AbilitiesFilteredByAttributeRequirementsFromCoreName()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "ability 1", "ability 2" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("ability 1");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("ability 2");
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityCoreNames", "ability 1")).Returns(new[] { "core ability 1" });
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityCoreNames", "ability 2")).Returns(new[] { "core ability 2" });
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "core ability 1")).Returns(new[] { "other type", "type 1" });
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "core ability 2")).Returns(attributes);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ExtraAttributesDoNotMatter()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { "ability" });
            attributes.Add("type 1");
            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialAbilityAttributes", "ability")).Returns(attributes);
            var inputTypes = attributes.Union(new[] { "other type" });

            var abilities = specialAbilitiesGenerator.GenerateWith(inputTypes, "power", 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void BonusSpecialAbilitiesAdded()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "ability 1", "ability 2" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("BonusSpecialAbility");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("ability 1");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns("ability 2");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void BaneAbilityGetsDesignatedFoe()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { "Bane" });
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectFrom("DesignatedFoes", 9266)).Returns("foe");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var ability = abilities.First();
            Assert.That(ability.BaseName, Is.EqualTo("Bane"));
            Assert.That(ability.Name, Is.EqualTo("foebane"));
        }

        [Test]
        public void SpellStoringAbilityDoesNotHaveSpellIfBelow51()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { "Spell storing" });
            mockSpellGenerator.Setup(g => g.Generate(It.IsAny<String>(), It.IsAny<Int32>())).Returns("spell");

            for (var roll = 1; roll < 51; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
                var ability = abilities.First();
                Assert.That(ability.BaseName, Is.EqualTo("Spell storing"));
                Assert.That(ability.Name, Is.EqualTo("Spell storing"));
            }
        }

        [Test]
        public void SpellStoringAbilityHasSpellIfAbove50()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { "Spell storing" });
            mockSpellGenerator.Setup(g => g.Generate(It.IsAny<String>(), It.IsAny<Int32>())).Returns("spell");

            for (var roll = 51; roll <= 100; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
                var ability = abilities.First();
                Assert.That(ability.BaseName, Is.EqualTo("Spell storing"));
                Assert.That(ability.Name, Is.EqualTo("Spell storing (contains spell)"));
            }
        }

        [Test]
        public void SpellStoringAbilityGetsTypeAndLevelOfSpell()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { "Spell storing" });
            mockDice.Setup(d => d.Percentile(1)).Returns(100);

            mockDice.Setup(d => d.d4(1)).Returns(9266);
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9265)).Returns("spell");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var ability = abilities.First();
            Assert.That(ability, Is.EqualTo("Spell storing"));
            Assert.That(ability.Name, Is.EqualTo("Spell storing (contains spell)"));
        }

        [Test]
        public void StopIfAllPossibleAbilitiesAcquired()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { "ability" });

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 5);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CountSameCoreNameAsSameAbility()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { "ability 1", "ability 2" });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("ability 1");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns("ability 2");
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityCoreNames", "ability 1")).Returns(new[] { "core ability 1" });
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityCoreNames", "ability 2")).Returns(new[] { "core ability 1" });

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 5);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ReturnEmptyIfNoCompatibleAbilities()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(Enumerable.Empty<String>());
            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void ReturnAllAbilitiesWithStrongestIfQuantityGreaterThanOrEqualToAllAvailableAbilities()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            var ability2 = CreateSpecialAbility("ability 2");
            var ability3 = CreateSpecialAbility("ability 3");
            ability3.BaseName = "ability";
            ability3.Strength = 1;
            var ability4 = CreateSpecialAbility("ability 4");
            ability4.BaseName = "ability";
            ability4.Strength = 2;

            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability3.Name)).Returns(ability3);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability4.Name)).Returns(ability4);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability1.Name, ability2.Name, ability3.Name, ability4.Name });

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 4);
            Assert.That(abilities.Count(), Is.EqualTo(3));
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability4));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>()), Times.Never);
        }

        [Test]
        public void DoNotReturnAbilitiesWithBonusSumGreaterThan10()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            ability1.BonusEquivalent = 3;
            var ability2 = CreateSpecialAbility("ability 2");
            ability2.BonusEquivalent = 3;
            var ability3 = CreateSpecialAbility("ability 3");
            ability3.BonusEquivalent = 3;
            var ability4 = CreateSpecialAbility("ability 4");
            ability4.BonusEquivalent = 3;

            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3).Returns(4);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(ability1.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(ability2.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns(ability3.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 4)).Returns(ability4.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability3.Name)).Returns(ability3);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability4.Name)).Returns(ability4);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability1.Name, ability2.Name, ability3.Name, ability4.Name });

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 5);
            Assert.That(abilities.Count(), Is.EqualTo(3));
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>()), Times.Exactly(3));
        }

        [Test]
        public void RemoveWeakerAbilitiesFromAvailableWhenStrongAdded()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            var ability2 = CreateSpecialAbility("ability 2");
            var ability3 = CreateSpecialAbility("ability 3");
            ability3.BaseName = "ability";
            ability3.Strength = 1;
            var ability4 = CreateSpecialAbility("ability 4");
            ability4.BaseName = "ability";
            ability4.Strength = 2;

            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 9266)).Returns(ability4.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability3.Name)).Returns(ability3);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability4.Name)).Returns(ability4);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability1.Name, ability2.Name, ability3.Name, ability4.Name });

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 3);
            Assert.That(abilities.Count(), Is.EqualTo(3));
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability4));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>()), Times.Once);
        }

        [Test]
        public void WhenAddingAllAbilities_UpgradeAllWeakAbilities()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            var ability2 = CreateSpecialAbility("ability 2");
            var ability3 = CreateSpecialAbility("ability 3");
            ability3.BaseName = "ability";
            ability3.Strength = 1;
            var ability4 = CreateSpecialAbility("ability 4");
            ability4.BaseName = "ability";
            ability4.Strength = 2;

            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 92)).Returns(ability3.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 66)).Returns("BonusSpecialAbility");
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability3.Name)).Returns(ability3);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability4.Name)).Returns(ability4);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability1.Name, ability2.Name, ability3.Name, ability4.Name });

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 3);
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Is.Not.Contains(ability3));
            Assert.That(abilities, Contains.Item(ability4));
            Assert.That(abilities.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>()), Times.Exactly(2));
        }

        [Test]
        public void NoAttributesThrowsError()
        {
            Assert.That(() => specialAbilitiesGenerator.GenerateWith(Enumerable.Empty<String>(), "power", 1, 1), Throws.Exception);
        }

        private SpecialAbilityAttributesResult CreateSpecialAbility(String name)
        {
            var result = new SpecialAbilityAttributesResult();

            result.BaseName = name;
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", name)).Returns(result);

            return result;
        }

        private void SetUpAbilityChain(params String[] names)
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(names);
            var sequence = mockDice.SetupSequence(d => d.Percentile(1));

            for (var roll = 0; roll < names.Length; roll++)
            {
                sequence = sequence.Returns(roll);
                mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), roll)).Returns(names[roll]);
            }
        }
    }
}