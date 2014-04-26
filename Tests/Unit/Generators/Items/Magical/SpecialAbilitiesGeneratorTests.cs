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
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<ISpecialAbilityAttributesSelector> mockSpecialAbilityAttributesSelector;

        private List<String> attributes;
        private List<String> names;

        [SetUp]
        public void Setup()
        {
            attributes = new List<String>();
            attributes.Add(ItemTypeConstants.Armor);

            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<IDice>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockSpecialAbilityAttributesSelector = new Mock<ISpecialAbilityAttributesSelector>();
            names = new List<String>();

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(names);

            specialAbilitiesGenerator = new SpecialAbilitiesGenerator(mockAttributesSelector.Object, mockPercentileSelector.Object,
                mockDice.Object, mockSpecialAbilityAttributesSelector.Object, mockBooleanPercentileSelector.Object);
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
            CreateSpecialAbility("name", "base name", 9, 266);
            SetUpAbilityChain("name");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var ability = abilities.First();
            Assert.That(ability.AttributeRequirements, Is.EqualTo(attributes));
            Assert.That(ability.Name, Is.EqualTo("name"));
            Assert.That(ability.BaseName, Is.EqualTo("base name"));
            Assert.That(ability.Strength, Is.EqualTo(266));
            Assert.That(ability.BonusEquivalent, Is.EqualTo(9));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAbilities()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3");
            SetUpAbilityChain("ability 1", "ability 2", "ability 3");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 3"));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void DoNotAllowAbilitiesAndMagicBonusToBeGreaterThan10()
        {
            CreateSpecialAbility("big ability", bonus: 2);
            CreateSpecialAbility("small ability", bonus: 1);
            SetUpAbilityChain("big ability", "small ability");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 9, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("small ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void AccumulateAbilities()
        {
            CreateSpecialAbility("ability 1", bonus: 2);
            CreateSpecialAbility("ability 2", bonus: 2);
            CreateSpecialAbility("ability 3", bonus: 3);
            CreateSpecialAbility("ability 4", bonus: 0);
            SetUpAbilityChain("ability 1", "ability 2", "ability 3", "ability 4");

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
            CreateSpecialAbility("weak ability", "ability", strength: 1);
            CreateSpecialAbility("strong ability", "ability", strength: 2);
            SetUpAbilityChain("weak ability", "strong ability");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("strong ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void DoNotCompareStrengthForDissimilarCoreName()
        {
            CreateSpecialAbility("weak ability", strength: 1);
            CreateSpecialAbility("strong ability", strength: 2);
            SetUpAbilityChain("weak ability", "strong ability");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("weak ability"));
            Assert.That(names, Contains.Item("strong ability"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void DoNotReplaceStrongWithWeak()
        {
            CreateSpecialAbility("strong ability", "ability", strength: 2);
            CreateSpecialAbility("weak ability", "ability", strength: 1);
            CreateSpecialAbility("other ability");
            SetUpAbilityChain("strong ability", "weak ability", "other ability");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("strong ability"));
            Assert.That(names, Is.Not.Contains("weak ability"));
        }

        [Test]
        public void AbilitiesMaxOutAtBonusOf10()
        {
            CreateSpecialAbility("ability 1", bonus: 2);
            CreateSpecialAbility("ability 2", bonus: 2);
            CreateSpecialAbility("ability 3", bonus: 3);
            CreateSpecialAbility("ability 4", bonus: 3);
            SetUpAbilityChain("ability 1", "ability 2", "ability 3", "ability 4");

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
            CreateSpecialAbility("ability 1", bonus: 9);
            CreateSpecialAbility("ability 2", bonus: 0);
            CreateSpecialAbility("ability 3", bonus: 3);
            SetUpAbilityChain("ability 1", "ability 2", "ability 3");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void DuplicateAbilitiesCannotBeAdded()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3");
            SetUpAbilityChain("ability 1", "ability 1", "ability 2");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void AbilitiesFilteredByAttributeRequirementsFromBaseName()
        {
            CreateSpecialAbility("ability 1", "base ability 1");
            CreateSpecialAbility("ability 2", "base ability 2");
            SetUpAbilityChain("ability 1", "ability 2");

            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributeRequirements", "base ability 1")).Returns(new[] { "other type", "type 1" });
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributeRequirements", "base ability 2")).Returns(attributes);

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ExtraAttributesDoNotMatter()
        {
            CreateSpecialAbility("ability");
            SetUpAbilityChain("ability");
            attributes.Add("type 1");
            var inputTypes = attributes.Union(new[] { "other type" });

            var abilities = specialAbilitiesGenerator.GenerateWith(inputTypes, "power", 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void BonusSpecialAbilitiesAdded()
        {
            CreateSpecialAbility("ability 1", "base ability 1");
            CreateSpecialAbility("ability 2", "base ability 2");
            SetUpAbilityChain("BonusSpecialAbility", "ability 1", "ability 2");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void BaneAbilityGetsDesignatedFoe()
        {
            CreateSpecialAbility("Bane");
            SetUpAbilityChain("Bane");
            mockPercentileSelector.Setup(p => p.SelectFrom("DesignatedFoes", It.IsAny<Int32>())).Returns("foe");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 1);
            var ability = abilities.First();
            Assert.That(ability.BaseName, Is.EqualTo("Bane"));
            Assert.That(ability.Name, Is.EqualTo("foebane"));
        }

        [Test]
        public void StopIfAllPossibleAbilitiesAcquired()
        {
            CreateSpecialAbility("ability");
            SetUpAbilityChain("ability");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 5);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CountSameCoreNameAsSameAbility()
        {
            CreateSpecialAbility("ability 1", "base name", strength: 1);
            CreateSpecialAbility("ability 2", "base name", strength: 2);
            SetUpAbilityChain("ability 1", "ability 2");

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
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3", "ability", strength: 1);
            CreateSpecialAbility("ability 4", "ability", strength: 2);
            SetUpAbilityChain("ability 1", "ability 2", "ability 3", "ability 4");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 4);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>()), Times.Never);
        }

        [Test]
        public void DoNotReturnAbilitiesWithBonusSumGreaterThan10()
        {
            CreateSpecialAbility("ability 1", bonus: 3);
            CreateSpecialAbility("ability 2", bonus: 3);
            CreateSpecialAbility("ability 3", bonus: 3);
            CreateSpecialAbility("ability 4", bonus: 3);
            SetUpAbilityChain("ability 1", "ability 2", "ability 3", "ability 4");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 5);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 3"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>()), Times.Exactly(3));
        }

        [Test]
        public void RemoveWeakerAbilitiesFromAvailableWhenStrongAdded()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3", "ability", strength: 1);
            CreateSpecialAbility("ability 4", "ability", strength: 2);
            SetUpAbilityChain("ability 4", "ability 2", "ability 3", "ability 1");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>()), Times.Once);
        }

        [Test]
        public void WhenAddingAllAbilities_UpgradeAllWeakAbilities()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3", "ability", strength: 1);
            CreateSpecialAbility("ability 4", "ability", strength: 2);
            SetUpAbilityChain("ability 3", "BonusSpecialAbility", "ability 2", "ability 1", "ability 4");

            var abilities = specialAbilitiesGenerator.GenerateWith(attributes, "power", 1, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>()), Times.Exactly(2));
        }

        [Test]
        public void NoAttributesThrowsError()
        {
            Assert.That(() => specialAbilitiesGenerator.GenerateWith(Enumerable.Empty<String>(), "power", 1, 1), Throws.Exception);
        }

        private void CreateSpecialAbility(String name, String baseName = "", Int32 bonus = 0, Int32 strength = 0)
        {
            var result = new SpecialAbilityAttributesResult();

            if (String.IsNullOrEmpty(baseName))
                result.BaseName = name;
            else
                result.BaseName = baseName;

            result.BonusEquivalent = bonus;
            result.Strength = strength;
            names.Add(name);

            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", name)).Returns(result);
            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialAbilityAttributeRequirements", result.BaseName)).Returns(attributes);

        }

        private void SetUpAbilityChain(params String[] names)
        {
            var sequence = mockDice.SetupSequence(d => d.Percentile(1));

            for (var roll = 0; roll < names.Length; roll++)
            {
                sequence = sequence.Returns(roll);
                mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), roll)).Returns(names[roll]);
            }
        }
    }
}