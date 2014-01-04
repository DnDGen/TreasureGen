using System;
using System.IO;
using System.Linq;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Parsers
{
    [TestFixture]
    public class PercentileXmlParserTests
    {
        private IPercentileXmlParser percentileXmlParser;
        private Mock<IStreamLoader> mockStreamLoader;
        private const String filename = "PercentileXmlParserTests.xml";

        [SetUp]
        public void Setup()
        {
            MakeXmlFile();

            mockStreamLoader = new Mock<IStreamLoader>();
            mockStreamLoader.Setup(l => l.LoadStream(filename)).Returns(GetStream());

            percentileXmlParser = new PercentileXmlParser(mockStreamLoader.Object);
        }

        [Test]
        public void LoadXmlFromStream()
        {
            var objects = percentileXmlParser.Parse(filename);

            Assert.That(objects.Count(), Is.EqualTo(2));

            var firstElement = objects.ElementAt(0);
            Assert.That(firstElement.LowerLimit, Is.EqualTo(1));
            Assert.That(firstElement.Content, Is.EqualTo("one through five"));
            Assert.That(firstElement.UpperLimit, Is.EqualTo(5));

            var secondElement = objects.ElementAt(1);
            Assert.That(secondElement.LowerLimit, Is.EqualTo(6));
            Assert.That(secondElement.Content, Is.EqualTo("six only"));
            Assert.That(secondElement.UpperLimit, Is.EqualTo(6));
        }

        private Stream GetStream()
        {
            return new FileStream(filename, FileMode.Open);
        }

        private void MakeXmlFile()
        {
            var content = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><percentile><object><lower>1</lower><content>one through five</content><upper>5</upper></object><object><lower>6</lower><content>six only</content><upper>6</upper></object></percentile>";
            File.WriteAllText(filename, content);
        }
    }
}