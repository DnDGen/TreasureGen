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
    public class SpecialAbilityDataXmlParserTests
    {
        private ISpecialAbilityDataXmlParser parser;
        private Mock<IStreamLoader> mockStreamLoader;
        private const String filename = "SpecialAbilityDataXmlParserTests.xml";

        [SetUp]
        public void Setup()
        {
            MakeXmlFile();

            mockStreamLoader = new Mock<IStreamLoader>();
            mockStreamLoader.Setup(l => l.LoadStream(filename)).Returns(GetStream());

            parser = new SpecialAbilityDataXmlParser(mockStreamLoader.Object);
        }

        [Test]
        public void LoadXmlFromStream()
        {
            var objects = parser.Parse(filename);

            Assert.That(objects.Count(), Is.EqualTo(2));
            Assert.That(objects["ability"].BonusEquivalent, Is.EqualTo(92));
            Assert.That(objects["ability"].CoreName, Is.EqualTo("core name"));
            Assert.That(objects["ability"].Strength, Is.EqualTo(66));
            Assert.That(objects["other ability"].BonusEquivalent, Is.EqualTo(42));
            Assert.That(objects["other ability"].CoreName, Is.EqualTo("other core name"));
            Assert.That(objects["other ability"].Strength, Is.EqualTo(9000));
        }

        private Stream GetStream()
        {
            return new FileStream(filename, FileMode.Open);
        }

        private void MakeXmlFile()
        {
            var content = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                            <abilities>
                                <object>
                                    <name>ability</name>
                                    <bonus>92</bonus>
                                    <strength>66</strength>
                                    <coreName>core name</coreName>
                                </object>
                                <object>
                                    <name>other ability</name>
                                    <bonus>42</bonus>
                                    <strength>9000</strength>
                                    <coreName>other core name</coreName>
                                </object>
                            </abilities>";

            File.WriteAllText(filename, content);
        }
    }
}