using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
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
        private Mock<IAttributesProvider> mockAttributesProvider;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<ISpecialMaterialGenerator> mockMaterialsProvider;
        private Mock<IMagicalItemTraitsGenerator> mockMagicItemTraitsGenerator;
        private Mock<IIntelligenceGenerator> mockIntelligenceGenerator;

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
            mockAttributesProvider = new Mock<IAttributesProvider>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMaterialsProvider = new Mock<ISpecialMaterialGenerator>();
            mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();

            magicalArmorGenerator = new MagicalArmorGenerator(mockTypeAndAmountPercentileResultProvider.Object,
                mockPercentileResultProvider.Object, mockAttributesProvider.Object, mockSpecialAbilitiesGenerator.Object,
                mockMaterialsProvider.Object, mockMagicItemTraitsGenerator.Object, mockIntelligenceGenerator.Object);
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
            var bonus = Convert.ToInt32(armor.Magic[Magic.Bonus]);
            Assert.That(bonus, Is.EqualTo(9266));
        }

        [Test]
        public void MagicalArmorGeneratorGetsNameFromPercentileResultProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(result.Type + "Type")).Returns("armor name");

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("armor name"));
        }

        [Test]
        public void MagicalArmorGeneratorGetsAttributesFromProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(result.Type + "Type")).Returns("armor name");

            var attributes = new[] { "type 1", "type 2" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor("armor name", "ArmorTypes")).Returns(attributes);

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void MagicalArmorGeneratorGetsSpecificItemsFromGenerator()
        {
            Assert.Fail();
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
            var abilities = armor.Magic[Magic.Abilities] as IEnumerable<SpecialAbility>;
            Assert.That(abilities.Count(), Is.EqualTo(1));
            Assert.That(abilities, Contains.Item(ability));
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

        [Test]
        public void GetIntelligenceFromGenerator()
        {
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Armor)).Returns(intelligence);

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            var armorIntelligence = armor.Magic[Magic.Intelligence] as Intelligence;
            Assert.That(armorIntelligence, Is.EqualTo(intelligence));
        }

        [Test]
        public void CastersShieldHasSpell()
        {
            Assert.Fail();
        }

        [Test]
        public void CastersShieldDoesNotHavespell()
        {
            Assert.Fail();
        }
    }
}