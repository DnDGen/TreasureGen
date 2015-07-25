using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Items.Magical;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors;
using TreasureGen.Selectors.Results;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests
    {
        private IMagicalItemGenerator potionGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private TypeAndAmountPercentileResult result;
        private String power;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            result = new TypeAndAmountPercentileResult();

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<String>())).Returns(result);
            result.Amount = 0;
            power = "power";

            potionGenerator = new PotionGenerator(mockTypeAndAmountPercentileSelector.Object, mockPercentileSelector.Object);
        }

        [Test]
        public void GeneratePotion()
        {
            var potion = potionGenerator.GenerateAtPower(power);
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
            newResult.Amount = 9266;

            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(newResult);

            var potion = potionGenerator.GenerateAtPower(power);
            Assert.That(potion.Name, Is.EqualTo(newResult.Type));
            Assert.That(potion.Magic.Bonus, Is.EqualTo(newResult.Amount));

        }
    }
}