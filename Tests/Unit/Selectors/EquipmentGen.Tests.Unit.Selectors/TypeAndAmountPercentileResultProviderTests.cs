using System;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class TypeAndAmountPercentileResultProviderTests
    {
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("table name", 9266))
                .Returns("type,roll");

            typeAndAmountPercentileResultProvider = new TypeAndAmountPercentileResultProvider(mockPercentileResultProvider.Object);
        }

        [Test]
        public void AccessesPercentileResultProviderWithTableNameAndRoll()
        {
            typeAndAmountPercentileResultProvider.GetResultFrom("table name", 9266);
            mockPercentileResultProvider.Verify(p => p.GetResultFrom("table name", 9266), Times.Once);
        }

        [Test]
        public void TypeAndAmountPercentileResultIsEmptyIfPercentileResultIsEmpty()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>(), It.IsAny<Int32>()))
                .Returns(String.Empty);

            var result = typeAndAmountPercentileResultProvider.GetResultFrom("table name", 1);
            Assert.That(result.Type, Is.Empty);
            Assert.That(result.AmountToRoll, Is.Empty);
        }

        [Test]
        public void TypeAndAmountPercentileResultProviderReturnsCorrectObject()
        {
            var result = typeAndAmountPercentileResultProvider.GetResultFrom("table name", 9266);
            Assert.That(result.Type, Is.EqualTo("type"));
            Assert.That(result.AmountToRoll, Is.EqualTo("roll"));
        }

        [Test]
        public void TypeAndAmountPercentileResultProviderThrowsFormatExceptionIfNoComma()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>(), It.IsAny<Int32>())).Returns("no comma in this result");
            Assert.That(() => typeAndAmountPercentileResultProvider.GetResultFrom("table name", 1), Throws.InstanceOf<FormatException>());
        }
    }
}