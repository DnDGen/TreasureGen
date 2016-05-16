using Moq;
using NUnit.Framework;
using RollGen;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Mappers.Percentile;
using TreasureGen.Domain.Selectors.Percentiles;

namespace TreasureGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class PercentileSelectorTests
    {
        private const string tableName = "table";

        private IPercentileSelector percentileSelector;
        private Dictionary<int, string> table;
        private Mock<IPercentileMapper> mockPercentileMapper;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            table = new Dictionary<int, string>();
            mockPercentileMapper = new Mock<IPercentileMapper>();
            mockDice = new Mock<Dice>();
            percentileSelector = new PercentileSelector(mockPercentileMapper.Object, mockDice.Object);

            mockPercentileMapper.Setup(p => p.Map(tableName)).Returns(table);
        }

        [Test]
        public void RollPercentile()
        {
            table.Add(9266, "9266 content");
            mockDice.Setup(d => d.Roll(1).IndividualRolls(100)).Returns(new[] { 9266 });

            var result = percentileSelector.SelectFrom(tableName);
            Assert.That(result, Is.EqualTo(table[9266]));
        }

        [Test]
        public void RerollEverySelect()
        {
            table.Add(42, "other content");
            table.Add(9266, "9266 content");
            mockDice.SetupSequence(d => d.Roll(1).IndividualRolls(100)).Returns(new[] { 42 }).Returns(new[] { 9266 });

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