using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Tests.Integration.Common;
using EquipmentGen.Tests.Integration.Data.Attributes;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data
{
    [TestFixture]
    public abstract class AttributesTests : IntegrationTests
    {
        [Inject]
        public IAttributesXmlParser AttributesXmlParser { get; set; }

        private Dictionary<String, IEnumerable<String>> table;

        [SetUp]
        public void Setup()
        {
            var file = GetTableNameFromAttribute();
            table = AttributesXmlParser.Parse(file);
        }

        private String GetTableNameFromAttribute()
        {
            var type = GetType();
            var attributes = type.GetCustomAttributes(true);

            if (!attributes.Any(a => a is AttributesTableAttribute))
                throw new ArgumentException("This test class does not have the needed AttributesTableAttribute");

            var attributesFilenameAttribute = attributes.First(a => a is AttributesTableAttribute) as AttributesTableAttribute;
            return String.Format("{0}.xml", attributesFilenameAttribute.TableName);
        }

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