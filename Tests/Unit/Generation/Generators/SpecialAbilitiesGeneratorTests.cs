using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorTests
    {
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private Mock<ISpecialAbilityPercentileResultProvider> mockSpecialAbilityPercentileResultProvider;
        private Mock<ITypesProvider> mockTypesProvider;

        private List<String> types;

        [SetUp]
        public void Setup()
        {
            types = new List<String>();
            types.Add(ItemsConstants.ItemTypes.Armor);

            mockSpecialAbilityPercentileResultProvider = new Mock<ISpecialAbilityPercentileResultProvider>();
            mockTypesProvider = new Mock<ITypesProvider>();

            specialAbilitiesGenerator = new SpecialAbilitiesGenerator(mockSpecialAbilityPercentileResultProvider.Object,
                mockTypesProvider.Object);
        }

        [Test]
        public void SpecialAbilitiesGeneratorReturnsEmptyIfBonusLessThanOne()
        {
            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 0, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsShieldAbilityIfShield()
        {
            types.Add(ItemsConstants.Gear.Types.Shield);
            var shieldAbility = new SpecialAbilityPercentileResult();
            shieldAbility.Name = "shield ability";
            mockSpecialAbilityPercentileResultProvider.Setup(p => p.GetResultFrom("powerShieldSpecialAbilities")).Returns(shieldAbility);

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability.Name, Is.EqualTo(shieldAbility.Name));
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsMeleeWeaponAbilityIfMeleeWeapon()
        {
            types.Add(ItemsConstants.Gear.Types.Melee);
            var meleeWeaponAbility = new SpecialAbilityPercentileResult();
            meleeWeaponAbility.Name = "melee weapon ability";
            mockSpecialAbilityPercentileResultProvider.Setup(p => p.GetResultFrom("powerMeleeWeaponSpecialAbilities")).Returns(meleeWeaponAbility);

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability.Name, Is.EqualTo(meleeWeaponAbility.Name));
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsRangedWeaponAbilityIfRangedWeapon()
        {
            types.Add(ItemsConstants.Gear.Types.Ranged);
            var rangedWeaponAbility = new SpecialAbilityPercentileResult();
            rangedWeaponAbility.Name = "ranged weapon ability";
            mockSpecialAbilityPercentileResultProvider.Setup(p => p.GetResultFrom("powerRangedWeaponSpecialAbilities")).Returns(rangedWeaponAbility);

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability.Name, Is.EqualTo(rangedWeaponAbility.Name));
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsArmorAbilityIfArmor()
        {
            var armorAbility = new SpecialAbilityPercentileResult();
            armorAbility.Name = "armor ability";
            mockSpecialAbilityPercentileResultProvider.Setup(p => p.GetResultFrom("powerArmorSpecialAbilities")).Returns(armorAbility);

            var ability = specialAbilitiesGenerator.GenerateFor(types, "power");
            Assert.That(ability.Name, Is.EqualTo(armorAbility.Name));
        }

        [Test]
        public void SpecialAbilitiesGeneratorSingularThrowsErrorIfNotValidTypes()
        {
            Assert.That(() => specialAbilitiesGenerator.GenerateFor(new[] { "invalid type" }, "power"), Throws.ArgumentException);
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsAbilities()
        {
            var ability1 = new SpecialAbilityPercentileResult() { Name = "ability 1" };
            var ability2 = new SpecialAbilityPercentileResult() { Name = "ability 2" };
            var ability3 = new SpecialAbilityPercentileResult() { Name = "ability 3" };

            mockSpecialAbilityPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(ability1).Returns(ability2).Returns(ability3);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item(ability1.Name));
            Assert.That(names, Contains.Item(ability2.Name));
            Assert.That(names, Contains.Item(ability3.Name));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void SpecialAbilitiesGeneratorWillNotAllowAbilitiesAndMagicBonusToBeGreaterThan10()
        {
            var bigAbility = new SpecialAbilityPercentileResult();
            bigAbility.Name = "big ability";
            bigAbility.Bonus = 2;
            var smallAbility = new SpecialAbilityPercentileResult();
            smallAbility.Name = "small ability";
            smallAbility.Bonus = 1;

            mockSpecialAbilityPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(bigAbility).Returns(smallAbility);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 9, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(smallAbility.Name));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void SpecialAbilitiesGeneratorAccumulatesAbilities()
        {
            var ability1 = new SpecialAbilityPercentileResult() { Name = "ability 1", Bonus = 1 };
            var ability2 = new SpecialAbilityPercentileResult() { Name = "ability 2", Bonus = 2 };
            var ability3 = new SpecialAbilityPercentileResult() { Name = "ability 3", Bonus = 3 };
            var ability4 = new SpecialAbilityPercentileResult() { Name = "ability 4", Bonus = 0 };

            mockSpecialAbilityPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(ability1).Returns(ability2).Returns(ability3).Returns(ability4);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 5, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item(ability1.Name));
            Assert.That(names, Contains.Item(ability2.Name));
            Assert.That(names, Contains.Item(ability4.Name));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void SpecialAbilitiesGeneratorUsesMostPowerfulVersionOfAbility()
        {
            var strongAbility = new SpecialAbilityPercentileResult();
            strongAbility.Name = "strong ability";
            strongAbility.CoreName = "ability";
            strongAbility.Strength = 2;
            var weakAbility = new SpecialAbilityPercentileResult();
            weakAbility.Name = "weak ability";
            weakAbility.CoreName = "ability";
            weakAbility.Strength = 1;
            var otherAbility = new SpecialAbilityPercentileResult();
            otherAbility.Name = "other ability";

            mockSpecialAbilityPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(strongAbility).Returns(weakAbility).Returns(otherAbility);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 2);
            var first = abilities.First();
            Assert.That(first.Strength, Is.EqualTo(strongAbility.Strength));
            Assert.That(abilities.Count(), Is.EqualTo(1));

            mockSpecialAbilityPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(weakAbility).Returns(strongAbility);

            abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 2);
            Assert.That(abilities.Count(), Is.EqualTo(1));

            first = abilities.First();
            Assert.That(first.Name, Is.EqualTo(strongAbility.Name));
            Assert.That(first.Strength, Is.EqualTo(strongAbility.Strength));
        }

        [Test]
        public void AbilitiesMaxOutAtBonusOf10()
        {
            var ability1 = new SpecialAbilityPercentileResult();
            ability1.Name = "ability 1";
            ability1.Bonus = 3;
            var ability2 = new SpecialAbilityPercentileResult();
            ability2.Name = "ability 2";
            ability2.Bonus = 3;
            var ability3 = new SpecialAbilityPercentileResult();
            ability3.Name = "ability 3";
            ability3.Bonus = 3;
            var ability4 = new SpecialAbilityPercentileResult();
            ability4.Name = "ability 4";
            ability4.Bonus = 1;

            mockSpecialAbilityPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(ability1).Returns(ability2).Returns(ability3).Returns(ability4);

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
            var ability = new SpecialAbilityPercentileResult();
            ability.Name = "ability";
            ability.Bonus = 1;
            var otherAbility = new SpecialAbilityPercentileResult();
            otherAbility.Name = "other ability";

            mockSpecialAbilityPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(ability).Returns(ability).Returns(otherAbility);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 2);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item(ability.Name));
            Assert.That(names, Contains.Item(otherAbility.Name));
            Assert.That(names.Count(), Is.EqualTo(2));
        }

        [Test]
        public void AbilitiesFilteredByTypeRequirements()
        {
            var ability1 = new SpecialAbilityPercentileResult();
            ability1.Name = "ability 1";
            var ability2 = new SpecialAbilityPercentileResult();
            ability2.Name = "ability 2";

            mockSpecialAbilityPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(ability1).Returns(ability2);

            types.Add("type 1");
            types.Add("type 2");
            mockTypesProvider.Setup(p => p.GetTypesFor(ability1.Name, "SpecialAbilityTypes")).Returns(new[] { "other type", "type 1" });
            mockTypesProvider.Setup(p => p.GetTypesFor(ability2.Name, "SpecialAbilityTypes")).Returns(types);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(ability2.Name));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ExtraTypesDoNotMatter()
        {
            var ability = new SpecialAbilityPercentileResult();
            ability.Name = "ability 1";

            mockSpecialAbilityPercentileResultProvider.Setup(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(ability);

            types.Add("type 1");
            mockTypesProvider.Setup(p => p.GetTypesFor(ability.Name, "SpecialAbilityTypes")).Returns(types);

            var inputTypes = types.Union(new[] { "other type" });
            var abilities = specialAbilitiesGenerator.GenerateFor(inputTypes, "power", 1, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(ability.Name));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void BonusSpecialAbilitiesAdded()
        {
            var bonusAbility = new SpecialAbilityPercentileResult();
            bonusAbility.Name = "BonusSpecialAbility";
            var ability1 = new SpecialAbilityPercentileResult();
            ability1.Name = "ability 1";
            var ability2 = new SpecialAbilityPercentileResult();
            ability2.Name = "ability 2";

            mockSpecialAbilityPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmorSpecialAbilities"))
                .Returns(bonusAbility).Returns(ability1).Returns(ability2);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 1);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item(ability2.Name));
            Assert.That(names, Contains.Item(ability1.Name));
            Assert.That(names.Count(), Is.EqualTo(2));
        }
    }
}