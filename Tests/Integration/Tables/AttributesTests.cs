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
        private List<String> testedNames;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            testedNames = new List<String>();
        }

        [SetUp]
        public void Setup()
        {
            table = AttributesMapper.Map(tableName);
        }

        [Test, TestFixtureTearDown]
        public void AllNamesTested()
        {
            var missingNames = table.Keys.Except(testedNames);
            Assert.That(missingNames, Is.Empty, tableName);
        }

        [Test, TestFixtureTearDown]
        public void NoNamesTestedNultipleTimes()
        {
            var duplicateNames = testedNames.Where(n => testedNames.Count(cn => cn == n) > 1).Distinct();
            Assert.That(duplicateNames, Is.Empty, tableName);
        }

        protected void AssertAttributes(String name, IEnumerable<String> attributes)
        {
            testedNames.Add(name);

            Assert.That(table.Keys, Contains.Item(name), tableName);

            foreach (var attribute in attributes)
            {
                Assert.That(table[name], Contains.Item(attribute));

                var actualAttributeCount = table[name].Count(a => a == attribute);
                var expectedAttributeCount = attributes.Count(a => a == attribute);
                Assert.That(actualAttributeCount, Is.EqualTo(expectedAttributeCount));
            }

            var extraAttributes = table[name].Except(attributes);
            Assert.That(extraAttributes, Is.Empty);
        }
    }
}