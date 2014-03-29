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

        private String tableName;
        private Dictionary<String, IEnumerable<String>> table;

        [SetUp]
        public void Setup()
        {
            tableName = GetTableName();
            table = AttributesMapper.Map(tableName);
        }

        protected abstract String GetTableName();

        protected void AssertContent(String name, IEnumerable<String> expectedAttributes)
        {
            if (!expectedAttributes.Any())
            {
                Assert.That(table.Keys, Is.Not.Contains(name));
                return;
            }

            Assert.That(table.Keys, Contains.Item(name));

            foreach (var expectedAttribute in expectedAttributes)
                Assert.That(table[name], Contains.Item(expectedAttribute));

            var tooMany = table[name].Except(expectedAttributes);
            var tooManyString = String.Join(", ", tooMany);
            var message = String.Format("Should not be in results: {0}", tooManyString);
            Assert.That(table[name].Count(), Is.EqualTo(expectedAttributes.Count()), message);
        }
    }
}