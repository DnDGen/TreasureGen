using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using TreasureGen.Mappers;
using TreasureGen.Mappers.Domain.Attributes;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Unit.Mappers.Attributes
{
    [TestFixture]
    public class AttributeXmlMapperTests
    {
        private IAttributesMapper mapper;
        private Mock<IStreamLoader> mockStreamLoader;
        private const String tableName = "AttributeXmlMapperTests";

        [SetUp]
        public void Setup()
        {
            MakeXmlFile();

            mockStreamLoader = new Mock<IStreamLoader>();
            var stream = GetStream();
            mockStreamLoader.Setup(l => l.LoadFor(It.IsAny<String>())).Returns(stream);

            mapper = new AttributesXmlMapper(mockStreamLoader.Object);
        }

        [Test]
        public void AppendXmlFileExtensionToTableName()
        {
            mapper.Map(tableName);
            mockStreamLoader.Verify(l => l.LoadFor(tableName + ".xml"), Times.Once);
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
            return new FileStream(tableName, FileMode.Open);
        }

        private void MakeXmlFile()
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

            File.WriteAllText(tableName, content);
        }
    }
}