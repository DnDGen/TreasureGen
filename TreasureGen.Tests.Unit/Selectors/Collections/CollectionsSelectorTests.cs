using Moq;
using NUnit.Framework;
using RollGen;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Mappers.Collections;
using TreasureGen.Domain.Selectors.Collections;

namespace TreasureGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class CollectionsSelectorTests
    {
        private ICollectionsSelector collectionsSelector;
        private Mock<ICollectionsMapper> mockCollectionsMapper;
        private IEnumerable<string> expected;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockCollectionsMapper = new Mock<ICollectionsMapper>();
            mockDice = new Mock<Dice>();
            collectionsSelector = new CollectionsSelector(mockCollectionsMapper.Object, mockDice.Object);

            expected = new[] { "type 1", "type 2" };
            var table = new Dictionary<string, IEnumerable<string>>();
            table.Add("name", expected);
            table.Add("other name", Enumerable.Empty<string>());

            mockCollectionsMapper.Setup(p => p.Map("table name")).Returns(table);
            mockCollectionsMapper.Setup(p => p.Map("other table name")).Returns(new Dictionary<string, IEnumerable<string>>());
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

        [Test]
        public void SelectRandomFromCollection()
        {
            var mockPartialSum = new Mock<PartialRoll>();
            mockPartialSum.Setup(r => r.AsSum()).Returns(4);

            var mockPartialRoll = new Mock<PartialRoll>();
            mockPartialRoll.Setup(r => r.d(7)).Returns(mockPartialSum.Object);

            mockDice.Setup(d => d.Roll(1)).Returns(mockPartialRoll.Object);

            var collection = new[]
            {
                "item 1",
                "item 2",
                "item 3",
                "item 4",
                "item 5",
                "item 6",
                "item 7",
            };

            var item = collectionsSelector.SelectRandomFrom(collection);
            Assert.That(item, Is.EqualTo("item 4"));
        }

        [Test]
        public void SelectRandomFromEmptyCollection()
        {
            Assert.That(() => collectionsSelector.SelectRandomFrom(Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot select random from an empty collection"));
        }
    }
}