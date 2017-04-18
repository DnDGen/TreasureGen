using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Selectors.Attributes;

namespace TreasureGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class IntelligenceCollectionsSelectorTests
    {
        private IIntelligenceAttributesSelector selector;
        private Mock<ICollectionsSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionsSelector>();
            selector = new IntelligenceAttributesSelector(mockInnerSelector.Object);
        }

        [Test]
        public void ReturnIntelligenceResult()
        {
            var attributes = new[] { "senses", "42", "9266" };
            mockInnerSelector.Setup(s => s.SelectFrom("table name", "name")).Returns(attributes);

            var result = selector.SelectFrom("table name", "name");
            Assert.That(result.Senses, Is.EqualTo("senses"));
            Assert.That(result.LesserPowersCount, Is.EqualTo(42));
            Assert.That(result.GreaterPowersCount, Is.EqualTo(9266));
        }

        [Test]
        public void ThrowErrorIfFewerThan3Attributes()
        {
            var attributes = new[] { "senses", "42" };
            mockInnerSelector.Setup(s => s.SelectFrom(It.IsAny<string>(), It.IsAny<string>())).Returns(attributes);
            Assert.That(() => selector.SelectFrom("table name", "name"), Throws.Exception.With.Message.EqualTo("Attributes are not formatted for intelligence"));
        }
    }
}