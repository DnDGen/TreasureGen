using Moq;
using NUnit.Framework;
using RollGen;
using System;
using TreasureGen.Selectors;
using TreasureGen.Selectors.Domain;

namespace TreasureGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class TypeAndAmountPercentileSelectorTests
    {
        private Mock<IPercentileSelector> mockPercentileSelector;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private Mock<IDice> mockDice;
        private Mock<IPartialRoll> mockPartialRoll;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<IDice>();
            typeAndAmountPercentileSelector = new TypeAndAmountPercentileSelector(mockPercentileSelector.Object, mockDice.Object);
            mockPartialRoll = new Mock<IPartialRoll>();

            mockDice.Setup(d => d.Roll(It.IsAny<Int32>())).Returns(mockPartialRoll.Object);
            mockPercentileSelector.Setup(p => p.SelectFrom("table name")).Returns("type,2d3*4");
        }

        [Test]
        public void AccessesPercentileSelectorWithTableNameAndRoll()
        {
            typeAndAmountPercentileSelector.SelectFrom("table name");
            mockPercentileSelector.Verify(p => p.SelectFrom("table name"), Times.Once);
        }

        [Test]
        public void ReturnEmptyIfPercentileIsEmpty()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns(String.Empty);

            var result = typeAndAmountPercentileSelector.SelectFrom("table name");
            Assert.That(result.Type, Is.Empty);
            Assert.That(result.Amount, Is.EqualTo(0));
        }

        [Test]
        public void ReturnType()
        {
            var result = typeAndAmountPercentileSelector.SelectFrom("table name");
            Assert.That(result.Type, Is.EqualTo("type"));
        }

        [Test]
        public void RollAmount()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("table name")).Returns("type,2");
            var result = typeAndAmountPercentileSelector.SelectFrom("table name");
            Assert.That(result.Amount, Is.EqualTo(2));
        }

        [Test]
        public void RollAmountWithQuantity()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("table name")).Returns("type,2d3");
            mockPartialRoll.Setup(r => r.d(3)).Returns(4);

            var result = typeAndAmountPercentileSelector.SelectFrom("table name");
            mockDice.Verify(d => d.Roll(2), Times.Once);
            Assert.That(result.Amount, Is.EqualTo(4));
        }

        [Test]
        public void RollAmountWithQuantityAndMultiplier()
        {
            mockPartialRoll.Setup(r => r.d(3)).Returns(4);

            var result = typeAndAmountPercentileSelector.SelectFrom("table name");
            mockDice.Verify(d => d.Roll(2), Times.Once);
            Assert.That(result.Amount, Is.EqualTo(16));
        }

        [Test]
        public void ThrowFormatExceptionIfNoComma()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns("no comma in this result");
            Assert.That(() => typeAndAmountPercentileSelector.SelectFrom("table name"), Throws.InstanceOf<FormatException>());
        }
    }
}