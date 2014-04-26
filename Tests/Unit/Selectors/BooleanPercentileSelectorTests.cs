using System;
using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Selectors
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
            mockInnerSelector.Setup(s => s.SelectFrom("table name", 9266)).Returns(Boolean.TrueString);
            var isTrue = selector.SelectFrom("table name", 9266);
            Assert.That(isTrue, Is.True);
        }

        [Test]
        public void ReturnFalse()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table name", 9266)).Returns(Boolean.FalseString);
            var isTrue = selector.SelectFrom("table name", 9266);
            Assert.That(isTrue, Is.False);
        }

        [Test]
        public void ThrowError()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table name", 9266)).Returns("wrong format");
            Assert.That(() => selector.SelectFrom("table name", 9266), Throws.InstanceOf<FormatException>());
        }
    }
}