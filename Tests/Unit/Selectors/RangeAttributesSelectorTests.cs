using System;
using System.Linq;
using TreasureGen.Selectors;
using TreasureGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class RangeAttributesSelectorTests
    {
        private IRangeAttributesSelector rangeAttributesSelector;
        private Mock<IAttributesSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IAttributesSelector>();
            rangeAttributesSelector = new RangeAttributesSelector(mockInnerSelector.Object);
        }

        [Test]
        public void GetRawAttributesFromAttributesSelector()
        {
            var attributes = new[] { "42", "9266" };
            mockInnerSelector.Setup(s => s.SelectFrom("table name", "name")).Returns(attributes);

            var result = rangeAttributesSelector.SelectFrom("table name", "name");
            Assert.That(result.Minimum, Is.EqualTo(42));
            Assert.That(result.Maximum, Is.EqualTo(9266));
        }

        [Test]
        public void ThrowErrorIfOnly1Attributes()
        {
            var attributes = new[] { "42" };
            mockInnerSelector.Setup(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<String>())).Returns(attributes);
            Assert.That(() => rangeAttributesSelector.SelectFrom(String.Empty, String.Empty), Throws.Exception.With.Message.EqualTo("Attributes are not in format for range"));
        }

        [Test]
        public void ThrowErrorIfNoAttributes()
        {
            mockInnerSelector.Setup(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<String>())).Returns(Enumerable.Empty<String>());
            Assert.That(() => rangeAttributesSelector.SelectFrom(String.Empty, String.Empty), Throws.Exception.With.Message.EqualTo("Attributes are not in format for range"));
        }
    }
}