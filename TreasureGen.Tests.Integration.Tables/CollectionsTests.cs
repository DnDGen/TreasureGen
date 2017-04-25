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

        protected IEnumerable<string> GetKeys()
        {
            return table.Keys;
        }

        public virtual void Collections(string name, params string[] items)
        {
            Assert.That(table.Keys, Contains.Item(name), tableName);
            AssertCollection(table[name], items);
        }

        protected void AssertCollection(IEnumerable<string> actual, IEnumerable<string> expected)
        {
            if (actual.Count() <= 10 && expected.Count() <= 10)
            {
                Assert.That(actual, Is.EquivalentTo(expected));
                return;
            }

            var missingItems = expected.Except(actual);
            Assert.That(missingItems, Is.Empty, $"{missingItems.Count()} missing items");

            foreach (var item in expected)
            {
                var actualAttributeCount = actual.Count(a => a == item);
                var expectedAttributeCount = expected.Count(a => a == item);
                Assert.That(actualAttributeCount, Is.EqualTo(expectedAttributeCount), item);
            }

            var extraItems = actual.Except(expected);
            Assert.That(extraItems, Is.Empty, $"{extraItems.Count()} extra items in collection");
        }

        public virtual void OrderedCollections(string name, params string[] items)
        {
            Assert.That(table.Keys, Contains.Item(name), tableName);
            AssertOrderedCollection(table[name], items);
        }

        protected void AssertOrderedCollection(IEnumerable<string> actual, IEnumerable<string> expected)
        {
            AssertCollection(actual, expected);

            if (actual.Count() <= 10 && expected.Count() <= 10)
            {
                Assert.That(actual, Is.EqualTo(expected));
                return;
            }

            var expectedArray = expected.ToArray();
            var actualArray = actual.ToArray();

            for (var i = 0; i < expectedArray.Length; i++)
            {
                Assert.That(actualArray[i], Is.EqualTo(expectedArray[i]), $"Index {i}");
            }
        }
    }
}