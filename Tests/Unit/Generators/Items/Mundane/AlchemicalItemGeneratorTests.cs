using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests
    {
        private IMundaneItemGenerator generator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IDice> mockDice;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "alchemical item";
            result.Amount = "9266";
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom("AlchemicalItems")).Returns(result);

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Roll(result.Amount)).Returns(9266);

            generator = new AlchemicalItemGenerator(mockTypeAndAmountPercentileSelector.Object, mockDice.Object);
        }

        [Test]
        public void GetItemAndQuantityFromSelector()
        {
            var item = generator.Generate();
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Quantity, Is.EqualTo(9266));
        }
    }
}