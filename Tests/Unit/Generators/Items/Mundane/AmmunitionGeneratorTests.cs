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
    public class AmmunitionGeneratorTests
    {
        private IMundaneItemGenerator ammunitionGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IDice> mockDice;
        private Mock<IAttributesSelector> mockAttributesSelector;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockDice = new Mock<IDice>();
            ammunitionGenerator = new AmmunitionGenerator(mockTypeAndAmountPercentileSelector.Object, mockDice.Object, mockAttributesSelector.Object);
            result = new TypeAndAmountPercentileResult();

            result.Type = "ammunition name";
            result.Amount = "9266";
            mockDice.Setup(d => d.Roll(result.Amount)).Returns(9266);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom("Ammunitions")).Returns(result);
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
            mockAttributesSelector.Setup(p => p.SelectFrom("AmmunitionAttributes", result.Type)).Returns(attributes);

            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Attributes, Is.EqualTo(attributes));
        }
    }
}