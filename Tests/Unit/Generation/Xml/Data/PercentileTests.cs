using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data
{
    [TestFixture]
    public abstract class PercentileTests
    {
        private Mock<IDice> mockDice;
        private IPercentileResultProvider percentileResultProvider;
        private String tableName;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            var streamLoader = new EmbeddedResourceStreamLoader();
            var percentileXmlParser = new PercentileXmlParser(streamLoader);
            percentileResultProvider = new PercentileResultProvider(percentileXmlParser, mockDice.Object);

            var type = GetType();
            var attributes = type.GetCustomAttributes(true);

            if (!attributes.Any(a => a is PercentileTableAttribute))
                throw new ArgumentException("This test class does not have the needed PercentileTableAttribute");

            var percentileTableAttribute = attributes.First(a => a is PercentileTableAttribute) as PercentileTableAttribute;
            tableName = percentileTableAttribute.Table;
        }

        protected void AssertEmpty(Int32 roll)
        {
            AssertContent(String.Empty, roll);
        }

        protected void AssertEmpty(Int32 minInclusive, Int32 maxInclusive)
        {
            AssertContent(String.Empty, minInclusive, maxInclusive);
        }

        protected void AssertContent(String content, Int32 roll)
        {
            AssertContent(content, roll, roll);
        }

        protected void AssertContent(String content, Int32 minInclusive, Int32 maxInclusive)
        {
            for (var roll = 1; roll <= 100; roll++)
            {
                if (roll >= minInclusive && roll <= maxInclusive)
                    AssertRollGrantsContent(roll, content);
                else
                    AssertRollDoesNotGrantContent(roll, content);
            }
        }

        private void AssertRollGrantsContent(Int32 roll, String content)
        {
            var result = GetResult(roll);
            Assert.That(result, Is.EqualTo(content), String.Format("Roll: {0}", roll));
        }

        private void AssertRollDoesNotGrantContent(Int32 roll, String content)
        {
            var result = GetResult(roll);
            Assert.That(result, Is.Not.EqualTo(content), String.Format("Roll: {0}", roll));
        }

        private String GetResult(Int32 roll)
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(roll);
            return percentileResultProvider.GetResultFrom(tableName);
        }
    }
}