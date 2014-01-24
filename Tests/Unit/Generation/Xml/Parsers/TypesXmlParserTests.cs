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
    public class TypesXmlParserTests
    {
        private ITypesXmlParser typesXmlParser;
        private Mock<IStreamLoader> mockStreamLoader;
        private const String filename = "TypesXmlParserTests.xml";

        [SetUp]
        public void Setup()
        {
            MakeXmlFile();

            mockStreamLoader = new Mock<IStreamLoader>();
            mockStreamLoader.Setup(l => l.LoadStream(filename)).Returns(GetStream());

            typesXmlParser = new TypesXmlParser(mockStreamLoader.Object);
        }

        [Test]
        public void LoadXmlFromStream()
        {
            var objects = typesXmlParser.Parse(filename);

            Assert.That(objects.Count(), Is.EqualTo(2));

            var armorTypes = objects["key 1"];
            Assert.That(armorTypes, Contains.Item("type 1"));
            Assert.That(armorTypes, Contains.Item("type 2"));
            Assert.That(armorTypes.Count(), Is.EqualTo(2));

            var weaponTypes = objects["key 2"];
            Assert.That(weaponTypes, Contains.Item("type 1"));
            Assert.That(weaponTypes, Contains.Item("type 2"));
            Assert.That(weaponTypes, Contains.Item("type 3"));
            Assert.That(weaponTypes.Count(), Is.EqualTo(3));
        }

        private Stream GetStream()
        {
            return new FileStream(filename, FileMode.Open);
        }

        private void MakeXmlFile()
        {
            var content = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><types><object><key>key 1</key><type>type 1</type><type>type 2</type></object><object><key>key 2</key><type>type 1</type><type>type 2</type><type>type 3</type></object></types>";
            File.WriteAllText(filename, content);
        }
    }
}