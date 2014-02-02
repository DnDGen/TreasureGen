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
    public abstract class TypesTest
    {
        private ITypesProvider typesProvider;
        private String tableName;

        [SetUp]
        public void Setup()
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            var typesXmlParser = new TypesXmlParser(streamLoader);
            typesProvider = new TypesProvider(typesXmlParser);

            var type = GetType();
            var attributes = type.GetCustomAttributes(true);

            if (!attributes.Any(a => a is TypesTableNameAttribute))
                throw new ArgumentException("This test class does not have the needed TypesTableNameAttribute");

            var typesFilenameAttribute = attributes.First(a => a is TypesTableNameAttribute) as TypesTableNameAttribute;
            tableName = typesFilenameAttribute.TableName;
        }

        protected void AssertContent(String name, IEnumerable<String> expectedTypes)
        {
            var actualTypes = typesProvider.GetTypesFor(name, tableName);

            foreach (var expectedType in expectedTypes)
                Assert.That(actualTypes, Contains.Item(expectedType));

            var tooMany = actualTypes.Except(expectedTypes);
            var tooManyString = String.Join(", ", tooMany);
            var message = String.Format("Should not be in results: {0}", tooManyString);
            Assert.That(actualTypes.Count(), Is.EqualTo(expectedTypes.Count()), message);
        }
    }
}