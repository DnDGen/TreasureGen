using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Mappers.Collections;

namespace TreasureGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class CollectionsTests : TableTests
    {
        [Inject]
        internal ICollectionsMapper CollectionsMapper { get; set; }

        private Dictionary<string, IEnumerable<string>> table;

        [SetUp]
        public void Setup()
        {
            table = CollectionsMapper.Map(tableName);
        }

        public virtual void Collections(string name, params string[] items)
        {
            Assert.That(table.Keys, Contains.Item(name), tableName);

            var missingItems = items.Except(table[name]);
            Assert.That(missingItems, Is.Empty, $"{missingItems.Count()} missing items");

            foreach (var item in items)
            {
                var actualAttributeCount = table[name].Count(a => a == item);
                var expectedAttributeCount = items.Count(a => a == item);
                Assert.That(actualAttributeCount, Is.EqualTo(expectedAttributeCount), item);
            }

            var extraItems = table[name].Except(items);
            Assert.That(extraItems, Is.Empty, $"{extraItems.Count()} extra items in collection");
        }

        public virtual void OrderedCollections(string name, params string[] items)
        {
            Assert.That(table.Keys, Contains.Item(name), tableName);
            var count = items.Count();

            for (var i = 0; i < count; i++)
            {
                var expected = items.ElementAt(i);
                var actual = table[name].ElementAt(i);
                Assert.That(actual, Is.EqualTo(expected));
            }

            Assert.That(table[name].Count(), Is.EqualTo(count));
        }
    }
}