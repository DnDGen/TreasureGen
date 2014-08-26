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
        private const String tableName = "table";

        private IPercentileSelector percentileSelector;
        private Dictionary<Int32, String> table;
        private Mock<IPercentileMapper> mockPercentileMapper;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            table = new Dictionary<Int32, String>();
            mockPercentileMapper = new Mock<IPercentileMapper>();
            mockDice = new Mock<IDice>();
            percentileSelector = new PercentileSelector(mockPercentileMapper.Object, mockDice.Object);

            mockPercentileMapper.Setup(p => p.Map(tableName)).Returns(table);
        }

        [Test]
        public void RollPercentile()
        {
            table.Add(9266, "9266 content");
            mockDice.Setup(d => d.Roll(1).Percentile()).Returns(9266);

            var result = percentileSelector.SelectFrom(tableName);
            Assert.That(result, Is.EqualTo(table[9266]));
        }

        [Test]
        public void RerollEverySelect()
        {
            table.Add(42, "other content");
            table.Add(9266, "9266 content");
            mockDice.SetupSequence(d => d.Roll(1).Percentile()).Returns(42).Returns(9266);

            var result = percentileSelector.SelectFrom(tableName);
            Assert.That(result, Is.EqualTo(table[42]));

            result = percentileSelector.SelectFrom(tableName);
            Assert.That(result, Is.EqualTo(table[9266]));
        }

        [Test]
        public void GetAllResultsReturnsWholeTable()
        {
            table.Add(9266, "9266 content");
            table.Add(42, "42 content");
            for (var i = 0; i <= 10; i++)
                table.Add(i, "content");

            var results = percentileSelector.SelectAllFrom(tableName);
            var tableContents = table.Values.Distinct();
            Assert.That(results, Is.EqualTo(tableContents));
        }
    }
}