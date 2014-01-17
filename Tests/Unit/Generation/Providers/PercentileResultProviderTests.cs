using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class PercentileResultProviderTests
    {
        private IPercentileResultProvider percentileResultProvider;
        private List<PercentileObject> table;
        private Mock<IDice> mockDice;
        private Mock<IPercentileXmlParser> mockPercentileXmlParser;
        private const String tableName = "table";
        private const Int32 min = 1;
        private const Int32 max = 50;

        [SetUp]
        public void Setup()
        {
            var percentileObject = new PercentileObject();
            percentileObject.Content = "content";
            percentileObject.LowerLimit = min;
            percentileObject.UpperLimit = max;

            table = new List<PercentileObject>();
            table.Add(percentileObject);

            mockPercentileXmlParser = new Mock<IPercentileXmlParser>();
            mockPercentileXmlParser.Setup(p => p.Parse(tableName + ".xml")).Returns(table);

            mockDice = new Mock<IDice>();
            percentileResultProvider = new PercentileResultProvider(mockPercentileXmlParser.Object, mockDice.Object);
        }

        [Test]
        public void GetPercentileResultCachesTable()
        {
            percentileResultProvider.GetPercentileResult(tableName);
            percentileResultProvider.GetPercentileResult(tableName);

            mockPercentileXmlParser.Verify(p => p.Parse(tableName + ".xml"), Times.Once());
        }

        [Test]
        public void GetPercentileResultReturnsEmptyStringForEmptyTable()
        {
            table.Clear();
            var result = percentileResultProvider.GetPercentileResult(tableName);
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetPercentileResultReturnsEmptyStringIfBelowRange()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(min - 1);
            var result = percentileResultProvider.GetPercentileResult(tableName);
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetPercentileResultReturnsEmptyStringIfAboveRange()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(max + 1);
            var result = percentileResultProvider.GetPercentileResult(tableName);
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetPercentileResultReturnContentIfInInclusiveRange()
        {
            for (var roll = min; roll <= max; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);

                var result = percentileResultProvider.GetPercentileResult(tableName);
                Assert.That(result, Is.EqualTo("content"));
            }
        }
    }
}