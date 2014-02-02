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
    public class TypesProviderTests
    {
        private ITypesProvider typesProvider;
        private Mock<ITypesXmlParser> mockTypesXmlParser;

        private IEnumerable<String> expected;

        [SetUp]
        public void Setup()
        {
            expected = new[] { "type 1", "type 2" };
            var table = new Dictionary<String, IEnumerable<String>>();
            table.Add("name", expected);
            table.Add("other name", expected);

            mockTypesXmlParser = new Mock<ITypesXmlParser>();
            mockTypesXmlParser.Setup(p => p.Parse("table name.xml")).Returns(table);
            mockTypesXmlParser.Setup(p => p.Parse("other table name.xml")).Returns(table);

            typesProvider = new TypesProvider(mockTypesXmlParser.Object);
        }

        [Test]
        public void TypesProviderGetsTypesFromXmlParser()
        {
            var actual = typesProvider.GetTypesFor("name", "table name");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TypesProviderCachesTable()
        {
            typesProvider.GetTypesFor("name", "table name");
            typesProvider.GetTypesFor("other name", "table name");
            mockTypesXmlParser.Verify(p => p.Parse(It.IsAny<String>()), Times.Once);
        }

        [Test]
        public void TypesProviderCachesAllTables()
        {
            typesProvider.GetTypesFor("name", "table name");
            typesProvider.GetTypesFor("other name", "table name");

            typesProvider.GetTypesFor("name", "other table name");
            typesProvider.GetTypesFor("other name", "other table name");

            mockTypesXmlParser.Verify(p => p.Parse(It.IsAny<String>()), Times.Exactly(2));
            mockTypesXmlParser.Verify(p => p.Parse("table name.xml"), Times.Once);
            mockTypesXmlParser.Verify(p => p.Parse("other table name.xml"), Times.Once);
        }

        [Test]
        public void TypesProviderThrowsErrorIfNameNotFound()
        {
            Assert.That(() => typesProvider.GetTypesFor("unknown gear name", "table name"), Throws.InstanceOf<ItemNotFoundException>());
        }
    }
}