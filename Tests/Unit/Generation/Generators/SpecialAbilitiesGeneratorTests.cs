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

        private List<String> attributes;

        [SetUp]
        public void Setup()
        {
            attributes = new List<String>();
            attributes.Add(ItemTypeConstants.Armor);

            mockSpecialAbilityDataProvider = new Mock<ISpecialAbilityDataProvider>();
            mockTypesProvider = new Mock<IAttributesProvider>();
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockDice = new Mock<IDice>();
            mockSpellGenerator = new Mock<ISpellGenerator>();

            var results = new List<String>();
            while (results.Count < 10)
                results.Add("dummy result");

            mockPercentileResultProvider.Setup(p => p.GetAllResultsFrom(It.IsAny<String>())).Returns(results);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor("dummy result"))
                .Returns(() => new SpecialAbility() { CoreName = Guid.NewGuid().ToString() });

            specialAbilitiesGenerator = new SpecialAbilitiesGenerator(mockSpecialAbilityDataProvider.Object,
                mockTypesProvider.Object, mockPercentileResultProvider.Object, mockDice.Object, mockSpellGenerator.Object);
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

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerShieldSpecialAbilities")).Returns(shieldAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(shieldAbility.Name)).Returns(shieldAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities.First(), Is.EqualTo(shieldAbility));
        }

        [Test]
        public void GetMeleeWeaponAbilityIfMeleeWeapon()
        {
            attributes.Add(AttributeConstants.Melee);
            var meleeWeaponAbility = CreateSpecialAbility("melee weapon ability");

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerMeleeWeaponSpecialAbilities")).Returns(meleeWeaponAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(meleeWeaponAbility.Name)).Returns(meleeWeaponAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities.First(), Is.EqualTo(meleeWeaponAbility));
        }

        [Test]
        public void GetRangedWeaponAbilityIfRangedWeapon()
        {
            attributes.Add(AttributeConstants.Ranged);
            var rangedWeaponAbility = CreateSpecialAbility("ranged weapon ability");

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRangedWeaponSpecialAbilities")).Returns(rangedWeaponAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(rangedWeaponAbility.Name)).Returns(rangedWeaponAbility);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities.First(), Is.EqualTo(rangedWeaponAbility));
        }

        [Test]
        public void GetArmorAbilityIfArmor()
        {
            var armorAbility = CreateSpecialAbility("armor ability");

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerArmorSpecialAbilities")).Returns(armorAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(armorAbility.Name)).Returns(armorAbility);

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

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerArmorSpecialAbilities")).Returns(ability.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability.Name)).Returns(ability);

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

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns(ability1.Name)
                .Returns(ability2.Name).Returns(ability3.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability3.Name)).Returns(ability3);

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

            mockSpecialAbilityDataProvider.SetupSequence(p => p.GetDataFor(It.IsAny<String>())).Returns(bigAbility)
                .Returns(smallAbility);

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns(bigAbility.Name)
                .Returns(smallAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(bigAbility.Name)).Returns(bigAbility);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(smallAbility.Name)).Returns(smallAbility);

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

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns(ability1.Name)
                .Returns(ability2.Name).Returns(ability3.Name).Returns(ability4.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability3.Name)).Returns(ability3);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability4.Name)).Returns(ability4);

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

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns(weakAbility.Name)
                .Returns(strongAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(weakAbility.Name)).Returns(weakAbility);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(strongAbility.Name)).Returns(strongAbility);

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

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns(strongAbility.Name)
                .Returns(weakAbility.Name).Returns(otherAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(strongAbility.Name)).Returns(strongAbility);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(weakAbility.Name)).Returns(weakAbility);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(otherAbility.Name)).Returns(otherAbility);

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

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns(ability1.Name)
                .Returns(ability2.Name).Returns(ability3.Name).Returns(ability4.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability2.Name)).Returns(ability2);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability3.Name)).Returns(ability3);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability4.Name)).Returns(ability4);

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

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns(ability.Name)
                .Returns(otherAbility.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability.Name)).Returns(ability);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(otherAbility.Name)).Returns(otherAbility);

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

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns(ability1.Name).Returns(ability2.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability2.Name)).Returns(ability2);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ExtraAttributesDoNotMatter()
        {
            var ability = CreateSpecialAbility("ability");
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(ability);

            attributes.Add("type 1");
            mockTypesProvider.Setup(p => p.GetAttributesFor(ability.Name, "SpecialAbilityTypes")).Returns(attributes);
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

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns("BonusSpecialAbility")
                .Returns(ability1.Name).Returns(ability2.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability1.Name)).Returns(ability1);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(ability2.Name)).Returns(ability2);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities, Contains.Item(ability2));
            Assert.That(abilities, Contains.Item(ability1));
            Assert.That(abilities.Count(), Is.EqualTo(2));
        }

        [Test]
        public void BaneAbilityGetsDesignatedFoe()
        {
            var bane = CreateSpecialAbility("Bane");
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(bane);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("DesignatedFoes")).Returns("foe");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var ability = abilities.First();
            Assert.That(ability.CoreName, Is.EqualTo(bane.CoreName));
            Assert.That(ability.Name, Is.EqualTo("foebane"));
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
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(spellStoring);
            mockSpellGenerator.Setup(g => g.GenerateOfTypeAtLevel(It.IsAny<String>(), It.IsAny<Int32>())).Returns("spell");

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
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(spellStoring);
            mockDice.Setup(d => d.Percentile(1)).Returns(100);

            mockDice.Setup(d => d.d3(1)).Returns(9266);
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateOfTypeAtLevel("spell type", 9266)).Returns("spell");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var ability = abilities.First();
            Assert.That(ability, Is.EqualTo(spellStoring));
            Assert.That(ability.Name, Is.EqualTo("Spell storing (contains spell)"));
        }

        [Test]
        public void StopIfAllPossibleAbilitiesAcquired()
        {
            var ability = CreateSpecialAbility("ability");
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor(It.IsAny<String>())).Returns(ability);
            mockPercentileResultProvider.Setup(p => p.GetAllResultsFrom(It.IsAny<String>())).Returns(new[] { ability.Name });

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 5);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CountSameCoreNameAsSameAbility()
        {
            var ability1 = CreateSpecialAbility("ability");
            var ability2 = CreateSpecialAbility("ability 2");
            ability2.CoreName = ability1.CoreName;

            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom(It.IsAny<String>())).Returns(ability1.Name).Returns(ability2.Name);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor("ability")).Returns(ability1);
            mockSpecialAbilityDataProvider.Setup(p => p.GetDataFor("ability 2")).Returns(ability2);
            mockPercentileResultProvider.Setup(p => p.GetAllResultsFrom(It.IsAny<String>())).Returns(new[] { ability1.Name, ability2.Name });

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 5);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ReturnEmptyIfNoCompatibleAbilities()
        {
            mockPercentileResultProvider.Setup(p => p.GetAllResultsFrom(It.IsAny<String>())).Returns(Enumerable.Empty<String>());
            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            Assert.That(abilities, Is.Empty);
        }
    }
}