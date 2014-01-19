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
    public class AlchemicalItemGeneratorTests
    {
        private IAlchemicalItemGenerator generator;
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileProvider;
        private Mock<IDice> mockDice;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "alchemical item";
            result.RollToDetermineAmount = "roll";
            mockTypeAndAmountPercentileProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileProvider.Setup(p => p.GetTypeAndAmountPercentileResult("AlchemicalItems")).Returns(result);
            mockDice = new Mock<IDice>();

            generator = new AlchemicalItemGenerator(mockTypeAndAmountPercentileProvider.Object, mockDice.Object);
        }

        [Test]
        public void AlchemicalItemGeneratorReturnsAlchemicalItem()
        {
            var item = generator.Generate();
            Assert.That(item, Is.Not.Null);
        }

        [Test]
        public void AlchemicalItemGeneratorGetsItemFromTypeAndAmountPercentileResultProvider()
        {
            var item = generator.Generate();
            Assert.That(item.Name, Is.EqualTo(result.Type));
        }

        [Test]
        public void AlchemicalItemGeneratorGetsAmountFromTypeAndAmountPercentileResultProvider()
        {
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(9266);
            var item = generator.Generate();
            Assert.That(item.Quantity, Is.EqualTo(9266));
        }
    }
}