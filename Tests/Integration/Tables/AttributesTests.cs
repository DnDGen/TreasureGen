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

        protected void AssertEmpty(String name)
        {
            if (!table.ContainsKey(name))
                Assert.Pass();

            Assert.That(table[name], Is.Empty);
        }

        protected void AssertAttributes(String name, IEnumerable<String> attributes)
        {
            Assert.That(table.Keys, Contains.Item(name));

            foreach (var attribute in attributes)
                Assert.That(table[name], Contains.Item(attribute));

            var extraAttributes = table[name].Except(attributes);
            Assert.That(extraAttributes, Is.Empty);
        }
    }
}