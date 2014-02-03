using System;
using D20Dice;
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
        private Mock<IDice> mockDice;
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>()))
                .Returns("type,roll");

            mockDice = new Mock<IDice>();

            typeAndAmountPercentileResultProvider = new TypeAndAmountPercentileResultProvider(mockPercentileResultProvider.Object,
                mockDice.Object);
        }

        [Test]
        public void AccessesPercentileResultProviderWithTableName()
        {
            typeAndAmountPercentileResultProvider.GetResultFrom("table name");
            mockPercentileResultProvider.Verify(p => p.GetResultFrom("table name"), Times.Once);
        }

        [Test]
        public void TypeAndAmountPercentileResultIsEmptyIfPercentileResultIsEmpty()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>()))
                .Returns(String.Empty);

            var result = typeAndAmountPercentileResultProvider.GetResultFrom("table name");
            Assert.That(result.Type, Is.Empty);
            Assert.That(result.Amount, Is.EqualTo(0));
        }

        [Test]
        public void TypeAndAmountPercentileResultProviderReturnsType()
        {
            var result = typeAndAmountPercentileResultProvider.GetResultFrom("table name");
            Assert.That(result.Type, Is.EqualTo("type"));
        }

        [Test]
        public void TypeAndAmountPercentileResultProviderReturnsAmount()
        {
            mockDice.Setup(d => d.Roll("roll")).Returns(9266);

            var result = typeAndAmountPercentileResultProvider.GetResultFrom("table name");
            Assert.That(result.Amount, Is.EqualTo(9266));
        }

        [Test]
        public void TypeAndAmountPercentileResultProviderThrowsFormatExceptionIfNoComma()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>())).Returns("no comma in this result");
            Assert.That(() => typeAndAmountPercentileResultProvider.GetResultFrom("table name"), Throws.InstanceOf<FormatException>());
        }
    }
}