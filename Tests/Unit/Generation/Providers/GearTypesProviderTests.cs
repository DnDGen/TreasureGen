using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class GearTypesProviderTests
    {
        private IGearTypesProvider gearTypesProvider;
        private Mock<ITypesXmlParser> mockGearTypesXmlParser;

        private IEnumerable<String> expected;

        [SetUp]
        public void Setup()
        {
            expected = new[] { "type 1", "type 2" };
            var table = new Dictionary<String, IEnumerable<String>>();
            table.Add("gear name", expected);

            mockGearTypesXmlParser = new Mock<ITypesXmlParser>();
            mockGearTypesXmlParser.Setup(p => p.Parse("GearTypes.xml")).Returns(table);

            gearTypesProvider = new GearTypesProvider(mockGearTypesXmlParser.Object);
        }

        [Test]
        public void GearTypesProviderGetsTypesFromXmlParser()
        {
            var actual = gearTypesProvider.GetGearTypesFor("gear name");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GearTypesProviderCachesTable()
        {
            gearTypesProvider.GetGearTypesFor("gear name");
            gearTypesProvider.GetGearTypesFor("gear name");
            mockGearTypesXmlParser.Verify(p => p.Parse(It.IsAny<String>()), Times.Once);
        }
    }
}