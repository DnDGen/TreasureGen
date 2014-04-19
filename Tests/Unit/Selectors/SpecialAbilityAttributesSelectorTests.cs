using System;
using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Selectors
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
            Assert.That(result.Strength, Is.EqualTo(9266));
        }

        [Test]
        public void ThrowErrorIfFewerThan3Attributes()
        {
            var attributes = new[] { "base name", "42" };
            mockInnerSelector.Setup(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<String>())).Returns(attributes);
            Assert.That(() => selector.SelectFrom("table name", "name"), Throws.Exception.With.Message.EqualTo("Attributes are not formatted for special abilities"));
        }
    }
}