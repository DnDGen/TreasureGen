using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Selectors.Percentiles;

namespace TreasureGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class BooleanPercentileSelectorTests
    {
        private IBooleanPercentileSelector selector;
        private Mock<IPercentileSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IPercentileSelector>();
            selector = new BooleanPercentileSelector(mockInnerSelector.Object);
        }

        [Test]
        public void ReturnTrue()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table name")).Returns(bool.TrueString);
            var isTrue = selector.SelectFrom("table name");
            Assert.That(isTrue, Is.True);
        }

        [Test]
        public void ReturnFalse()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table name")).Returns(bool.FalseString);
            var isTrue = selector.SelectFrom("table name");
            Assert.That(isTrue, Is.False);
        }

        [Test]
        public void ThrowError()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table name")).Returns("wrong format");
            Assert.That(() => selector.SelectFrom("table name"), Throws.InstanceOf<FormatException>());
        }
    }
}