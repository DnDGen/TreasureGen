using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data
{
    [TestFixture]
    public abstract class TypesTest
    {
        protected String filename;

        private ITypesXmlParser typesXmlParser;
        private Dictionary<String, IEnumerable<String>> table;

        [SetUp]
        public void Setup()
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            typesXmlParser = new TypesXmlParser(streamLoader);
        }

        protected void AssertContent(String gearName, params String[] expectedTypes)
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