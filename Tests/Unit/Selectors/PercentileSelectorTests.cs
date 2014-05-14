using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
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
        private Mock<IDice> mockDice;
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

            mockDice = new Mock<IDice>();

            percentileSelector = new PercentileSelector(mockPercentileMapper.Object, mockDice.Object);
        }

        [Test]
        public void GetResultReturnsDifferentContentIfBelowRange()
        {
            table.Add(min - 1, "other content");
            mockDice.Setup(s => s.Percentile(1)).Returns(min - 1);
            var result = percentileSelector.SelectFrom(tableName);
            Assert.That(result, Is.EqualTo(table[min - 1]));
        }

        [Test]
        public void GetResultReturnsDifferentContentIfAboveRange()
        {
            table.Add(max + 1, "other content");
            mockDice.Setup(s => s.Percentile(1)).Returns(max + 1);
            var result = percentileSelector.SelectFrom(tableName);
            Assert.That(result, Is.EqualTo(table[max + 1]));
        }

        [Test]
        public void GetResultReturnContentIfInInclusiveRange()
        {
            for (var roll = min; roll <= max; roll++)
            {
                mockDice.Setup(s => s.Percentile(1)).Returns(roll);
                var result = percentileSelector.SelectFrom(tableName);
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
    }
}