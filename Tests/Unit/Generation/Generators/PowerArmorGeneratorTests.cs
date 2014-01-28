using System;
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

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "armor type";
            result.Amount = 9266;

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult(It.IsAny<String>())).Returns(result);

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockGearTypesProvider = new Mock<IGearTypesProvider>();

            powerArmorGenerator = new PowerArmorGenerator(mockTypeAndAmountPercentileResultProvider.Object,
                mockPercentileResultProvider.Object, mockGearTypesProvider.Object);
        }

        [Test]
        public void PowerArmorGeneratorGeneratesArmor()
        {
            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor, Is.Not.Null);
        }

        [Test]
        public void PowerArmorGeneratorGetsBonusFromProvider()
        {
            var armor = powerArmorGenerator.GenerateAtPower("power");
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetTypeAndAmountPercentileResult("powerArmor"), Times.Once);
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
            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            mockTypeAndAmountPercentileResultProvider.SetupSequence(p => p.GetTypeAndAmountPercentileResult("powerArmor"))
                .Returns(abilityResult).Returns(result);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(result.Type + "SpecialAbilities")).Returns("ability");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Abilities[0], Is.EqualTo("ability"));
            Assert.That(armor.Abilities.Count, Is.EqualTo(1));
        }

        [Test]
        public void PowerArmorGeneratorGetsNumberOfAbilitiesAsRolled()
        {
            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            mockTypeAndAmountPercentileResultProvider.SetupSequence(p => p.GetTypeAndAmountPercentileResult("powerArmor"))
                .Returns(abilityResult).Returns(abilityResult).Returns(result);
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(result.Type + "SpecialAbilities"))
                .Returns("ability 1").Returns("ability 2");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Abilities[0], Is.EqualTo("ability 1"));
            Assert.That(armor.Abilities[0], Is.EqualTo("ability 2"));
            Assert.That(armor.Abilities.Count, Is.EqualTo(2));
        }
    }
}