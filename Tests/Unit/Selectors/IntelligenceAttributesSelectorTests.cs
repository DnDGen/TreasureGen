using System;
using TreasureGen.Selectors;
using TreasureGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class IntelligenceAttributesSelectorTests
    {
        private IIntelligenceAttributesSelector selector;
        private Mock<IAttributesSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IAttributesSelector>();
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
            mockInnerSelector.Setup(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<String>())).Returns(attributes);
            Assert.That(() => selector.SelectFrom("table name", "name"), Throws.Exception.With.Message.EqualTo("Attributes are not formatted for intelligence"));
        }
    }
}