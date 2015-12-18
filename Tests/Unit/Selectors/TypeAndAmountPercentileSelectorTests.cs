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
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<Dice>();
            typeAndAmountPercentileSelector = new TypeAndAmountPercentileSelector(mockPercentileSelector.Object, mockDice.Object);

            mockPercentileSelector.Setup(p => p.SelectFrom("table name")).Returns("type,amount");
            mockDice.Setup(d => d.Roll("amount")).Returns(9266);
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
            var result = typeAndAmountPercentileSelector.SelectFrom("table name");
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