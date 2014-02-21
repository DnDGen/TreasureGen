using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Exceptions;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class AttributesProviderTests
    {
        private IAttributesProvider typesProvider;
        private Mock<IAttributesXmlParser> mockTypesXmlParser;

        private IEnumerable<String> expected;

        [SetUp]
        public void Setup()
        {
            expected = new[] { "type 1", "type 2" };
            var table = new Dictionary<String, IEnumerable<String>>();
            table.Add("name", expected);
            table.Add("other name", expected);

            mockTypesXmlParser = new Mock<IAttributesXmlParser>();
            mockTypesXmlParser.Setup(p => p.Parse("table name.xml")).Returns(table);
            mockTypesXmlParser.Setup(p => p.Parse("other table name.xml")).Returns(table);

            typesProvider = new AttributesProvider(mockTypesXmlParser.Object);
        }

        [Test]
        public void TypesProviderGetsTypesFromXmlParser()
        {
            var actual = typesProvider.GetAttributesFor("name", "table name");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TypesProviderCachesTable()
        {
            typesProvider.GetAttributesFor("name", "table name");
            typesProvider.GetAttributesFor("other name", "table name");
            mockTypesXmlParser.Verify(p => p.Parse(It.IsAny<String>()), Times.Once);
        }

        [Test]
        public void TypesProviderCachesAllTables()
        {
            typesProvider.GetAttributesFor("name", "table name");
            typesProvider.GetAttributesFor("other name", "table name");

            typesProvider.GetAttributesFor("name", "other table name");
            typesProvider.GetAttributesFor("other name", "other table name");

            mockTypesXmlParser.Verify(p => p.Parse(It.IsAny<String>()), Times.Exactly(2));
            mockTypesXmlParser.Verify(p => p.Parse("table name.xml"), Times.Once);
            mockTypesXmlParser.Verify(p => p.Parse("other table name.xml"), Times.Once);
        }

        [Test]
        public void TypesProviderThrowsErrorIfNameNotFound()
        {
            Assert.That(() => typesProvider.GetAttributesFor("unknown gear name", "table name"), Throws.InstanceOf<ItemNotFoundException>());
        }
    }
}