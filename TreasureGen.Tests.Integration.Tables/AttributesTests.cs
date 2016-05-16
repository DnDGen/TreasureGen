using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Mappers.Attributes;

namespace TreasureGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class AttributesTests : TableTests
    {
        [Inject]
        internal IAttributesMapper AttributesMapper { get; set; }

        private Dictionary<string, IEnumerable<string>> table;

        [SetUp]
        public void Setup()
        {
            table = AttributesMapper.Map(tableName);
        }

        public virtual void Attributes(string name, params string[] attributes)
        {
            Assert.That(table.Keys, Contains.Item(name), tableName);

            foreach (var attribute in attributes)
            {
                Assert.That(table[name], Contains.Item(attribute));

                var actualAttributeCount = table[name].Count(a => a == attribute);
                var expectedAttributeCount = attributes.Count(a => a == attribute);
                Assert.That(actualAttributeCount, Is.EqualTo(expectedAttributeCount), attribute);
            }

            var extraAttributes = table[name].Except(attributes);
            Assert.That(extraAttributes, Is.Empty, "Extra attributes");
        }

        public virtual void OrderedAttributes(String name, params String[] attributes)
        {
            Assert.That(table.Keys, Contains.Item(name), tableName);
            var count = attributes.Count();

            for (var i = 0; i < count; i++)
            {
                var expected = attributes.ElementAt(i);
                var actual = table[name].ElementAt(i);
                Assert.That(actual, Is.EqualTo(expected));
            }

            Assert.That(table[name].Count(), Is.EqualTo(count));
        }
    }
}