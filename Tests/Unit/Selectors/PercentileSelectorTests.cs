using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Mappers.Interfaces;
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
        private Dictionary<Int32, String> table;
        private Mock<IPercentileMapper> mockPercentileMapper;
        private const String tableName = "table";
        private const Int32 min = 10;
        private const Int32 max = 12;

        [SetUp]
        public void Setup()
        {
            table = new Dictionary<Int32, String>();
            for (var i = min; i <= max; i++)
                table.Add(i, "content");

            mockPercentileMapper = new Mock<IPercentileMapper>();
            mockPercentileMapper.Setup(p => p.Map(tableName)).Returns(table);

            percentileSelector = new PercentileSelector(mockPercentileMapper.Object);
        }

        [Test]
        public void GetResultCachesTable()
        {
            percentileSelector.SelectFrom(tableName, min);
            percentileSelector.SelectFrom(tableName, min);

            mockPercentileMapper.Verify(p => p.Map(tableName), Times.Once());
        }

        [Test]
        public void ThrowErrorIfRollLessThan1()
        {
            Assert.That(() => percentileSelector.SelectFrom(tableName, 0), Throws.ArgumentException);
        }

        [Test]
        public void ThrowErrorIfRollGreaterThan100()
        {
            Assert.That(() => percentileSelector.SelectFrom(tableName, 101), Throws.ArgumentException);
        }

        [Test]
        public void GetResultReturnsDifferentContentIfBelowRange()
        {
            table.Add(min - 1, "other content");
            var result = percentileSelector.SelectFrom(tableName, min - 1);
            Assert.That(result, Is.EqualTo(table[min - 1]));
        }

        [Test]
        public void GetResultReturnsDifferentContentIfAboveRange()
        {
            table.Add(max + 1, "other content");
            var result = percentileSelector.SelectFrom(tableName, max + 1);
            Assert.That(result, Is.EqualTo(table[max + 1]));
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
            var tableContents = table.Values.Distinct();
            Assert.That(results, Is.EqualTo(tableContents));
        }

        [Test]
        public void GetAllResultsCachesTable()
        {
            percentileSelector.SelectAllFrom(tableName);
            percentileSelector.SelectAllFrom(tableName);

            mockPercentileMapper.Verify(p => p.Map(tableName), Times.Once());
        }
    }
}