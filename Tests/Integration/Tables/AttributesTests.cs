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
        private HashSet<String> testedNames;

        public AttributesTests()
        {
            testedNames = new HashSet<String>();
            table = AttributesMapper.Map(tableName);
        }

        [Test, TestFixtureTearDown]
        public void AllNamesTested()
        {
            var missingNames = table.Keys.Except(testedNames);
            Assert.That(missingNames, Is.Empty, tableName);
        }

        protected void AssertAttributes(String name, IEnumerable<String> attributes)
        {
            var notTestedBefore = testedNames.Add(name);
            Assert.That(notTestedBefore, Is.True);

            Assert.That(table.Keys, Contains.Item(name), tableName);

            foreach (var attribute in attributes)
            {
                Assert.That(table[name], Contains.Item(attribute));

                var actualAttributeCount = table[name].Count(a => a == attribute);
                var expectedAttributeCount = attributes.Count(a => a == attribute);
                Assert.That(actualAttributeCount, Is.EqualTo(expectedAttributeCount), attribute);
            }

            var extraAttributes = table[name].Except(attributes);
            Assert.That(extraAttributes, Is.Empty);
        }
    }
}