using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Mappers.Collections;
using TreasureGen.Domain.Selectors.Attributes;

namespace TreasureGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class CollectionsSelectorTests
    {
        private ICollectionsSelector collectionsSelector;
        private Mock<ICollectionsMapper> mockCollectionsMapper;
        private IEnumerable<string> expected;

        [SetUp]
        public void Setup()
        {
            expected = new[] { "type 1", "type 2" };
            var table = new Dictionary<string, IEnumerable<string>>();
            table.Add("name", expected);
            table.Add("other name", Enumerable.Empty<string>());

            mockCollectionsMapper = new Mock<ICollectionsMapper>();
            mockCollectionsMapper.Setup(p => p.Map("table name")).Returns(table);
            mockCollectionsMapper.Setup(p => p.Map("other table name")).Returns(new Dictionary<string, IEnumerable<string>>());

            collectionsSelector = new CollectionsSelector(mockCollectionsMapper.Object);
        }

        [Test]
        public void GetAttributesFromMapper()
        {
            var attributes = collectionsSelector.SelectFrom("table name", "name");
            Assert.That(attributes, Is.EqualTo(expected));
        }

        [Test]
        public void GetEmptyAttributesFromMapper()
        {
            var attributes = collectionsSelector.SelectFrom("table name", "other name");
            Assert.That(attributes, Is.Empty);
        }

        [Test]
        public void ThrowErrorIfNameNotFound()
        {
            Assert.That(() => collectionsSelector.SelectFrom("table name", "unknown name"), Throws.ArgumentException.With.Message.EqualTo("unknown name is not in the table table name"));
            Assert.That(() => collectionsSelector.SelectFrom("other table name", "name"), Throws.ArgumentException.With.Message.EqualTo("name is not in the table other table name"));
        }

        [Test]
        public void ItemExists()
        {
            var exists = collectionsSelector.Exists("table name", "name");
            Assert.That(exists, Is.True);
        }

        [Test]
        public void ItemDoesNotExist()
        {
            var exists = collectionsSelector.Exists("table name", "unknown name");
            Assert.That(exists, Is.False);
        }
    }
}