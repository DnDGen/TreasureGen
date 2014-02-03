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

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "alchemical item";
            result.Amount = 9266;
            mockTypeAndAmountPercentileProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileProvider.Setup(p => p.GetResultFrom("AlchemicalItems")).Returns(result);

            generator = new AlchemicalItemGenerator(mockTypeAndAmountPercentileProvider.Object);
        }

        [Test]
        public void AlchemicalItemGeneratorGetsItemAndQuantityFromTypeAndAmountPercentileResultProvider()
        {
            var item = generator.Generate();
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Quantity, Is.EqualTo(9266));
        }
    }
}