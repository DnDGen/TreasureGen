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
    public class GearTypesXmlParserTests
    {
        private IGearTypesXmlParser gearTypesXmlParser;
        private Mock<IStreamLoader> mockStreamLoader;
        private const String filename = "PercentileXmlParserTests.xml";

        [SetUp]
        public void Setup()
        {
            MakeXmlFile();

            mockStreamLoader = new Mock<IStreamLoader>();
            mockStreamLoader.Setup(l => l.LoadStream(filename)).Returns(GetStream());

            gearTypesXmlParser = new GearTypesXmlParser(mockStreamLoader.Object);
        }

        [Test]
        public void LoadXmlFromStream()
        {
            var objects = gearTypesXmlParser.Parse(filename);

            Assert.That(objects.Count(), Is.EqualTo(2));

            var armorTypes = objects["armor"];
            Assert.That(armorTypes, Contains.Item("armor type 1"));
            Assert.That(armorTypes, Contains.Item("armor type 2"));
            Assert.That(armorTypes.Count(), Is.EqualTo(2));

            var weaponTypes = objects["weapon"];
            Assert.That(weaponTypes, Contains.Item("weapon type 1"));
            Assert.That(weaponTypes, Contains.Item("weapon type 2"));
            Assert.That(weaponTypes, Contains.Item("weapon type 3"));
            Assert.That(weaponTypes.Count(), Is.EqualTo(3));
        }

        private Stream GetStream()
        {
            return new FileStream(filename, FileMode.Open);
        }

        private void MakeXmlFile()
        {
            var content = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><gearTypes><object><gear>armor</gear><type>armor type 1</type><type>armor type 2</type></object><object><gear>weapon</gear><type>weapon type 1</type><type>weapon type 2</type><type>weapon type 3</type></object></gearTypes>";
            File.WriteAllText(filename, content);
        }
    }
}