using System;
using System.Collections.Generic;
using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Mappers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class AttributesProviderTests
    {
        private IAttributesProvider typesProvider;
        private Mock<IAttributesMapper> mockTypesXmlParser;

        private IEnumerable<String> expected;

        [SetUp]
        public void Setup()
        {
            expected = new[] { "type 1", "type 2" };
            var table = new Dictionary<String, IEnumerable<String>>();
            table.Add("name", expected);
            table.Add("other name", expected);

            mockTypesXmlParser = new Mock<IAttributesMapper>();
            mockTypesXmlParser.Setup(p => p.Parse("table name.xml")).Returns(table);
            mockTypesXmlParser.Setup(p => p.Parse("other table name.xml")).Returns(table);

            typesProvider = new AttributesProvider(mockTypesXmlParser.Object);
        }

        [Test]
        public void GetTypesFromXmlParser()
        {
            var actual = typesProvider.GetAttributesFor("name", "table name");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CacheTable()
        {
            typesProvider.GetAttributesFor("name", "table name");
            typesProvider.GetAttributesFor("other name", "table name");
            mockTypesXmlParser.Verify(p => p.Parse(It.IsAny<String>()), Times.Once);
        }

        [Test]
        public void CacheAllTables()
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
        public void ReturnEmptyIfNameNotFound()
        {
            var attributes = typesProvider.GetAttributesFor("unknown name", "table name");
            Assert.That(attributes, Is.Empty);
        }
    }
}