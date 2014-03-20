using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;
using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class PercentileSelectorTests
    {
        private IPercentileSelector percentileSelector;
        private List<PercentileObject> table;
        private Mock<IPercentileMapper> mockPercentileMapper;
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

            mockPercentileMapper = new Mock<IPercentileMapper>();
            mockPercentileMapper.Setup(p => p.Map(tableName + ".xml")).Returns(table);

            percentileSelector = new PercentileSelector(mockPercentileMapper.Object);
        }

        [Test]
        public void GetResultCachesTable()
        {
            percentileSelector.SelectFrom(tableName, 1);
            percentileSelector.SelectFrom(tableName, 1);

            mockPercentileMapper.Verify(p => p.Map(tableName + ".xml"), Times.Once());
        }

        [Test]
        public void GetResultReturnsEmptyStringForEmptyTable()
        {
            table.Clear();
            var result = percentileSelector.SelectFrom(tableName, 1);
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetResultReturnsEmptyStringIfBelowRange()
        {
            var result = percentileSelector.SelectFrom(tableName, min - 1);
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetResultReturnsEmptyStringIfAboveRange()
        {
            var result = percentileSelector.SelectFrom(tableName, max + 1);
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetResultReturnContentIfInInclusiveRange()
        {
            for (var roll = min; roll <= max; roll++)
            {
                var result = percentileSelector.SelectFrom(tableName, roll);
                Assert.That(result, Is.EqualTo("content"));
            }
        }

        [Test]
        public void GetAllResultsReturnsWholeTable()
        {
            var results = percentileSelector.SelectAllFrom(tableName);
            var tableContents = table.Select(o => o.Content);
            Assert.That(results, Is.EqualTo(tableContents));
        }

        [Test]
        public void GetAllResultsCachesTable()
        {
            percentileSelector.SelectAllFrom(tableName);
            percentileSelector.SelectAllFrom(tableName);

            mockPercentileMapper.Verify(p => p.Map(tableName + ".xml"), Times.Once());
        }
    }
}