using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using EquipmentGen.Tables.Interfaces;
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
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<ISpecialAbilityAttributesSelector> mockSpecialAbilityAttributesSelector;
        private Mock<IDice> mockDice;

        private List<String> attributes;
        private List<String> names;
        private String power;

        [SetUp]
        public void Setup()
        {
            attributes = new List<String>();

            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockSpecialAbilityAttributesSelector = new Mock<ISpecialAbilityAttributesSelector>();
            mockDice = new Mock<IDice>();
            names = new List<String>();
            power = "power";

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(names);
            mockDice.Setup(d => d.Roll(1).d(It.IsAny<Int32>())).Returns(1);

            specialAbilitiesGenerator = new SpecialAbilitiesGenerator(mockAttributesSelector.Object, mockPercentileSelector.Object,
                mockSpecialAbilityAttributesSelector.Object, mockBooleanPercentileSelector.Object, mockDice.Object);
        }

        [Test]
        public void ReturnEmptyIfBonusLessThanOne()
        {
            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 0, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void GetShieldAbilityIfShield()
        {
            attributes.Add(AttributeConstants.Shield);
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Shield);

            specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 1);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(tableName), Times.Once);
        }

        [Test]
        public void GetMeleeAbilityIfMelee()
        {
            attributes.Add(AttributeConstants.Melee);
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Melee);

            specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Weapon, attributes, power, 1, 1);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(tableName), Times.Once);
        }

        [Test]
        public void GetRangedAbilityIfRanged()
        {
            attributes.Add(AttributeConstants.Ranged);
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Ranged);

            specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Weapon, attributes, power, 1, 1);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(tableName), Times.Once);
        }

        [Test]
        public void GetArmorAbilityIfArmor()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, ItemTypeConstants.Armor);
            specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 1);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(tableName), Times.Once);
        }

        [Test]
        public void ReturnEmptyIfNoMatchingTableNames()
        {
            var abilities = specialAbilitiesGenerator.GenerateFor("wrong item type", attributes, power, 1, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void SetAbilityByResult()
        {
            CreateSpecialAbility("name", "base name", 9, 266);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns("name");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 1);
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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 3"));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void WeaponsThatAreBothMeleeAndRangedGetRandomlyBetweenTables()
        {
            attributes.Add(AttributeConstants.Melee);
            attributes.Add(AttributeConstants.Ranged);

            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Melee);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[] { "melee ability" });
            tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Ranged);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[] { "ranged ability" });

            var meleeResult = new SpecialAbilityAttributesResult();
            meleeResult.BaseName = "melee ability";
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributes, meleeResult.BaseName)).Returns(meleeResult);
            mockAttributesSelector.Setup(p => p.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, meleeResult.BaseName)).Returns(attributes);

            var rangedResult = new SpecialAbilityAttributesResult();
            rangedResult.BaseName = "ranged ability";
            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributes, rangedResult.BaseName)).Returns(rangedResult);
            mockAttributesSelector.Setup(p => p.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, rangedResult.BaseName)).Returns(attributes);

            mockDice.SetupSequence(d => d.Roll(1).d(2)).Returns(1).Returns(2);

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 2);
            var names = abilities.Select(a => a.Name);

            Assert.That(names, Contains.Item("melee ability"));
            Assert.That(names, Contains.Item("ranged ability"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void DoNotAllowAbilitiesAndMagicBonusToBeGreaterThan10()
        {
            CreateSpecialAbility("big ability", bonus: 2);
            CreateSpecialAbility("small ability", bonus: 1);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("big ability").Returns("small ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 9, 1);
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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3").Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 5, 3);
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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("weak ability").Returns("strong ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("strong ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void DoNotCompareStrengthForDissimilarCoreName()
        {
            CreateSpecialAbility("weak ability", strength: 1);
            CreateSpecialAbility("strong ability", strength: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("weak ability").Returns("strong ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 2);
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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("strong ability").Returns("weak ability")
                .Returns("other ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 2);
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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3").Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 4);
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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 2);
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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 1").Returns("ability 1")
                .Returns("ability 2");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 2);
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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 1").Returns("ability 2");

            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, "base ability 1")).Returns(new[] { "other type", "type 1" });
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, "base ability 2")).Returns(attributes);

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ExtraAttributesDoNotMatter()
        {
            CreateSpecialAbility("ability");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns("ability");
            attributes.Add("type 1");
            var inputTypes = attributes.Union(new[] { "other type" });

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, inputTypes, power, 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void BonusSpecialAbilitiesAdded()
        {
            CreateSpecialAbility("ability 1", "base ability 1");
            CreateSpecialAbility("ability 2", "base ability 2");
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("BonusSpecialAbility").Returns("ability 1")
                .Returns("ability 2");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void StopIfAllPossibleAbilitiesAcquired()
        {
            CreateSpecialAbility("ability");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns("ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 5);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CountSameCoreNameAsSameAbility()
        {
            CreateSpecialAbility("ability 1", "base name", strength: 1);
            CreateSpecialAbility("ability 2", "base name", strength: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 1").Returns("ability 2");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 5);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ReturnEmptyIfNoCompatibleAbilities()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<String>())).Returns(Enumerable.Empty<String>());
            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void ReturnAllAbilitiesWithStrongestIfQuantityGreaterThanOrEqualToAllAvailableAbilities()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3", "ability", strength: 1);
            CreateSpecialAbility("ability 4", "ability", strength: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3").Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 4);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>()), Times.Never);
        }

        [Test]
        public void DoNotReturnAbilitiesWithBonusSumGreaterThan10()
        {
            CreateSpecialAbility("ability 1", bonus: 3);
            CreateSpecialAbility("ability 2", bonus: 3);
            CreateSpecialAbility("ability 3", bonus: 3);
            CreateSpecialAbility("ability 4", bonus: 3);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3").Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 5);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 3"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>()), Times.Exactly(3));
        }

        [Test]
        public void RemoveWeakerAbilitiesFromAvailableWhenStrongAdded()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3", "ability", strength: 1);
            CreateSpecialAbility("ability 4", "ability", strength: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 4").Returns("ability 2")
                .Returns("ability 3").Returns("ability 1");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>()), Times.Once);
        }

        [Test]
        public void WhenAddingAllAbilities_UpgradeAllWeakAbilities()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3", "ability", strength: 1);
            CreateSpecialAbility("ability 4", "ability", strength: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<String>())).Returns("ability 3").Returns("BonusSpecialAbility")
                .Returns("ability 2").Returns("ability 1").Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, 1, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<String>()), Times.Exactly(2));
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

            mockSpecialAbilityAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributes, name)).Returns(result);
            mockAttributesSelector.Setup(p => p.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, result.BaseName)).Returns(attributes);
        }
    }
}