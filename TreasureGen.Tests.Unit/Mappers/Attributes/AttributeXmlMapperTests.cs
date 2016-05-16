using Moq;
using NUnit.Framework;
using System.IO;
using System.Linq;
using TreasureGen.Domain.Mappers.Attributes;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Unit.Mappers.Attributes
{
    [TestFixture]
    public class AttributeXmlMapperTests
    {
        private const string tableName = "AttributeXmlMapperTests";

        private IAttributesMapper mapper;
        private Mock<IStreamLoader> mockStreamLoader;
        private string fileName;

        [SetUp]
        public void Setup()
        {
            fileName = tableName + ".xml";

            mockStreamLoader = new Mock<IStreamLoader>();
            mockStreamLoader.Setup(l => l.LoadFor(fileName)).Returns(() => GetStream());

            mapper = new AttributesXmlMapper(mockStreamLoader.Object);
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

            Assert.That(table.Count(), Is.EqualTo(3));

            var armorAttributes = table["armor"];
            Assert.That(armorAttributes, Contains.Item("armor attribute 1"));
            Assert.That(armorAttributes, Contains.Item("armor attribute 2"));
            Assert.That(armorAttributes.Count(), Is.EqualTo(2));

            var weaponAttributes = table["weapon"];
            Assert.That(weaponAttributes, Contains.Item("weapon attribute 1"));
            Assert.That(weaponAttributes, Contains.Item("weapon attribute 2"));
            Assert.That(weaponAttributes, Contains.Item("weapon attribute 3"));
            Assert.That(weaponAttributes.Count(), Is.EqualTo(3));

            var emptyAttributes = table["empty"];
            Assert.That(emptyAttributes, Is.Empty);
        }

        private Stream GetStream()
        {
            var content = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                            <attributes>
                                <object>
                                    <name>armor</name>
                                    <attribute>armor attribute 1</attribute>
                                    <attribute>armor attribute 2</attribute>
                                </object>
                                <object>
                                    <name>weapon</name>
                                    <attribute>weapon attribute 1</attribute>
                                    <attribute>weapon attribute 2</attribute>
                                    <attribute>weapon attribute 3</attribute>
                                </object>
                                <object>
                                    <name>empty</name>
                                </object>
                            </attributes>";

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}