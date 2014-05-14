using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests
    {
        private IMagicalItemGenerator potionGenerator;
        private Mock<IDice> mockDice;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            result = new TypeAndAmountPercentileResult();

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<String>())).Returns(result);
            result.Amount = "0";

            potionGenerator = new PotionGenerator(mockDice.Object, mockTypeAndAmountPercentileSelector.Object, mockPercentileSelector.Object);
        }

        [Test]
        public void ReturnPotion()
        {
            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion, Is.Not.Null);
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
        }

        [Test]
        public void GetPotionFromSelector()
        {
            var newResult = new TypeAndAmountPercentileResult();
            newResult.Type = "potion";
            newResult.Amount = "9266";

            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom("powerPotions")).Returns(newResult);

            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion.Name, Is.EqualTo(newResult.Type));
            Assert.That(potion.Magic.Bonus, Is.EqualTo(Convert.ToInt32(newResult.Amount)));

        }

        [Test]
        public void AlignmentIsGenerated()
        {
            result.Type = "potion of ALIGNMENT";
            mockPercentileSelector.Setup(s => s.SelectFrom("ProtectionAlignments")).Returns("an alignment");

            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion.Name, Is.EqualTo("potion of an alignment"));
        }

        [Test]
        public void EnergyIsGenerated()
        {
            result.Type = "potion of ENERGY";
            mockPercentileSelector.Setup(s => s.SelectFrom("Elements")).Returns("an element");

            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion.Name, Is.EqualTo("potion of an element"));
        }
    }
}