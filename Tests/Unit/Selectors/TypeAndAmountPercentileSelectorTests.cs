using System;
using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class TypeAndAmountPercentileSelectorTests
    {
        private Mock<IPercentileSelector> mockPercentileSelector;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockPercentileSelector.Setup(p => p.SelectFrom("table name", 9266))
                .Returns("type,roll");

            typeAndAmountPercentileSelector = new TypeAndAmountPercentileSelector(mockPercentileSelector.Object);
        }

        [Test]
        public void AccessesPercentileSelectorWithTableNameAndRoll()
        {
            typeAndAmountPercentileSelector.SelectFrom("table name", 9266);
            mockPercentileSelector.Verify(p => p.SelectFrom("table name", 9266), Times.Once);
        }

        [Test]
        public void ReturnEmptyIfPercentileIsEmpty()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>()))
                .Returns(String.Empty);

            var result = typeAndAmountPercentileSelector.SelectFrom("table name", 1);
            Assert.That(result.Type, Is.Empty);
            Assert.That(result.Amount, Is.Empty);
        }

        [Test]
        public void ReturnCorrectObject()
        {
            var result = typeAndAmountPercentileSelector.SelectFrom("table name", 9266);
            Assert.That(result.Type, Is.EqualTo("type"));
            Assert.That(result.Amount, Is.EqualTo("roll"));
        }

        [Test]
        public void ThrowFormatExceptionIfNoComma()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>())).Returns("no comma in this result");
            Assert.That(() => typeAndAmountPercentileSelector.SelectFrom("table name", 1), Throws.InstanceOf<FormatException>());
        }
    }
}