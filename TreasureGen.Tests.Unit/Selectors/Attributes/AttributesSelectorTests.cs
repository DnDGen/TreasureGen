using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Mappers.Collections;
using TreasureGen.Domain.Selectors.Attributes;

namespace TreasureGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class AttributesSelectorTests
    {
        private ICollectionsSelector attributesSelector;
        private Mock<ICollectionsMapper> mockAttributesMapper;
        private IEnumerable<string> expected;

        [SetUp]
        public void Setup()
        {
            expected = new[] { "type 1", "type 2" };
            var table = new Dictionary<string, IEnumerable<string>>();
            table.Add("name", expected);
            table.Add("other name", Enumerable.Empty<string>());

            mockAttributesMapper = new Mock<ICollectionsMapper>();
            mockAttributesMapper.Setup(p => p.Map("table name")).Returns(table);
            mockAttributesMapper.Setup(p => p.Map("other table name")).Returns(new Dictionary<string, IEnumerable<string>>());

            attributesSelector = new CollectionsSelector(mockAttributesMapper.Object);
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