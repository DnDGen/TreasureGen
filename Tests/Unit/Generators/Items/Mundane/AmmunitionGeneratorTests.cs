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
    public class AmmunitionGeneratorTests
    {
        private IAmmunitionGenerator ammunitionGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IDice> mockDice;
        private Mock<IAttributesSelector> mockAttributesSelector;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "ammunition name";
            result.AmountToRoll = "9266";

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(42);
            mockDice.Setup(d => d.Roll(result.AmountToRoll)).Returns(9266);

            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom("Ammunitions", 42)).Returns(result);

            mockAttributesSelector = new Mock<IAttributesSelector>();

            ammunitionGenerator = new AmmunitionGenerator(mockTypeAndAmountPercentileSelector.Object, mockDice.Object,
                mockAttributesSelector.Object);
        }

        [Test]
        public void AmmunitionGeneratorGetsNameAndQuantityFromSelector()
        {
            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Name, Is.EqualTo(result.Type));
            Assert.That(ammunition.Quantity, Is.EqualTo(9266));
        }

        [Test]
        public void AmmunitionGeneratorGetsAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom(result.Type, "AmmunitionAttributes")).Returns(attributes);

            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Attributes, Is.EqualTo(attributes));
        }
    }
}