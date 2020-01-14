using DnDGen.RollGen;
using DnDGen.TreasureGen.Selectors.Percentiles;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class TypeAndAmountPercentileSelectorTests
    {
        private Mock<ITreasurePercentileSelector> mockPercentileSelector;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<ITreasurePercentileSelector>();
            mockDice = new Mock<Dice>();
            typeAndAmountPercentileSelector = new TypeAndAmountPercentileSelector(mockPercentileSelector.Object, mockDice.Object);

            mockPercentileSelector.Setup(p => p.SelectFrom("table name")).Returns("type,amount");
            SetUpRoll("amount", 9266);
        }

        private void SetUpRoll(string roll, int amount)
        {
            var partial = new Mock<PartialRoll>();
            partial.Setup(p => p.AsSum()).Returns(amount);
            mockDice.Setup(d => d.Roll(roll)).Returns(partial.Object);
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
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns(string.Empty);

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
            mockPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns("no comma in this result");
            Assert.That(() => typeAndAmountPercentileSelector.SelectFrom("table name"), Throws.InstanceOf<FormatException>().With.Message.EqualTo("no comma in this result is not formatted for type and amount parsing"));
        }

        [Test]
        public void SelectAllResults()
        {
            mockPercentileSelector.Setup(p => p.SelectAllFrom("table name")).Returns(new[] { "type,amount", "other type,other amount" });
            SetUpRoll("other amount", 90210);

            var results = typeAndAmountPercentileSelector.SelectAllFrom("table name");
            Assert.That(results.Count(), Is.EqualTo(2));

            var first = results.First();
            var last = results.Last();
            Assert.That(first.Type, Is.EqualTo("type"));
            Assert.That(first.Amount, Is.EqualTo(9266));
            Assert.That(last.Type, Is.EqualTo("other type"));
            Assert.That(last.Amount, Is.EqualTo(90210));
        }
    }
}