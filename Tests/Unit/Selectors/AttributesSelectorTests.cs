using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Mappers;
using TreasureGen.Selectors;
using TreasureGen.Selectors.Domain;

namespace TreasureGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class AttributesSelectorTests
    {
        private IAttributesSelector attributesSelector;
        private Mock<IAttributesMapper> mockAttributesMapper;
        private IEnumerable<String> expected;

        [SetUp]
        public void Setup()
        {
            expected = new[] { "type 1", "type 2" };
            var table = new Dictionary<String, IEnumerable<String>>();
            table.Add("name", expected);
            table.Add("other name", Enumerable.Empty<String>());

            mockAttributesMapper = new Mock<IAttributesMapper>();
            mockAttributesMapper.Setup(p => p.Map("table name")).Returns(table);
            mockAttributesMapper.Setup(p => p.Map("other table name")).Returns(new Dictionary<String, IEnumerable<String>>());

            attributesSelector = new AttributesSelector(mockAttributesMapper.Object);
        }

        [Test]
        public void GetAttributesFromMapper()
        {
            var attributes = attributesSelector.SelectFrom("table name", "name");
            Assert.That(attributes, Is.EqualTo(expected));
        }

        [Test]
        public void GetEmptyAttributesFromMapper()
        {
            var attributes = attributesSelector.SelectFrom("table name", "other name");
            Assert.That(attributes, Is.Empty);
        }

        [Test]
        public void ThrowErrorIfNameNotFound()
        {
            Assert.That(() => attributesSelector.SelectFrom("table name", "unknown name"), Throws.ArgumentException.With.Message.EqualTo("unknown name is not in the table table name"));
            Assert.That(() => attributesSelector.SelectFrom("other table name", "name"), Throws.ArgumentException.With.Message.EqualTo("name is not in the table other table name"));
        }
    }
}