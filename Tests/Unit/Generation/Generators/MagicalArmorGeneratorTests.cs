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
    public class MagicalArmorGeneratorTests
    {
        private IMagicalGearGenerator magicalArmorGenerator;
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<ITypesProvider> mockTypesProvider;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<ISpecialMaterialGenerator> mockMaterialsProvider;
        private Mock<IMagicalItemTraitsGenerator> mockMagicItemTraitsGenerator;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "armor type";
            result.Amount = 9266;

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetResultFrom("powerArmor")).Returns(result);

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockTypesProvider = new Mock<ITypesProvider>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMaterialsProvider = new Mock<ISpecialMaterialGenerator>();
            mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();

            magicalArmorGenerator = new MagicalArmorGenerator(mockTypeAndAmountPercentileResultProvider.Object,
                mockPercentileResultProvider.Object, mockTypesProvider.Object, mockSpecialAbilitiesGenerator.Object,
                mockMaterialsProvider.Object, mockMagicItemTraitsGenerator.Object);
        }

        [Test]
        public void MagicalArmorGeneratorThrowsErrorIfMundane()
        {
            Assert.That(() => magicalArmorGenerator.GenerateAtPower(PowerConstants.Mundane), Throws.ArgumentException);
        }

        [Test]
        public void MagicalArmorGeneratorGetsBonusFromProvider()
        {
            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.MagicalBonus, Is.EqualTo(9266));
        }

        [Test]
        public void MagicalArmorGeneratorGetsNameFromPercentileResultProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(result.Type + "Type")).Returns("armor name");

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("armor name"));
        }

        [Test]
        public void MagicalArmorGeneratorGetsGearTypesFromProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(result.Type + "Type")).Returns("armor name");

            var types = new[] { "type 1", "type 2" };
            mockTypesProvider.Setup(p => p.GetTypesFor("armor name", "ArmorTypes")).Returns(types);

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Types, Is.EqualTo(types));
        }

        [Test]
        public void MagicalArmorGeneratorGetsSpecificItems()
        {
            result.Type = "Specific armor type";
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("power" + result.Type)).Returns("specific armor name");

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("specific armor name"));
        }

        [Test]
        public void MagicalArmorGeneratorGetsAbilities()
        {
            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;
            mockTypeAndAmountPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmor"))
                .Returns(abilityResult).Returns(result);

            var ability = new SpecialAbility();
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>(), "power", result.Amount, 1))
                .Returns(new[] { ability });

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Abilities.Count(), Is.EqualTo(1));
            Assert.That(armor.Abilities, Contains.Item(ability));
        }

        [Test]
        public void SpecificItemsDoNotHaveAbilitiesNorMagicBonusesNorTraits()
        {
            result.Type = "Specific armor type";
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("power" + result.Type)).Returns("specific armor name");

            var ability = new SpecialAbility();
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>(), "power", result.Amount, 1))
                .Returns(new[] { ability });

            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;
            mockTypeAndAmountPercentileResultProvider.SetupSequence(p => p.GetResultFrom("powerArmor"))
                .Returns(abilityResult).Returns(result);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(result.Type + "SpecialAbilities")).Returns("ability");

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            mockMagicItemTraitsGenerator.Setup(g => g.GenerateFor(It.IsAny<String>())).Returns(new[] { "trait" });

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("specific armor name"));
            Assert.That(armor.Abilities, Is.Empty);
            Assert.That(armor.MagicalBonus, Is.EqualTo(0));
            Assert.That(armor.Traits, Is.Empty);
        }

        [Test]
        public void MagicalArmorGeneratorDoesNotGetSpecialMaterialIfArmorDoesNotHaveSpecialMaterial()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(false);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void MagicalArmorGeneratorGetsSpecialMaterialFromMaterialProvider()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Traits, Contains.Item("special material"));
        }

        [Test]
        public void MagicalArmorGeneratorGetsTraits()
        {
            var traits = new[] { "trait 1", "trait 2" };
            mockMagicItemTraitsGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Armor)).Returns(traits);

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            foreach (var trait in traits)
                Assert.That(armor.Traits, Contains.Item(trait));
        }
    }
}