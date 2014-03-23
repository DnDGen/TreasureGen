using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorTests
    {
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private Mock<ISpecialAbilityDataSelector> mockSpecialAbilityDataSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IDice> mockDice;
        private Mock<ISpellGenerator> mockSpellGenerator;

        private List<String> attributes;

        [SetUp]
        public void Setup()
        {
            attributes = new List<String>();
            attributes.Add(ItemTypeConstants.Armor);

            mockSpecialAbilityDataSelector = new Mock<ISpecialAbilityDataSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<IDice>();
            mockSpellGenerator = new Mock<ISpellGenerator>();

            specialAbilitiesGenerator = new SpecialAbilitiesGenerator(mockSpecialAbilityDataSelector.Object,
                mockAttributesSelector.Object, mockPercentileSelector.Object, mockDice.Object, mockSpellGenerator.Object);
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
            var shieldAbility = CreateSpecialAbility("shield ability");

            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectAllFrom("powerShieldSpecialAbilities")).Returns(new[] { shieldAbility.Name });
            mockPercentileSelector.Setup(p => p.SelectFrom("powerShieldSpecialAbilities", 9266)).Returns(shieldAbility.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(shieldAbility.Name)).Returns(shieldAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities.First(), Is.EqualTo(shieldAbility));
        }

        [Test]
        public void GetMeleeWeaponAbilityIfMeleeWeapon()
        {
            attributes.Add(AttributeConstants.Melee);
            var meleeWeaponAbility = CreateSpecialAbility("melee weapon ability");

            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectAllFrom("powerMeleeWeaponSpecialAbilities")).Returns(new[] { meleeWeaponAbility.Name });
            mockPercentileSelector.Setup(p => p.SelectFrom("powerMeleeWeaponSpecialAbilities", 9266)).Returns(meleeWeaponAbility.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(meleeWeaponAbility.Name)).Returns(meleeWeaponAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities.First(), Is.EqualTo(meleeWeaponAbility));
        }

        [Test]
        public void GetRangedWeaponAbilityIfRangedWeapon()
        {
            attributes.Add(AttributeConstants.Ranged);
            var rangedWeaponAbility = CreateSpecialAbility("ranged weapon ability");

            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectAllFrom("powerRangedWeaponSpecialAbilities")).Returns(new[] { rangedWeaponAbility.Name });
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRangedWeaponSpecialAbilities", 9266)).Returns(rangedWeaponAbility.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(rangedWeaponAbility.Name)).Returns(rangedWeaponAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities.First(), Is.EqualTo(rangedWeaponAbility));
        }

        [Test]
        public void GetArmorAbilityIfArmor()
        {
            var armorAbility = CreateSpecialAbility("armor ability");

            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectAllFrom("powerArmorSpecialAbilities")).Returns(new[] { armorAbility.Name });
            mockPercentileSelector.Setup(p => p.SelectFrom("powerArmorSpecialAbilities", 9266)).Returns(armorAbility.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(armorAbility.Name)).Returns(armorAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities.First(), Is.EqualTo(armorAbility));
        }

        [Test]
        public void ThrowErrorIfNotValidTypes()
        {
            Assert.That(() => specialAbilitiesGenerator.GenerateWith(new[] { "invalid type" }, "power", 1, 1), Throws.ArgumentException);
        }

        [Test]
        public void SetAbilityByResult()
        {
            var ability = new SpecialAbility();
            ability.BonusEquivalent = 9;
            ability.CoreName = "core name";
            ability.Name = "name";
            ability.Strength = 266;
            ability.AttributeRequirements = attributes;

            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectAllFrom("powerArmorSpecialAbilities")).Returns(new[] { ability.Name });
            mockPercentileSelector.Setup(p => p.SelectFrom("powerArmorSpecialAbilities", 9266)).Returns(ability.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability.Name)).Returns(ability);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities.First(), Is.EqualTo(ability));
            Assert.That(abilities.Count(), Is.EqualTo(1));
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

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability1.Name, ability2.Name, ability3.Name });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(ability1.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(ability2.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns(ability3.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability3.Name)).Returns(ability3);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 3);
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
            ability.AttributeRequirements = attributes;
            return ability;
        }

        [Test]
        public void DoNotAllowAbilitiesAndMagicBonusToBeGreaterThan10()
        {
            var bigAbility = CreateSpecialAbility("big ability");
            bigAbility.BonusEquivalent = 2;
            var smallAbility = CreateSpecialAbility("small ability");
            smallAbility.BonusEquivalent = 1;

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { smallAbility.Name, bigAbility.Name, });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(bigAbility.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(smallAbility.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(bigAbility.Name)).Returns(bigAbility);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(smallAbility.Name)).Returns(smallAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 9, 1);
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

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability1.Name, ability2.Name, ability3.Name, ability4.Name });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3).Returns(4);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(ability1.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(ability2.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns(ability3.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 4)).Returns(ability4.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability3.Name)).Returns(ability3);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability4.Name)).Returns(ability4);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 5, 3);
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability4));
            Assert.That(abilities.Count(), Is.EqualTo(3));
        }

        [Test]
        public void ReplaceWeakWithStrong()
        {
            var weakAbility = CreateSpecialAbility("weak ability");
            weakAbility.CoreName = "ability";
            weakAbility.Strength = 1;
            var strongAbility = CreateSpecialAbility("strong ability");
            strongAbility.CoreName = "ability";
            strongAbility.Strength = 2;

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { weakAbility.Name, strongAbility.Name });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(weakAbility.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(strongAbility.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(weakAbility.Name)).Returns(weakAbility);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(strongAbility.Name)).Returns(strongAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
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

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { strongAbility.Name, weakAbility.Name, otherAbility.Name });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(strongAbility.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(weakAbility.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns(otherAbility.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(strongAbility.Name)).Returns(strongAbility);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(weakAbility.Name)).Returns(weakAbility);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(otherAbility.Name)).Returns(otherAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
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

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability1.Name, ability2.Name, ability3.Name, ability4.Name });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3).Returns(4);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(ability1.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(ability2.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns(ability3.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 4)).Returns(ability4.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability3.Name)).Returns(ability3);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability4.Name)).Returns(ability4);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 4);
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability3));
            Assert.That(abilities.Count(), Is.EqualTo(3));
        }

        [Test]
        public void DuplicateAbilitiesCannotBeAdded()
        {
            var ability = CreateSpecialAbility("ability");
            var otherAbility = CreateSpecialAbility("other ability");

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability.Name, otherAbility.Name });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(ability.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(otherAbility.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability.Name)).Returns(ability);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(otherAbility.Name)).Returns(otherAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item(ability.Name));
            Assert.That(names, Contains.Item(otherAbility.Name));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void AbilitiesFilteredByAttributeRequirementsFromCoreName()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            ability1.CoreName = "core ability 1";
            ability1.AttributeRequirements = new[] { "other type", "type 1" };

            attributes.Add("type 1");
            attributes.Add("type 2");
            var ability2 = CreateSpecialAbility("ability 2");
            ability2.CoreName = "core ability 2";

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability1.Name, ability2.Name });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(ability1.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(ability2.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ExtraAttributesDoNotMatter()
        {
            var ability = CreateSpecialAbility("ability");
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability.Name });
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(It.IsAny<String>())).Returns(ability);

            attributes.Add("type 1");
            mockAttributesSelector.Setup(p => p.SelectFrom(ability.Name, "SpecialAbilityTypes")).Returns(attributes);
            var inputTypes = attributes.Union(new[] { "other type" });

            var abilities = specialAbilitiesGenerator.GenerateWith(inputTypes, "power", 1, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(ability.Name));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void BonusSpecialAbilitiesAdded()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            var ability2 = CreateSpecialAbility("ability 2");

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { ability1.Name, ability2.Name });
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2).Returns(3);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns("BonusSpecialAbility");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(ability1.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 3)).Returns(ability2.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities.Count(), Is.EqualTo(2));
        }

        [Test]
        public void BaneAbilityGetsDesignatedFoe()
        {
            var bane = CreateSpecialAbility("Bane");
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(It.IsAny<String>())).Returns(bane);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>()))
                .Returns(new[] { bane.Name });
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectFrom("DesignatedFoes", 9266)).Returns("foe");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var ability = abilities.First();
            Assert.That(ability.CoreName, Is.EqualTo(bane.CoreName));
            Assert.That(ability.Name, Is.EqualTo("foebane"));
        }

        [Test]
        public void SpellStoringAbilityDoesNotHaveSpellIfBelow51()
        {
            var spellStoring = CreateSpecialAbility("Spell storing");
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { spellStoring.Name });
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(It.IsAny<String>())).Returns(spellStoring);
            mockSpellGenerator.Setup(g => g.Generate(It.IsAny<String>(), It.IsAny<Int32>())).Returns("spell");

            for (var roll = 1; roll < 51; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
                var ability = abilities.First();
                Assert.That(ability, Is.EqualTo(spellStoring));
                Assert.That(ability.Name, Is.EqualTo("Spell storing"));
            }
        }

        [Test]
        public void SpellStoringAbilityHasSpellIfAbove50()
        {
            var spellStoring = CreateSpecialAbility("Spell storing");
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { spellStoring.Name });
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(It.IsAny<String>())).Returns(spellStoring);
            mockSpellGenerator.Setup(g => g.Generate(It.IsAny<String>(), It.IsAny<Int32>())).Returns("spell");

            for (var roll = 51; roll <= 100; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
                var ability = abilities.First();
                Assert.That(ability, Is.EqualTo(spellStoring));
                Assert.That(ability.Name, Is.EqualTo("Spell storing (contains spell)"));
            }
        }

        [Test]
        public void SpellStoringAbilityGetsTypeAndLevelOfSpell()
        {
            var spellStoring = CreateSpecialAbility("Spell storing");
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { spellStoring.Name });
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(It.IsAny<String>())).Returns(spellStoring);
            mockDice.Setup(d => d.Percentile(1)).Returns(100);

            mockDice.Setup(d => d.d4(1)).Returns(9266);
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9265)).Returns("spell");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var ability = abilities.First();
            Assert.That(ability, Is.EqualTo(spellStoring));
            Assert.That(ability.Name, Is.EqualTo("Spell storing (contains spell)"));
        }

        [Test]
        public void StopIfAllPossibleAbilitiesAcquired()
        {
            var ability = CreateSpecialAbility("ability");
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(It.IsAny<String>())).Returns(ability);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { ability.Name });

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 5);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CountSameCoreNameAsSameAbility()
        {
            var ability1 = CreateSpecialAbility("ability 1");
            ability1.Strength = 1;
            var ability2 = CreateSpecialAbility("ability 2");
            ability2.CoreName = ability1.CoreName;
            ability2.Strength = 2;

            mockDice.SetupSequence(d => d.Percentile(1)).Returns(1).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 1)).Returns(ability1.Name);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 2)).Returns(ability2.Name);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataSelector.Setup(p => p.SelectFor(ability2.Name)).Returns(ability2);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(new[] { ability1.Name, ability2.Name });

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
            ability3.CoreName = "ability";
            ability3.Strength = 1;
            var ability4 = CreateSpecialAbility("ability 4");
            ability4.CoreName = "ability";
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
            ability3.CoreName = "ability";
            ability3.Strength = 1;
            var ability4 = CreateSpecialAbility("ability 4");
            ability4.CoreName = "ability";
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
            ability3.CoreName = "ability";
            ability3.Strength = 1;
            var ability4 = CreateSpecialAbility("ability 4");
            ability4.CoreName = "ability";
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
    }
}