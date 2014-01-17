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
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("type,roll");

            typeAndAmountPercentileResultProvider = new TypeAndAmountPercentileResultProvider(mockPercentileResultProvider.Object);
        }

        [Test]
        public void AccessesPercentileResultProviderWithTableName()
        {
            typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult("table name");
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("table name"), Times.Once);
        }

        [Test]
        public void TypeAndAmountPercentileResultIsEmptyIfPercentileResultIsEmpty()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(String.Empty);

            var result = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult("table name");
            Assert.That(result.Type, Is.EqualTo(String.Empty));
            Assert.That(result.RollToDetermineAmount, Is.EqualTo(String.Empty));
        }

        [Test]
        public void TypeAndAmountPercentileResultReturnedComplete()
        {
            var result = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult("table name");
            Assert.That(result.Type, Is.EqualTo("type"));
            Assert.That(result.RollToDetermineAmount, Is.EqualTo("roll"));
        }
    }
}