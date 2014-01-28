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
            result.RollToDetermineAmount = "9266";

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
            result.Type = "armor type";
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("armor typeType")).Returns("armor name");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("armor name"));
        }

        [Test]
        public void PowerArmorGeneratorGetsGearTypesFromProvider()
        {
            result.Type = "armor type";
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("armor typeType")).Returns("armor name");

            var types = new[] { "type 1", "type 2" };
            mockGearTypesProvider.Setup(p => p.GetGearTypesFor("armor name")).Returns(types);

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Types, Is.EqualTo(types));
        }

        [Test]
        public void PowerArmorGeneratorGetsSpecificItems()
        {
            result.Type = "armor type";
            result.RollToDetermineAmount = "Specific";

            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerSpecificarmor type")).Returns("specific armor name");

            var armor = powerArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("specific armor name"));
        }
    }
}