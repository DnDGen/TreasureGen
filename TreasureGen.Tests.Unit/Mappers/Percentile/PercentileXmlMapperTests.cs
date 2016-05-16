using Moq;
using NUnit.Framework;
using System.IO;
using System.Linq;
using TreasureGen.Domain.Mappers.Percentile;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Unit.Mappers.Percentile
{
    [TestFixture]
    public class PercentileXmlMapperTests
    {
        private const string tableName = "PercentileXmlMapperTests";

        private IPercentileMapper mapper;
        private Mock<IStreamLoader> mockStreamLoader;
        private string fileName;

        [SetUp]
        public void Setup()
        {
            mockStreamLoader = new Mock<IStreamLoader>();
            mapper = new PercentileXmlMapper(mockStreamLoader.Object);

            fileName = tableName + ".xml";
            mockStreamLoader.Setup(l => l.LoadFor(fileName)).Returns(() => GetStream());
        }

        [Test]
        public void AppendXmlFileExtensionToTableName()
        {
            mapper.Map(tableName);
            mockStreamLoader.Verify(l => l.LoadFor(fileName), Times.Once);
        }

        [Test]
        public void LoadFromStream()
        {
            var table = mapper.Map(tableName);

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
            var content = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                            <percentile>
                                <object>
                                    <lower>1</lower>
                                    <content>one through five</content>
                                    <upper>5</upper>
                                </object>
                                <object>
                                    <lower>6</lower>
                                    <content>six only</content>
                                    <upper>6</upper>
                                </object>
                                <object>
                                    <lower>7</lower>
                                    <content></content>
                                    <upper>7</upper>
                                </object>
                            </percentile>";

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}