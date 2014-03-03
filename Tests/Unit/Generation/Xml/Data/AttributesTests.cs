using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data
{
    [TestFixture]
    public abstract class AttributesTests
    {
        private IAttributesProvider attributesProvider;
        private String tableName;

        [SetUp]
        public void Setup()
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            var attributesXmlParser = new AttributesXmlParser(streamLoader);
            attributesProvider = new AttributesProvider(attributesXmlParser);

            var type = GetType();
            var attributes = type.GetCustomAttributes(true);

            if (!attributes.Any(a => a is AttributesTableAttribute))
                throw new ArgumentException("This test class does not have the needed AttributesTableNameAttribute");

            var attributesFilenameAttribute = attributes.First(a => a is AttributesTableAttribute) as AttributesTableAttribute;
            tableName = attributesFilenameAttribute.TableName;
        }

        protected void AssertContent(String name, IEnumerable<String> expectedAttributes)
        {
            var actualAttributes = attributesProvider.GetAttributesFor(name, tableName);

            foreach (var expectedAttribute in expectedAttributes)
                Assert.That(actualAttributes, Contains.Item(expectedAttribute));

            var tooMany = actualAttributes.Except(expectedAttributes);
            var tooManyString = String.Join(", ", tooMany);
            var message = String.Format("Should not be in results: {0}", tooManyString);
            Assert.That(actualAttributes.Count(), Is.EqualTo(expectedAttributes.Count()), message);
        }
    }
}