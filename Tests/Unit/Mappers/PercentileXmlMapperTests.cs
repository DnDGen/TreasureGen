using System;
using System.IO;
using System.Linq;
using EquipmentGen.Mappers;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Tables.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Mappers
{
    [TestFixture]
    public class PercentileXmlMapperTests
    {
        private IPercentileMapper mapper;
        private Mock<IStreamLoader> mockStreamLoader;
        private const String filename = "PercentileXmlMapperTests.xml";

        [SetUp]
        public void Setup()
        {
            MakeXmlFile();

            mockStreamLoader = new Mock<IStreamLoader>();
            mockStreamLoader.Setup(l => l.LoadFor(It.IsAny<String>())).Returns(GetStream());

            mapper = new PercentileXmlMapper(mockStreamLoader.Object);
        }

        [Test]
        public void AppendXmlFileExtensionToTableName()
        {
            mapper.Map(filename);
            mockStreamLoader.Verify(l => l.LoadFor(filename + ".xml"), Times.Once);
        }

        [Test]
        public void LoadFromStream()
        {
            var table = mapper.Map(filename);

            Assert.That(table[1], Is.EqualTo("one through five"));
            Assert.That(table[2], Is.EqualTo("one through five"));
            Assert.That(table[3], Is.EqualTo("one through five"));
            Assert.That(table[4], Is.EqualTo("one through five"));
            Assert.That(table[5], Is.EqualTo("one through five"));
            Assert.That(table[6], Is.EqualTo("six only"));
            Assert.That(table[7], Is.Empty);
            Assert.That(table.Count(), Is.EqualTo(7));
        }

        private Stream GetStream()
        {
            return new FileStream(filename, FileMode.Open);
        }

        private void MakeXmlFile()
        {
            var content = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><percentile><object><lower>1</lower><content>one through five</content><upper>5</upper></object><object><lower>6</lower><content>six only</content><upper>6</upper></object><object><lower>7</lower><content></content><upper>7</upper></object></percentile>";
            File.WriteAllText(filename, content);
        }
    }
}