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
    public class PowerArmorGeneratorTests
    {
        private IPowerGearGenerator powerArmorGenerator;
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IGearTypesProvider> mockGearTypesProvider;
        private Mock<IGearSpecialAbilitiesGenerator> mockGearSpecialAbilitiesGenerator;
        private Mock<IMaterialsProvider> mockMaterialsProvider;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "armor type";
            result.Amount = 9266;

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult("powerArmor")).Returns(result);

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockGearTypesProvider = new Mock<IGearTypesProvider>();
            mockGearSpecialAbilitiesGenerator = new Mock<IGearSpecialAbilitiesGenerator>();
            mockMaterialsProvider = new Mock<IMaterialsProvider>();

            powerArmorGenerator = new PowerArmorGenerator(mockTypeAndAmountPercentileResultProvider.Object,
                mockPercentileResultProvider.Object, mockGearTypesProvider.Object, mockGearSpecialAbilitiesGenerator.Object,
                mockMaterialsProvider.Object);
        }

        [Test]
        public void PowerArmorGeneratorGetsBonusFromProvider()
        {
            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.MagicalBonus, Is.EqualTo(9266));
        }

        [Test]
        public void PowerArmorGeneratorGetsNameFromPercentileResultProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(result.Type + "Type")).Returns("armor name");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("armor name"));
        }

        [Test]
        public void PowerArmorGeneratorGetsGearTypesFromProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(result.Type + "Type")).Returns("armor name");

            var types = new[] { "type 1", "type 2" };
            mockGearTypesProvider.Setup(p => p.GetGearTypesFor("armor name")).Returns(types);

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Types, Is.EqualTo(types));
        }

        [Test]
        public void PowerArmorGeneratorGetsSpecificItems()
        {
            result.Type = "Specific armor type";
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerSpecific" + result.Type)).Returns("specific armor name");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("specific armor name"));
        }

        [Test]
        public void PowerArmorGeneratorGetsAbilities()
        {
            var ability = new GearSpecialAbility();
            mockGearSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>(), "power", result.Amount, 1))
                .Returns(new[] { ability });

            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;
            mockTypeAndAmountPercentileResultProvider.SetupSequence(p => p.GetTypeAndAmountPercentileResult("powerArmor"))
                .Returns(abilityResult).Returns(result);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(result.Type + "SpecialAbilities")).Returns("ability");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Abilities.Count(), Is.EqualTo(1));
            Assert.That(armor.Abilities, Contains.Item(ability));
        }

        [Test]
        public void SpecificItemsDoNotHaveAbilitiesOrMagicBonusesOrSpecialMaterials()
        {
            result.Type = "Specific armor type";
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerSpecific" + result.Type)).Returns("specific armor name");

            var ability = new GearSpecialAbility();
            mockGearSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>(), "power", result.Amount, 1))
                .Returns(new[] { ability });

            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;
            mockTypeAndAmountPercentileResultProvider.SetupSequence(p => p.GetTypeAndAmountPercentileResult("powerArmor"))
                .Returns(abilityResult).Returns(result);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(result.Type + "SpecialAbilities")).Returns("ability");

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial()).Returns(true);
            mockMaterialsProvider.Setup(p => p.GetSpecialMaterialFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("specific armor name"));
            Assert.That(armor.Abilities, Is.Empty);
            Assert.That(armor.MagicalBonus, Is.EqualTo(0));
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void PowerArmorGeneratorDoesNotGetSpecialMaterialIfArmorDoesNotHaveSpecialMaterial()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial()).Returns(false);
            mockMaterialsProvider.Setup(p => p.GetSpecialMaterialFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void PowerArmorGeneratorGetsSpecialMaterialFromMaterialProvider()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial()).Returns(true);
            mockMaterialsProvider.Setup(p => p.GetSpecialMaterialFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Traits, Contains.Item("special material"));
        }

        [Test]
        public void NoEmptyStringAddedToTraitsForSpecialMaterials()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial()).Returns(true);
            mockMaterialsProvider.Setup(p => p.GetSpecialMaterialFor(It.IsAny<IEnumerable<String>>())).Returns(String.Empty);

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Traits, Is.Not.Contains(String.Empty));
        }

        [Test]
        public void PowerArmorGeneratorGetsTraits()
        {
            Assert.Fail();
        }

        [Test]
        public void PowerArmorGeneratorGetsCurses()
        {
            Assert.Fail();
        }
    }
}