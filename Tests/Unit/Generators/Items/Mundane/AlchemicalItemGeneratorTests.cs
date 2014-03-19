using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests
    {
        private IAlchemicalItemGenerator generator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileProvider;
        private Mock<IDice> mockDice;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "alchemical item";
            result.AmountToRoll = "9266";
            mockTypeAndAmountPercentileProvider = new Mock<ITypeAndAmountPercentileSelector>();
            mockTypeAndAmountPercentileProvider.Setup(p => p.SelectFrom("AlchemicalItems", 42)).Returns(result);

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(42);
            mockDice.Setup(d => d.Roll(result.AmountToRoll)).Returns(9266);

            generator = new AlchemicalItemGenerator(mockTypeAndAmountPercentileProvider.Object, mockDice.Object);
        }

        [Test]
        public void GetItemAndQuantityFromTypeAndAmountPercentileResultProvider()
        {
            var item = generator.Generate();
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Quantity, Is.EqualTo(9266));
        }
    }
}