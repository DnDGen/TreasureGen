using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class AttributesSelectorTests
    {
        private IAttributesSelector attributesSelector;
        private Mock<IAttributesMapper> mockAttributesMapper;

        private IEnumerable<String> expected;

        [SetUp]
        public void Setup()
        {
            expected = new[] { "type 1", "type 2" };
            var table = new Dictionary<String, IEnumerable<String>>();
            table.Add("name", expected);
            table.Add("other name", expected);

            mockAttributesMapper = new Mock<IAttributesMapper>();
            mockAttributesMapper.Setup(p => p.Map("table name")).Returns(table);
            mockAttributesMapper.Setup(p => p.Map("other table name")).Returns(table);

            attributesSelector = new AttributesSelector(mockAttributesMapper.Object);
        }

        [Test]
        public void GetAttributesFromMapper()
        {
            var actual = attributesSelector.SelectFrom("table name", "name");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ReturnEmptyIfNameNotFound()
        {
            var attributes = attributesSelector.SelectFrom("table name", "unknown name");
            Assert.That(attributes, Is.Empty);
        }
    }
}