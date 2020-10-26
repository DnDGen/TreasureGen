using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Generators.Items.Magical;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Helpers;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorTests
    {
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private Mock<ICollectionSelector> mockCollectionsSelector;
        private Mock<ITreasurePercentileSelector> mockPercentileSelector;
        private Mock<ISpecialAbilityDataSelector> mockSpecialAbilityDataSelector;
        private DamageHelper damageHelper;

        private List<string> itemAttributes;
        private List<string> names;
        private string power;
        private Item item;

        [SetUp]
        public void Setup()
        {
            itemAttributes = new List<string>();

            mockCollectionsSelector = new Mock<ICollectionSelector>();
            mockPercentileSelector = new Mock<ITreasurePercentileSelector>();
            mockSpecialAbilityDataSelector = new Mock<ISpecialAbilityDataSelector>();
            specialAbilitiesGenerator = new SpecialAbilitiesGenerator(mockCollectionsSelector.Object, mockPercentileSelector.Object, mockSpecialAbilityDataSelector.Object);
            names = new List<string>();
            item = new Item();
            damageHelper = new DamageHelper();

            power = "power";
            item.ItemType = ItemTypeConstants.Armor;
            item.Attributes = itemAttributes;
            item.Magic.Bonus = 1;

            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<string>())).Returns(names);

            var count = 0;

            mockCollectionsSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>()))
                .Returns((IEnumerable<string> ss) => ss.ElementAt(count++ % ss.Count()));
        }

        [Test]
        public void ReturnEmptyIfBonusLessThanOne()
        {
            item.Magic.Bonus = 0;
            CreateSpecialAbility("name", "base name", 9, 266);

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Empty);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(It.IsAny<string>()), Times.Never);
            mockPercentileSelector.Verify(s => s.SelectFrom(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void ReturnEmptyIfQuantityIsNone()
        {
            CreateSpecialAbility("name", "base name", 9, 266);

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 0);
            Assert.That(abilities, Is.Empty);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(It.IsAny<string>()), Times.Never);
            mockPercentileSelector.Verify(s => s.SelectFrom(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void GetShieldAbilityIfShield()
        {
            itemAttributes.Add(AttributeConstants.Shield);
            CreateSpecialAbility("name", "base name", 9, 266);

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Shield);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(tableName), Times.Once);
        }

        [Test]
        public void GetMeleeAbilityIfMelee()
        {
            item.ItemType = ItemTypeConstants.Weapon;
            itemAttributes.Add(AttributeConstants.Melee);
            CreateSpecialAbility("name", "base name", 9, 266);

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Melee);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(tableName), Times.Once);
        }

        [Test]
        public void GetRangedAbilityIfRanged()
        {
            item.ItemType = ItemTypeConstants.Weapon;
            itemAttributes.Add(AttributeConstants.Ranged);
            CreateSpecialAbility("name", "base name", 9, 266);

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Ranged);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(tableName), Times.Once);
        }

        [Test]
        public void GetArmorAbilityIfArmor()
        {
            CreateSpecialAbility("name", "base name", 9, 266);

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, ItemTypeConstants.Armor);
            mockPercentileSelector.Verify(s => s.SelectAllFrom(tableName), Times.Once);
        }

        [Test]
        public void ReturnEmptyIfNoMatchingTableNames()
        {
            item.ItemType = "wrong item type";
            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void SetAbilityByResult()
        {
            CreateSpecialAbility("name", "base name", 9, 266);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns("name");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var ability = abilities.First();
            Assert.That(ability.AttributeRequirements, Is.EqualTo(itemAttributes));
            Assert.That(ability.Name, Is.EqualTo("name"));
            Assert.That(ability.BaseName, Is.EqualTo("base name"));
            Assert.That(ability.Power, Is.EqualTo(266));
            Assert.That(ability.BonusEquivalent, Is.EqualTo(9));
            Assert.That(ability.Damages, Is.Empty);
            Assert.That(ability.CriticalDamages, Is.Empty);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAbilities()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3");
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>()))
                .Returns("ability 1")
                .Returns("ability 2")
                .Returns("ability 3");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 3);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 3"));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void SetDamage()
        {
            CreateSpecialAbility("name", "base name", 9, 266);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns("name");

            var damage = damageHelper.BuildEntry("my roll", "my damage type");
            mockCollectionsSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "name"))
                .Returns(new[] { damage, string.Empty, string.Empty, string.Empty });

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var ability = abilities.First();
            Assert.That(ability.AttributeRequirements, Is.EqualTo(itemAttributes));
            Assert.That(ability.Name, Is.EqualTo("name"));
            Assert.That(ability.BaseName, Is.EqualTo("base name"));
            Assert.That(ability.Power, Is.EqualTo(266));
            Assert.That(ability.BonusEquivalent, Is.EqualTo(9));
            Assert.That(ability.Damages, Has.Count.EqualTo(1));
            Assert.That(ability.Damages[0].Roll, Is.EqualTo("my roll"));
            Assert.That(ability.Damages[0].Type, Is.EqualTo("my damage type"));
            Assert.That(ability.CriticalDamages, Is.Empty);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void SetCriticalDamages()
        {
            CreateSpecialAbility("name", "base name", 9, 266);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns("name");

            var damage1 = damageHelper.BuildEntry("my roll", "my damage type");
            var damage2 = damageHelper.BuildEntry("my other roll", "my other damage type");
            var damage3 = damageHelper.BuildEntry("my third roll", "my third damage type");
            mockCollectionsSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "name"))
                .Returns(new[] { string.Empty, damage1, damage2, damage3 });

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var ability = abilities.First();
            Assert.That(ability.AttributeRequirements, Is.EqualTo(itemAttributes));
            Assert.That(ability.Name, Is.EqualTo("name"));
            Assert.That(ability.BaseName, Is.EqualTo("base name"));
            Assert.That(ability.Power, Is.EqualTo(266));
            Assert.That(ability.BonusEquivalent, Is.EqualTo(9));
            Assert.That(ability.Damages, Is.Empty);
            Assert.That(ability.CriticalDamages, Has.Count.EqualTo(3)
                .And.ContainKey("x2")
                .And.ContainKey("x3")
                .And.ContainKey("x4"));
            Assert.That(ability.CriticalDamages["x2"], Has.Count.EqualTo(1));
            Assert.That(ability.CriticalDamages["x2"][0].Roll, Is.EqualTo("my roll"));
            Assert.That(ability.CriticalDamages["x2"][0].Type, Is.EqualTo("my damage type"));
            Assert.That(ability.CriticalDamages["x3"], Has.Count.EqualTo(1));
            Assert.That(ability.CriticalDamages["x3"][0].Roll, Is.EqualTo("my other roll"));
            Assert.That(ability.CriticalDamages["x3"][0].Type, Is.EqualTo("my other damage type"));
            Assert.That(ability.CriticalDamages["x4"], Has.Count.EqualTo(1));
            Assert.That(ability.CriticalDamages["x4"][0].Roll, Is.EqualTo("my third roll"));
            Assert.That(ability.CriticalDamages["x4"][0].Type, Is.EqualTo("my third damage type"));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void SetDamageAndCriticalDamages()
        {
            CreateSpecialAbility("name", "base name", 9, 266);
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns("name");

            var damage1 = damageHelper.BuildEntry("my roll", "my damage type");
            var damage2 = damageHelper.BuildEntry("my other roll", "my other damage type");
            var damage3 = damageHelper.BuildEntry("my third roll", "my third damage type");
            var damage4 = damageHelper.BuildEntry("my last roll", "my last damage type");
            mockCollectionsSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "name"))
                .Returns(new[] { damage1, damage2, damage3, damage4 });

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var ability = abilities.First();
            Assert.That(ability.AttributeRequirements, Is.EqualTo(itemAttributes));
            Assert.That(ability.Name, Is.EqualTo("name"));
            Assert.That(ability.BaseName, Is.EqualTo("base name"));
            Assert.That(ability.Power, Is.EqualTo(266));
            Assert.That(ability.BonusEquivalent, Is.EqualTo(9));
            Assert.That(ability.Damages, Has.Count.EqualTo(1));
            Assert.That(ability.Damages[0].Roll, Is.EqualTo("my roll"));
            Assert.That(ability.Damages[0].Type, Is.EqualTo("my damage type"));
            Assert.That(ability.CriticalDamages, Has.Count.EqualTo(3)
                .And.ContainKey("x2")
                .And.ContainKey("x3")
                .And.ContainKey("x4"));
            Assert.That(ability.CriticalDamages["x2"], Has.Count.EqualTo(1));
            Assert.That(ability.CriticalDamages["x2"][0].Roll, Is.EqualTo("my other roll"));
            Assert.That(ability.CriticalDamages["x2"][0].Type, Is.EqualTo("my other damage type"));
            Assert.That(ability.CriticalDamages["x3"], Has.Count.EqualTo(1));
            Assert.That(ability.CriticalDamages["x3"][0].Roll, Is.EqualTo("my third roll"));
            Assert.That(ability.CriticalDamages["x3"][0].Type, Is.EqualTo("my third damage type"));
            Assert.That(ability.CriticalDamages["x4"], Has.Count.EqualTo(1));
            Assert.That(ability.CriticalDamages["x4"][0].Roll, Is.EqualTo("my last roll"));
            Assert.That(ability.CriticalDamages["x4"][0].Type, Is.EqualTo("my last damage type"));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void WeaponsThatAreBothMeleeAndRangedGetRandomlyBetweenTables()
        {
            item.ItemType = ItemTypeConstants.Weapon;
            itemAttributes.Add(AttributeConstants.Melee);
            itemAttributes.Add(AttributeConstants.Ranged);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Melee);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[] { "melee ability" });
            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Ranged);
            mockPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[] { "ranged ability" });

            var meleeResult = new SpecialAbilitySelection();
            meleeResult.BaseName = "melee ability";
            mockSpecialAbilityDataSelector.Setup(s => s.SelectFrom(meleeResult.BaseName)).Returns(meleeResult);
            mockCollectionsSelector.Setup(p => p.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, meleeResult.BaseName)).Returns(itemAttributes);

            var rangedResult = new SpecialAbilitySelection();
            rangedResult.BaseName = "ranged ability";
            mockSpecialAbilityDataSelector.Setup(s => s.SelectFrom(rangedResult.BaseName)).Returns(rangedResult);
            mockCollectionsSelector.Setup(p => p.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, rangedResult.BaseName)).Returns(itemAttributes);

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 2);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);

            Assert.That(names, Contains.Item("melee ability"));
            Assert.That(names, Contains.Item("ranged ability"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void DoNotAllowAbilitiesAndMagicBonusToBeGreaterThan10()
        {
            item.Magic.Bonus = 9;

            CreateSpecialAbility("big ability", bonus: 2);
            CreateSpecialAbility("small ability", bonus: 1);

            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>()))
                .Returns("big ability")
                .Returns("small ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("small ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void AccumulateSpecialAbilities()
        {
            item.Magic.Bonus = 5;

            CreateSpecialAbility("ability 1", bonus: 2);
            CreateSpecialAbility("ability 2", bonus: 2);
            CreateSpecialAbility("ability 3", bonus: 3);
            CreateSpecialAbility("ability 4", bonus: 0);

            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>()))
                .Returns("ability 1")
                .Returns("ability 2")
                .Returns("ability 3")
                .Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 3);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void ReplaceWeakWithStrong()
        {
            CreateSpecialAbility("weak ability", "ability", power: 1);
            CreateSpecialAbility("strong ability", "ability", power: 2);

            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>()))
                .Returns("weak ability")
                .Returns("strong ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 2);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("strong ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void DoNotCompareStrengthForDissimilarCoreName()
        {
            CreateSpecialAbility("weak ability", power: 1);
            CreateSpecialAbility("strong ability", power: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("weak ability").Returns("strong ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 2);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("weak ability"));
            Assert.That(names, Contains.Item("strong ability"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void DoNotReplaceStrongWithWeak()
        {
            CreateSpecialAbility("strong ability", "ability", power: 2);
            CreateSpecialAbility("weak ability", "ability", power: 1);
            CreateSpecialAbility("other ability");
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("strong ability").Returns("weak ability")
                .Returns("other ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 2);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("strong ability"));
            Assert.That(names, Is.Not.Contains("weak ability"));
        }

        [Test]
        public void SpecialAbilitiesMaxOutAtBonusOf10()
        {
            CreateSpecialAbility("ability 1", bonus: 2);
            CreateSpecialAbility("ability 2", bonus: 2);
            CreateSpecialAbility("ability 3", bonus: 3);
            CreateSpecialAbility("ability 4", bonus: 3);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3").Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 4);
            Assert.That(abilities, Is.Not.Empty);

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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 2);
            Assert.That(abilities, Is.Not.Empty);

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
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 1").Returns("ability 1")
                .Returns("ability 2");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 2);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void SpecialAbilitiesFilteredByAttributeRequirementsFromBaseName()
        {
            CreateSpecialAbility("ability 1", "base ability 1");
            CreateSpecialAbility("ability 2", "base ability 2");
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 1").Returns("ability 2");

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base ability 1")).Returns(new[] { "other type", "type 1" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base ability 2")).Returns(itemAttributes);

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void SpecialAbilitiesFilteredByEitherAttributeRequirementsFromBaseName()
        {
            itemAttributes.Add("or");

            CreateSpecialAbility("ability 1", "base ability 1");
            CreateSpecialAbility("ability 2", "base ability 2");
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 1").Returns("ability 2");

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base ability 1")).Returns(new[] { "other/order/of/type", "type 1" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base ability 2")).Returns(new[] { "either/or" });

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ExtraAttributesDoNotMatter()
        {
            CreateSpecialAbility("ability");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns("ability");
            itemAttributes.Add("type 1");
            item.Attributes = itemAttributes.Union(new[] { "other type" });

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability"));
            Assert.That(names.Count(), Is.EqualTo(1));
        }

        [Test]
        public void BonusSpecialAbilitiesAdded()
        {
            CreateSpecialAbility("ability 1", "base ability 1");
            CreateSpecialAbility("ability 2", "base ability 2");
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>()))
                .Returns("BonusSpecialAbility")
                .Returns("ability 1")
                .Returns("ability 2");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void StopIfAllPossibleAbilitiesAcquired()
        {
            CreateSpecialAbility("ability");
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns("ability");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 5);
            Assert.That(abilities, Is.Not.Empty);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CountSameCoreNameAsSameAbility()
        {
            CreateSpecialAbility("ability 1", "base name", power: 1);
            CreateSpecialAbility("ability 2", "base name", power: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 1").Returns("ability 2");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 5);
            Assert.That(abilities, Is.Not.Empty);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ReturnEmptyIfNoCompatibleAbilities()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom(It.IsAny<string>())).Returns(Enumerable.Empty<string>());
            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void ReturnAllAbilitiesWithStrongestIfQuantityGreaterThanOrEqualToAllAvailableAbilities()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3", "ability", power: 1);
            CreateSpecialAbility("ability 4", "ability", power: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3").Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 4);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void DoNotReturnAbilitiesWithBonusSumGreaterThan10()
        {
            CreateSpecialAbility("ability 1", bonus: 3);
            CreateSpecialAbility("ability 2", bonus: 3);
            CreateSpecialAbility("ability 3", bonus: 3);
            CreateSpecialAbility("ability 4", bonus: 3);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 1").Returns("ability 2")
                .Returns("ability 3").Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 5);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 3"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void RemoveWeakerAbilitiesFromAvailableWhenStrongAdded()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3", "ability", power: 1);
            CreateSpecialAbility("ability 4", "ability", power: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 4").Returns("ability 2")
                .Returns("ability 3").Returns("ability 1");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 3);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void WhenAddingAllAbilities_UpgradeAllWeakAbilities()
        {
            CreateSpecialAbility("ability 1");
            CreateSpecialAbility("ability 2");
            CreateSpecialAbility("ability 3", "ability", power: 1);
            CreateSpecialAbility("ability 4", "ability", power: 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(It.IsAny<string>())).Returns("ability 3").Returns("BonusSpecialAbility")
                .Returns("ability 2").Returns("ability 1").Returns("ability 4");

            var abilities = specialAbilitiesGenerator.GenerateFor(item, power, 3);
            Assert.That(abilities, Is.Not.Empty);

            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item("ability 1"));
            Assert.That(names, Contains.Item("ability 2"));
            Assert.That(names, Contains.Item("ability 4"));
            Assert.That(names.Count(), Is.EqualTo(3));
            mockPercentileSelector.Verify(p => p.SelectFrom(It.IsAny<string>()), Times.Exactly(2));
        }

        private void CreateSpecialAbility(string name, string baseName = "", int bonus = 0, int power = 0)
        {
            var result = new SpecialAbilitySelection();

            if (string.IsNullOrEmpty(baseName))
                result.BaseName = name;
            else
                result.BaseName = baseName;

            result.BonusEquivalent = bonus;
            result.Power = power;
            names.Add(name);

            mockSpecialAbilityDataSelector.Setup(s => s.SelectFrom(name)).Returns(result);
            mockCollectionsSelector.Setup(p => p.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, result.BaseName)).Returns(itemAttributes);
        }

        [Test]
        public void CreateSetSpecialAbilities()
        {
            CreateSpecialAbility("ability 1", "base 1", 9266, 90210);
            CreateSpecialAbility("ability 2", "base 2", 42, 600);
            CreateSpecialAbility("ability 3", "base 3", 1337, 1234);

            var attributeRequirements = new List<IEnumerable<string>>();
            attributeRequirements.Add(new[] { "other type 1", "type 1" });
            attributeRequirements.Add(new[] { "other type 2", "type 2" });
            attributeRequirements.Add(new[] { "other type 3", "type 3" });

            mockSpecialAbilityDataSelector.Setup(s => s.IsSpecialAbility("ability 1")).Returns(true);
            mockSpecialAbilityDataSelector.Setup(s => s.IsSpecialAbility("ability 2")).Returns(true);
            mockSpecialAbilityDataSelector.Setup(s => s.IsSpecialAbility("ability 3")).Returns(true);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base 1")).Returns(attributeRequirements[0]);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base 2")).Returns(attributeRequirements[1]);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base 3")).Returns(attributeRequirements[2]);

            var damage = damageHelper.BuildEntry("my roll", "my damage type");
            mockCollectionsSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "ability 2"))
                .Returns(new[] { damage, string.Empty, string.Empty, string.Empty });

            var damage1 = damageHelper.BuildEntry("my roll", "my damage type");
            var damage2 = damageHelper.BuildEntry("my other roll", "my other damage type");
            var damage3 = damageHelper.BuildEntry("my third roll", "my third damage type");
            mockCollectionsSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "ability 3"))
                .Returns(new[] { string.Empty, damage1, damage2, damage3 });

            var abilityPrototypes = new[]
            {
                new SpecialAbility { Name = "ability 1" },
                new SpecialAbility { Name = "ability 2" },
                new SpecialAbility { Name = "ability 3" },
            };

            var abilities = specialAbilitiesGenerator.GenerateFor(abilityPrototypes);
            Assert.That(abilities, Is.Not.Empty);

            var abilityArray = abilities.ToArray();
            Assert.That(abilityArray[0].Name, Is.EqualTo("ability 1"));
            Assert.That(abilityArray[0].BaseName, Is.EqualTo("base 1"));
            Assert.That(abilityArray[0].AttributeRequirements, Is.EqualTo(attributeRequirements[0]));
            Assert.That(abilityArray[0].Power, Is.EqualTo(90210));
            Assert.That(abilityArray[0].BonusEquivalent, Is.EqualTo(9266));
            Assert.That(abilityArray[0].Damages, Is.Empty);
            Assert.That(abilityArray[0].CriticalDamages, Is.Empty);
            Assert.That(abilityArray[1].Name, Is.EqualTo("ability 2"));
            Assert.That(abilityArray[1].BaseName, Is.EqualTo("base 2"));
            Assert.That(abilityArray[1].AttributeRequirements, Is.EqualTo(attributeRequirements[1]));
            Assert.That(abilityArray[1].Power, Is.EqualTo(600));
            Assert.That(abilityArray[1].BonusEquivalent, Is.EqualTo(42));
            Assert.That(abilityArray[1].Damages, Has.Count.EqualTo(1));
            Assert.That(abilityArray[1].Damages[0].Roll, Is.EqualTo("my roll"));
            Assert.That(abilityArray[1].Damages[0].Type, Is.EqualTo("my damage type"));
            Assert.That(abilityArray[1].CriticalDamages, Is.Empty);
            Assert.That(abilityArray[2].Name, Is.EqualTo("ability 3"));
            Assert.That(abilityArray[2].BaseName, Is.EqualTo("base 3"));
            Assert.That(abilityArray[2].AttributeRequirements, Is.EqualTo(attributeRequirements[2]));
            Assert.That(abilityArray[2].Power, Is.EqualTo(1234));
            Assert.That(abilityArray[2].BonusEquivalent, Is.EqualTo(1337));
            Assert.That(abilityArray[2].Damages, Is.Empty);
            Assert.That(abilityArray[2].CriticalDamages, Has.Count.EqualTo(3)
                .And.ContainKey("x2")
                .And.ContainKey("x3")
                .And.ContainKey("x4"));
            Assert.That(abilityArray[2].CriticalDamages["x2"], Has.Count.EqualTo(1));
            Assert.That(abilityArray[2].CriticalDamages["x2"][0].Roll, Is.EqualTo("my roll"));
            Assert.That(abilityArray[2].CriticalDamages["x2"][0].Type, Is.EqualTo("my damage type"));
            Assert.That(abilityArray[2].CriticalDamages["x3"], Has.Count.EqualTo(1));
            Assert.That(abilityArray[2].CriticalDamages["x3"][0].Roll, Is.EqualTo("my other roll"));
            Assert.That(abilityArray[2].CriticalDamages["x3"][0].Type, Is.EqualTo("my other damage type"));
            Assert.That(abilityArray[2].CriticalDamages["x4"], Has.Count.EqualTo(1));
            Assert.That(abilityArray[2].CriticalDamages["x4"][0].Roll, Is.EqualTo("my third roll"));
            Assert.That(abilityArray[2].CriticalDamages["x4"][0].Type, Is.EqualTo("my third damage type"));
            Assert.That(abilityArray.Length, Is.EqualTo(3));
        }

        [Test]
        public void CreateCustomSpecialAbilities()
        {
            CreateSpecialAbility("ability 1", "base 1", 9266, 90210);
            CreateSpecialAbility("ability 2", "base 2", 42, 600);
            CreateSpecialAbility("ability 3", "base 3", 1337, 1234);

            var attributeRequirements = new List<IEnumerable<string>>();
            attributeRequirements.Add(new[] { "other type 1", "type 1" });
            attributeRequirements.Add(new[] { "other type 2", "type 2" });
            attributeRequirements.Add(new[] { "other type 3", "type 3" });

            mockSpecialAbilityDataSelector.Setup(s => s.IsSpecialAbility("ability 1")).Returns(false);
            mockSpecialAbilityDataSelector.Setup(s => s.IsSpecialAbility("ability 2")).Returns(false);
            mockSpecialAbilityDataSelector.Setup(s => s.IsSpecialAbility("ability 3")).Returns(false);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base 1")).Returns(attributeRequirements[0]);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base 2")).Returns(attributeRequirements[1]);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base 3")).Returns(attributeRequirements[2]);

            var damage = damageHelper.BuildEntry("my roll", "my damage type");
            mockCollectionsSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "ability 2"))
                .Returns(new[] { damage, string.Empty, string.Empty, string.Empty });

            var damage1 = damageHelper.BuildEntry("my roll", "my damage type");
            var damage2 = damageHelper.BuildEntry("my other roll", "my other damage type");
            var damage3 = damageHelper.BuildEntry("my third roll", "my third damage type");
            mockCollectionsSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "ability 3"))
                .Returns(new[] { string.Empty, damage1, damage2, damage3 });

            var abilityPrototypes = new[]
            {
                new SpecialAbility { Name = "ability 1", BaseName = "custom base 1", BonusEquivalent = 2345, Power = 9876 },
                new SpecialAbility { Name = "ability 2", BaseName = "custom base 2", BonusEquivalent = 3456, Power = 8765 },
                new SpecialAbility { Name = "ability 3", BaseName = "custom base 3", BonusEquivalent = 4567, Power = 7654 },
            };

            var abilities = specialAbilitiesGenerator.GenerateFor(abilityPrototypes);
            Assert.That(abilities, Is.Not.Empty);

            var abilityArray = abilities.ToArray();
            Assert.That(abilityArray[0].AttributeRequirements, Is.Empty);
            Assert.That(abilityArray[0].Name, Is.EqualTo("ability 1"));
            Assert.That(abilityArray[0].BaseName, Is.EqualTo("custom base 1"));
            Assert.That(abilityArray[0].Power, Is.EqualTo(9876));
            Assert.That(abilityArray[0].BonusEquivalent, Is.EqualTo(2345));
            Assert.That(abilityArray[0].Damages, Is.Empty);
            Assert.That(abilityArray[0].CriticalDamages, Is.Empty);
            Assert.That(abilityArray[1].AttributeRequirements, Is.Empty);
            Assert.That(abilityArray[1].Name, Is.EqualTo("ability 2"));
            Assert.That(abilityArray[1].BaseName, Is.EqualTo("custom base 2"));
            Assert.That(abilityArray[1].Power, Is.EqualTo(8765));
            Assert.That(abilityArray[1].BonusEquivalent, Is.EqualTo(3456));
            Assert.That(abilityArray[1].Damages, Has.Count.EqualTo(1));
            Assert.That(abilityArray[1].Damages[0].Roll, Is.EqualTo("my roll"));
            Assert.That(abilityArray[1].Damages[0].Type, Is.EqualTo("my damage type"));
            Assert.That(abilityArray[1].CriticalDamages, Is.Empty);
            Assert.That(abilityArray[2].AttributeRequirements, Is.Empty);
            Assert.That(abilityArray[2].Name, Is.EqualTo("ability 3"));
            Assert.That(abilityArray[2].BaseName, Is.EqualTo("custom base 3"));
            Assert.That(abilityArray[2].Power, Is.EqualTo(7654));
            Assert.That(abilityArray[2].BonusEquivalent, Is.EqualTo(4567));
            Assert.That(abilityArray[2].Damages, Is.Empty);
            Assert.That(abilityArray[2].CriticalDamages, Has.Count.EqualTo(3)
                .And.ContainKey("x2")
                .And.ContainKey("x3")
                .And.ContainKey("x4"));
            Assert.That(abilityArray[2].CriticalDamages["x2"], Has.Count.EqualTo(1));
            Assert.That(abilityArray[2].CriticalDamages["x2"][0].Roll, Is.EqualTo("my roll"));
            Assert.That(abilityArray[2].CriticalDamages["x2"][0].Type, Is.EqualTo("my damage type"));
            Assert.That(abilityArray[2].CriticalDamages["x3"], Has.Count.EqualTo(1));
            Assert.That(abilityArray[2].CriticalDamages["x3"][0].Roll, Is.EqualTo("my other roll"));
            Assert.That(abilityArray[2].CriticalDamages["x3"][0].Type, Is.EqualTo("my other damage type"));
            Assert.That(abilityArray[2].CriticalDamages["x4"], Has.Count.EqualTo(1));
            Assert.That(abilityArray[2].CriticalDamages["x4"][0].Roll, Is.EqualTo("my third roll"));
            Assert.That(abilityArray[2].CriticalDamages["x4"][0].Type, Is.EqualTo("my third damage type"));
            Assert.That(abilityArray.Length, Is.EqualTo(3));
        }

        [Test]
        public void CreateSetAndCustomSpecialAbilities()
        {
            CreateSpecialAbility("ability 1", "base 1", 9266, 90210);
            CreateSpecialAbility("ability 2", "base 2", 42, 600);
            CreateSpecialAbility("ability 3", "base 3", 1337, 1234);

            var attributeRequirements = new List<IEnumerable<string>>();
            attributeRequirements.Add(new[] { "other type 1", "type 1" });
            attributeRequirements.Add(new[] { "other type 2", "type 2" });
            attributeRequirements.Add(new[] { "other type 3", "type 3" });

            mockSpecialAbilityDataSelector.Setup(s => s.IsSpecialAbility("ability 1")).Returns(true);
            mockSpecialAbilityDataSelector.Setup(s => s.IsSpecialAbility("ability 2")).Returns(false);
            mockSpecialAbilityDataSelector.Setup(s => s.IsSpecialAbility("ability 3")).Returns(true);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base 1")).Returns(attributeRequirements[0]);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base 2")).Returns(attributeRequirements[1]);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, "base 3")).Returns(attributeRequirements[2]);

            var damage = damageHelper.BuildEntry("my roll", "my damage type");
            mockCollectionsSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "ability 2"))
                .Returns(new[] { damage, string.Empty, string.Empty, string.Empty });

            var damage1 = damageHelper.BuildEntry("my roll", "my damage type");
            var damage2 = damageHelper.BuildEntry("my other roll", "my other damage type");
            var damage3 = damageHelper.BuildEntry("my third roll", "my third damage type");
            mockCollectionsSelector
                .Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "ability 3"))
                .Returns(new[] { string.Empty, damage1, damage2, damage3 });

            var abilityPrototypes = new[]
            {
                new SpecialAbility { Name = "ability 1", BaseName = "custom base 1", BonusEquivalent = 2345, Power = 9876 },
                new SpecialAbility { Name = "ability 2", BaseName = "custom base 2", BonusEquivalent = 3456, Power = 8765 },
                new SpecialAbility { Name = "ability 3", BaseName = "custom base 3", BonusEquivalent = 4567, Power = 7654 },
            };

            var abilities = specialAbilitiesGenerator.GenerateFor(abilityPrototypes);
            Assert.That(abilities, Is.Not.Empty);

            var abilityArray = abilities.ToArray();
            Assert.That(abilityArray[0].Name, Is.EqualTo("ability 1"));
            Assert.That(abilityArray[0].BaseName, Is.EqualTo("base 1"));
            Assert.That(abilityArray[0].AttributeRequirements, Is.EqualTo(attributeRequirements[0]));
            Assert.That(abilityArray[0].Power, Is.EqualTo(90210));
            Assert.That(abilityArray[0].BonusEquivalent, Is.EqualTo(9266));
            Assert.That(abilityArray[0].Damages, Is.Empty);
            Assert.That(abilityArray[0].CriticalDamages, Is.Empty);
            Assert.That(abilityArray[1].Name, Is.EqualTo("ability 2"));
            Assert.That(abilityArray[1].BaseName, Is.EqualTo("custom base 2"));
            Assert.That(abilityArray[1].AttributeRequirements, Is.Empty);
            Assert.That(abilityArray[1].Power, Is.EqualTo(8765));
            Assert.That(abilityArray[1].BonusEquivalent, Is.EqualTo(3456));
            Assert.That(abilityArray[1].Damages, Has.Count.EqualTo(1));
            Assert.That(abilityArray[1].Damages[0].Roll, Is.EqualTo("my roll"));
            Assert.That(abilityArray[1].Damages[0].Type, Is.EqualTo("my damage type"));
            Assert.That(abilityArray[1].CriticalDamages, Is.Empty);
            Assert.That(abilityArray[2].Name, Is.EqualTo("ability 3"));
            Assert.That(abilityArray[2].BaseName, Is.EqualTo("base 3"));
            Assert.That(abilityArray[2].AttributeRequirements, Is.EqualTo(attributeRequirements[2]));
            Assert.That(abilityArray[2].Power, Is.EqualTo(1234));
            Assert.That(abilityArray[2].BonusEquivalent, Is.EqualTo(1337));
            Assert.That(abilityArray[2].Damages, Is.Empty);
            Assert.That(abilityArray[2].CriticalDamages, Has.Count.EqualTo(3)
                .And.ContainKey("x2")
                .And.ContainKey("x3")
                .And.ContainKey("x4"));
            Assert.That(abilityArray[2].CriticalDamages["x2"], Has.Count.EqualTo(1));
            Assert.That(abilityArray[2].CriticalDamages["x2"][0].Roll, Is.EqualTo("my roll"));
            Assert.That(abilityArray[2].CriticalDamages["x2"][0].Type, Is.EqualTo("my damage type"));
            Assert.That(abilityArray[2].CriticalDamages["x3"], Has.Count.EqualTo(1));
            Assert.That(abilityArray[2].CriticalDamages["x3"][0].Roll, Is.EqualTo("my other roll"));
            Assert.That(abilityArray[2].CriticalDamages["x3"][0].Type, Is.EqualTo("my other damage type"));
            Assert.That(abilityArray[2].CriticalDamages["x4"], Has.Count.EqualTo(1));
            Assert.That(abilityArray[2].CriticalDamages["x4"][0].Roll, Is.EqualTo("my third roll"));
            Assert.That(abilityArray[2].CriticalDamages["x4"][0].Type, Is.EqualTo("my third damage type"));
            Assert.That(abilityArray.Length, Is.EqualTo(3));
        }
    }
}