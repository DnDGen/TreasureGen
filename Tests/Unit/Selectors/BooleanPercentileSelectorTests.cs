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
            mockInnerSelector.Setup(s => s.SelectFrom("table name")).Returns(Boolean.TrueString);
            var isTrue = selector.SelectFrom("table name");
            Assert.That(isTrue, Is.True);
        }

        [Test]
        public void ReturnFalse()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table name")).Returns(Boolean.FalseString);
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