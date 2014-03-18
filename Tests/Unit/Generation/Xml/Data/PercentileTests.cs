using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Objects;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data
{
    [TestFixture]
    public abstract class PercentileTests
    {
        private IEnumerable<PercentileObject> table;

        [SetUp]
        public void Setup()
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            var percentileXmlParser = new PercentileXmlParser(streamLoader);

            var type = GetType();
            var attributes = type.GetCustomAttributes(true);

            if (!attributes.Any(a => a is PercentileTableAttribute))
                throw new ArgumentException("This test class does not have the needed PercentileTableAttribute");

            var percentileTableAttribute = attributes.First(a => a is PercentileTableAttribute) as PercentileTableAttribute;
            var file = String.Format("{0}.xml", percentileTableAttribute.Table);
            table = percentileXmlParser.Parse(file);
        }

        protected void AssertEmpty(Int32 roll)
        {
            AssertEmpty(roll, roll);
        }

        protected void AssertEmpty(Int32 minInclusive, Int32 maxInclusive)
        {
            Assert.That(table.Any(o => o.LowerLimit >= minInclusive && o.UpperLimit <= maxInclusive), Is.False);
        }

        protected void AssertContent(String content, Int32 roll)
        {
            AssertContent(content, roll, roll);
        }

        protected void AssertContent(String content, Int32 minInclusive, Int32 maxInclusive)
        {
            Assert.That(table.Select(o => o.Content), Contains.Item(content), "Content not in table");
            Assert.That(table.Where(o => o.Content == content).Count(), Is.EqualTo(1), "Uniqueness of content");

            var result = table.Single(o => o.Content == content);
            Assert.That(result.LowerLimit, Is.EqualTo(minInclusive), "Lower limit");
            Assert.That(result.UpperLimit, Is.EqualTo(maxInclusive), "Upper limit");
        }
    }
}