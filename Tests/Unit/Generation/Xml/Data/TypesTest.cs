using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data
{
    [TestFixture]
    public abstract class TypesTest
    {
        private ITypesXmlParser typesXmlParser;
        private Dictionary<String, IEnumerable<String>> table;
        private String filename;

        [SetUp]
        public void Setup()
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            typesXmlParser = new TypesXmlParser(streamLoader);

            var type = GetType();
            var attributes = type.GetCustomAttributes(true);

            if (!attributes.Any(a => a is TypesFilenameAttribute))
                throw new ArgumentException("This test class does not have the needed TypesFilenameAttribute");

            var typesFilenameAttribute = attributes.First(a => a is TypesFilenameAttribute) as TypesFilenameAttribute;
            filename = typesFilenameAttribute.Filename;
        }

        protected void AssertContent(String gearName, IEnumerable<String> expectedTypes)
        {
            CacheTable();

            var actualTypes = table[gearName];

            foreach (var expectedType in expectedTypes)
                Assert.That(actualTypes, Contains.Item(expectedType));

            Assert.That(actualTypes.Count(), Is.EqualTo(expectedTypes.Count()));
        }

        private void CacheTable()
        {
            if (table == null)
                table = typesXmlParser.Parse(filename);
        }
    }
}