using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GetResultCachesTable()
        {
            percentileResultProvider.GetResultFrom(tableName);
            percentileResultProvider.GetResultFrom(tableName);

            mockPercentileXmlParser.Verify(p => p.Parse(tableName + ".xml"), Times.Once());
        }

        [Test]
        public void GetResultReturnsEmptyStringForEmptyTable()
        {
            table.Clear();
            var result = percentileResultProvider.GetResultFrom(tableName);
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetResultReturnsEmptyStringIfBelowRange()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(min - 1);
            var result = percentileResultProvider.GetResultFrom(tableName);
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetResultReturnsEmptyStringIfAboveRange()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(max + 1);
            var result = percentileResultProvider.GetResultFrom(tableName);
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetResultReturnContentIfInInclusiveRange()
        {
            for (var roll = min; roll <= max; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var result = percentileResultProvider.GetResultFrom(tableName);
                Assert.That(result, Is.EqualTo("content"));
            }
        }

        [Test]
        public void GetAllResultsReturnsWholeTable()
        {
            var results = percentileResultProvider.GetAllResultsFrom(tableName);
            var tableContents = table.Select(o => o.Content);
            Assert.That(results, Is.EqualTo(tableContents));
        }

        [Test]
        public void GetAllResultsCachesTable()
        {
            percentileResultProvider.GetAllResultsFrom(tableName);
            percentileResultProvider.GetAllResultsFrom(tableName);

            mockPercentileXmlParser.Verify(p => p.Parse(tableName + ".xml"), Times.Once());
        }
    }
}