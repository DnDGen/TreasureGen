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

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<IDice>();
            typeAndAmountPercentileSelector = new TypeAndAmountPercentileSelector(mockPercentileSelector.Object, mockDice.Object);

            mockDice.Setup(d => d.Roll(It.IsAny<Int32>()).d(It.IsAny<Int32>())).Returns(1);
            mockPercentileSelector.Setup(p => p.SelectFrom("table name")).Returns("type,2d3");
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
            mockDice.Setup(d => d.Roll(2).d(1)).Returns(9266);
            mockPercentileSelector.Setup(p => p.SelectFrom("table name")).Returns("type,2");

            var result = typeAndAmountPercentileSelector.SelectFrom("table name");
            Assert.That(result.Amount, Is.EqualTo(9266));
        }

        [Test]
        public void RollAmountWithQuantity()
        {
            mockDice.Setup(d => d.Roll(2).d(3)).Returns(9266);

            var result = typeAndAmountPercentileSelector.SelectFrom("table name");
            mockDice.Verify(d => d.Roll(2), Times.Once);
            Assert.That(result.Amount, Is.EqualTo(9266));
        }

        [Test]
        public void ThrowFormatExceptionIfNoComma()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns("no comma in this result");
            Assert.That(() => typeAndAmountPercentileSelector.SelectFrom("table name"), Throws.InstanceOf<FormatException>());
        }
    }
}