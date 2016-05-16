using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Selectors.Attributes;

namespace TreasureGen.Tests.Unit.Selectors.Attributes
{
    [TestFixture]
    public class SpecialAbilityAttributesSelectorTests
    {
        private ISpecialAbilityAttributesSelector selector;
        private Mock<IAttributesSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IAttributesSelector>();
            selector = new SpecialAbilityAttributesSelector(mockInnerSelector.Object);
        }

        [Test]
        public void ReturnSpecialAbilityAttributesResult()
        {
            var attributes = new[] { "42", "base name", "9266" };
            mockInnerSelector.Setup(s => s.SelectFrom("table name", "name")).Returns(attributes);

            var result = selector.SelectFrom("table name", "name");
            Assert.That(result.BaseName, Is.EqualTo("base name"));
            Assert.That(result.BonusEquivalent, Is.EqualTo(42));
            Assert.That(result.Power, Is.EqualTo(9266));
        }

        [Test]
        public void ThrowErrorIfFewerThan3Attributes()
        {
            var attributes = new[] { "base name", "42" };
            mockInnerSelector.Setup(s => s.SelectFrom(It.IsAny<string>(), It.IsAny<string>())).Returns(attributes);
            Assert.That(() => selector.SelectFrom("table name", "name"), Throws.Exception.With.Message.EqualTo("Attributes are not formatted for special abilities"));
        }
    }
}