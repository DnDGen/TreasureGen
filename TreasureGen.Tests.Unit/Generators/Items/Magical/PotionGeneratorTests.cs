using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests
    {
        private MagicalItemGenerator potionGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private TypeAndAmountPercentileResult result;
        private string power;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            result = new TypeAndAmountPercentileResult();

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<string>())).Returns(result);
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

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(newResult);

            var potion = potionGenerator.GenerateAtPower(power);
            Assert.That(potion.Name, Is.EqualTo(newResult.Type));
            Assert.That(potion.Magic.Bonus, Is.EqualTo(newResult.Amount));

        }
    }
}