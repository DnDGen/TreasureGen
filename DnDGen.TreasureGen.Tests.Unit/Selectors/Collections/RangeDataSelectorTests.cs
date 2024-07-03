using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class RangeDataSelectorTests
    {
        private IRangeDataSelector rangeDataSelector;
        private Mock<ICollectionSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionSelector>();
            rangeDataSelector = new RangeDataSelector(mockInnerSelector.Object);
        }

        [Test]
        public void GetRawAttributesFromAttributesSelector()
        {
            var attributes = new[] { "42", "9266" };
            mockInnerSelector.Setup(s => s.SelectFrom(Config.Name, "table name", "name")).Returns(attributes);

            var result = rangeDataSelector.SelectFrom("table name", "name");
            Assert.That(result.Minimum, Is.EqualTo(42));
            Assert.That(result.Maximum, Is.EqualTo(9266));
        }

        [Test]
        public void ThrowErrorIfOnly1Attributes()
        {
            var attributes = new[] { "42" };
            mockInnerSelector.Setup(s => s.SelectFrom(Config.Name, It.IsAny<string>(), It.IsAny<string>())).Returns(attributes);
            Assert.That(() => rangeDataSelector.SelectFrom(string.Empty, string.Empty), Throws.Exception.With.Message.EqualTo("Data is not in format for range"));
        }

        [Test]
        public void ThrowErrorIfNoAttributes()
        {
            mockInnerSelector.Setup(s => s.SelectFrom(Config.Name, It.IsAny<string>(), It.IsAny<string>())).Returns(Enumerable.Empty<string>());
            Assert.That(() => rangeDataSelector.SelectFrom(string.Empty, string.Empty), Throws.Exception.With.Message.EqualTo("Data is not in format for range"));
        }
    }
}