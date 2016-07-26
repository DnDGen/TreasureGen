using Moq;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;

namespace TreasureGen.Tests.Unit.Selectors.Attributes
{
    [TestFixture]
    public class RangeAttributesSelectorTests
    {
        private IRangeAttributesSelector rangeAttributesSelector;
        private Mock<ICollectionsSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionsSelector>();
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
            mockInnerSelector.Setup(s => s.SelectFrom(It.IsAny<string>(), It.IsAny<string>())).Returns(attributes);
            Assert.That(() => rangeAttributesSelector.SelectFrom(string.Empty, string.Empty), Throws.Exception.With.Message.EqualTo("Attributes are not in format for range"));
        }

        [Test]
        public void ThrowErrorIfNoAttributes()
        {
            mockInnerSelector.Setup(s => s.SelectFrom(It.IsAny<string>(), It.IsAny<string>())).Returns(Enumerable.Empty<string>());
            Assert.That(() => rangeAttributesSelector.SelectFrom(string.Empty, string.Empty), Throws.Exception.With.Message.EqualTo("Attributes are not in format for range"));
        }
    }
}