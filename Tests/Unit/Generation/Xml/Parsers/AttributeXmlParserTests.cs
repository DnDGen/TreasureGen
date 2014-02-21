using System;
using System.IO;
using System.Linq;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Parsers
{
    [TestFixture]
    public class AttributeXmlParserTests
    {
        private IAttributesXmlParser attributeXmlParser;
        private Mock<IStreamLoader> mockStreamLoader;
        private const String filename = "AttributeXmlParserTests.xml";

        [SetUp]
        public void Setup()
        {
            MakeXmlFile();

            mockStreamLoader = new Mock<IStreamLoader>();
            mockStreamLoader.Setup(l => l.LoadStream(filename)).Returns(GetStream());

            attributeXmlParser = new AttributesXmlParser(mockStreamLoader.Object);
        }

        [Test]
        public void LoadXmlFromStream()
        {
            var table = attributeXmlParser.Parse(filename);

            Assert.That(table.Count(), Is.EqualTo(2));

            var armorAttributes = table["armor"];
            Assert.That(armorAttributes, Contains.Item("attribute 1"));
            Assert.That(armorAttributes, Contains.Item("attribute 2"));
            Assert.That(armorAttributes.Count(), Is.EqualTo(2));

            var weaponAttributes = table["weapon"];
            Assert.That(weaponAttributes, Contains.Item("attribute 1"));
            Assert.That(weaponAttributes, Contains.Item("attribute 2"));
            Assert.That(weaponAttributes, Contains.Item("attribute 3"));
            Assert.That(weaponAttributes.Count(), Is.EqualTo(3));
        }

        private Stream GetStream()
        {
            return new FileStream(filename, FileMode.Open);
        }

        private void MakeXmlFile()
        {
            var content = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><attributes><object><name>armor</key><attribute>attribute 1</attribute><attribute>attribute 2</attribute></object><object><name>weapon</name><attribute>attribute 1</attribute><attribute>attribute 2</attribute><attribute>attribute 3</attribute></object></attributes>";
            File.WriteAllText(filename, content);
        }
    }
}