using D20Dice;
using EquipmentGen.Generators;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Objects;
using Moq;
using NUnit.Framework;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class AmmunitionGeneratorTests
    {
        private IAmmunitionGenerator ammunitionGenerator;
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private Mock<IDice> mockDice;
        private Mock<IAttributesProvider> mockAttributesProvider;

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

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetResultFrom("Ammunitions", 42)).Returns(result);

            mockAttributesProvider = new Mock<IAttributesProvider>();

            ammunitionGenerator = new AmmunitionGenerator(mockTypeAndAmountPercentileResultProvider.Object, mockDice.Object,
                mockAttributesProvider.Object);
        }

        [Test]
        public void AmmunitionGeneratorGetsNameAndQuantityFromTypeAndAmountPercentileResultProvider()
        {
            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Name, Is.EqualTo(result.Type));
            Assert.That(ammunition.Quantity, Is.EqualTo(9266));
        }

        [Test]
        public void AmmunitionGeneratorGetsAttributesFromProvider()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor(result.Type, "AmmunitionAttributes")).Returns(attributes);

            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Attributes, Is.EqualTo(attributes));
        }
    }
}