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
    public class GearSpecialAbilitiesGeneratorTests
    {
        private IGearSpecialAbilitiesGenerator specialAbilitiesGenerator;
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;

        private List<String> types;

        [SetUp]
        public void Setup()
        {
            types = new List<String>();
            types.Add(ItemsConstants.ItemTypes.Armor);
            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();

            specialAbilitiesGenerator = new GearSpecialAbilitiesGenerator(mockTypeAndAmountPercentileResultProvider.Object);
        }

        [Test]
        public void SpecialAbilitiesGeneratorReturnsEmptyIfBonusLessThanOne()
        {
            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 0, 1);
            Assert.That(abilities, Is.Empty);
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsShieldAbilitiesIfShield()
        {
            types.Add(ItemsConstants.Gear.Types.Shield);
            var shieldAbilityType = new TypeAndAmountPercentileResult();
            shieldAbilityType.Type = "shield ability";
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult("powerShieldSpecialAbilities")).Returns(shieldAbilityType);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(shieldAbilityType.Type));
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsMeleeWeaponAbilitiesIfMeleeWeapon()
        {
            types.Add(ItemsConstants.Gear.Types.Melee);
            var meleeWeaponAbilityType = new TypeAndAmountPercentileResult();
            meleeWeaponAbilityType.Type = "melee weapon ability";
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult("powerMeleeWeaponSpecialAbilities")).Returns(meleeWeaponAbilityType);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(meleeWeaponAbilityType.Type));
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsRangedWeaponAbilitiesIfRangedWeapon()
        {
            types.Add(ItemsConstants.Gear.Types.Ranged);
            var rangedWeaponAbilityType = new TypeAndAmountPercentileResult();
            rangedWeaponAbilityType.Type = "ranged weapon ability";
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult("powerRangedWeaponSpecialAbilities")).Returns(rangedWeaponAbilityType);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(rangedWeaponAbilityType.Type));
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsArmorAbilitiesIfArmor()
        {
            var armorAbilityType = new TypeAndAmountPercentileResult();
            armorAbilityType.Type = "armor ability";
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult("powerArmorSpecialAbilities")).Returns(armorAbilityType);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(armorAbilityType.Type));
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void SpecialAbilitiesGeneratorThrowsErrorIfNotValidTypes()
        {
            specialAbilitiesGenerator.GenerateFor(new[] { "invalid type" }, "power", 1, 1);
        }

        [Test]
        public void SpecialAbilitiesGeneratorGetsAbilitiesFromTypeAndAmountPercentileResultProvider()
        {
            var ability1 = new TypeAndAmountPercentileResult() { Type = "ability 1" };
            var ability2 = new TypeAndAmountPercentileResult() { Type = "ability 2" };
            var ability3 = new TypeAndAmountPercentileResult() { Type = "ability 3" };

            mockTypeAndAmountPercentileResultProvider.SetupSequence(p => p.GetTypeAndAmountPercentileResult("powerArmorSpecialAbilities"))
                .Returns(ability1).Returns(ability2).Returns(ability3);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item(ability1.Type));
            Assert.That(names, Contains.Item(ability2.Type));
            Assert.That(names, Contains.Item(ability3.Type));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void SpecialAbilitiesGeneratorWillNotAllowAbilitiesAndMagicBonusToBeGreaterThan10()
        {
            var bigAbility = new TypeAndAmountPercentileResult();
            bigAbility.Type = "big ability";
            bigAbility.Amount = 2;
            var smallAbility = new TypeAndAmountPercentileResult();
            smallAbility.Type = "small ability";
            smallAbility.Amount = 1;
            mockTypeAndAmountPercentileResultProvider.SetupSequence(p => p.GetTypeAndAmountPercentileResult("powerArmorSpecialAbilities"))
                .Returns(bigAbility).Returns(smallAbility);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 9, 1);
            Assert.That(abilities.First().Name, Is.EqualTo(smallAbility.Type));
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }

        [Test]
        public void SpecialAbilitiesGeneratorAccumulatesAbilities()
        {
            var ability1 = new TypeAndAmountPercentileResult() { Type = "ability 1", Amount = 1 };
            var ability2 = new TypeAndAmountPercentileResult() { Type = "ability 2", Amount = 2 };
            var ability3 = new TypeAndAmountPercentileResult() { Type = "ability 3", Amount = 3 };
            var ability4 = new TypeAndAmountPercentileResult() { Type = "ability 4", Amount = 0 };

            mockTypeAndAmountPercentileResultProvider.SetupSequence(p => p.GetTypeAndAmountPercentileResult("powerArmorSpecialAbilities"))
                .Returns(ability1).Returns(ability2).Returns(ability3).Returns(ability4);

            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 5, 3);
            var names = abilities.Select(a => a.Name);
            Assert.That(names, Contains.Item(ability1.Type));
            Assert.That(names, Contains.Item(ability2.Type));
            Assert.That(names, Contains.Item(ability4.Type));
            Assert.That(names.Count(), Is.EqualTo(3));
        }

        [Test]
        public void SpecialAbilitiesGeneratorUsesMostPowerfulVersionOfAbility()
        {
            Assert.Fail();
        }
    }
}