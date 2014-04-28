using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class AttributesTests : IntegrationTests
    {
        [Inject]
        public IAttributesMapper AttributesMapper { get; set; }

        protected abstract String tableName { get; }

        private Dictionary<String, IEnumerable<String>> table;

        [SetUp]
        public void Setup()
        {
            table = AttributesMapper.Map(tableName);
        }

        protected void AssertAttributes(String name, IEnumerable<String> attributes)
        {
            if (!attributes.Any())
            {
                Assert.That(table.Keys, Is.Not.Contains(name));
                return;
            }

            Assert.That(table.Keys, Contains.Item(name));

            foreach (var attribute in attributes)
                Assert.That(table[name], Contains.Item(attribute));

            var tooMany = table[name].Except(attributes);
            var tooManyString = String.Join(", ", tooMany);
            var message = String.Format("Should not be in results: {0}", tooManyString);
            Assert.That(table[name].Count(), Is.EqualTo(attributes.Count()), message);
        }
    }
}