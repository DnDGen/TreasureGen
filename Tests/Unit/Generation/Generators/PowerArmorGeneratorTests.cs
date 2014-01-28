using System;
using D20Dice;
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
        private Mock<IDice> mockDice;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.RollToDetermineAmount = "9266";

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult(It.IsAny<String>())).Returns(result);

            mockDice = new Mock<IDice>();

            powerArmorGenerator = new PowerArmorGenerator();
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
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(9266);

            var armor = powerArmorGenerator.GenerateAtPower("power");
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetTypeAndAmountPercentileResult("powerArmor"), Times.Once);
            Assert.That(armor.MagicalBonus, Is.EqualTo(9266));
        }
    }
}