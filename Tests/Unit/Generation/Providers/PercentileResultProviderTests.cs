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

        [Test]
        public void GetAllResultsIncludesEmptyStringIfEmptyTable()
        {
            table.Clear();
            var results = percentileResultProvider.GetAllResults(tableName);

            Assert.That(results.Contains(String.Empty), Is.True);
            Assert.That(results.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAllResultsReturnsAllContentValues()
        {
            for (var i = 1; i < 10; i++)
                table.Add(new PercentileObject() { Content = String.Format("Item {0}", i) });

            var results = percentileResultProvider.GetAllResults(tableName);

            foreach (var percentileObject in table)
                Assert.That(results.Contains(percentileObject.Content), Is.True);
        }

        [Test]
        public void GetAllResultsIncludesEmptyStringIfIncompleteTable()
        {
            var results = percentileResultProvider.GetAllResults(tableName);
            Assert.That(results.Contains(String.Empty), Is.True);
        }

        [Test]
        public void GetAllResultsCachesTable()
        {
            percentileResultProvider.GetAllResults(tableName);
            percentileResultProvider.GetAllResults(tableName);

            mockPercentileXmlParser.Verify(p => p.Parse(tableName + ".xml"), Times.Once());
        }

        [Test]
        public void CompleteTableWithOneEntryIsSeenAsComplete()
        {
            DetermineUpperLimits(1);
        }

        [Test]
        public void CompleteTableWithTwoEntriesIsSeenAsComplete()
        {
            DetermineUpperLimits(2);
        }

        [Test]
        public void CompleteTableWithThreeEntriesIsSeenAsComplete()
        {
            DetermineUpperLimits(3);
        }

        private void DetermineUpperLimits(Int32 numberOfLimits)
        {
            var upperLimits = new[] { 100 };

            if (numberOfLimits == 1)
                AssertPercentileObjects(upperLimits);
            else
                DetermineUpperLimits(numberOfLimits, upperLimits);
        }

        private void DetermineUpperLimits(Int32 numberOfLimits, IEnumerable<Int32> upperLimits)
        {
            for (var newUpperLimit = upperLimits.First() - 1; newUpperLimit > 0; newUpperLimit--)
            {
                var addedUpperLimits = upperLimits.Union(new[] { newUpperLimit }).OrderBy(l => l);

                if (numberOfLimits <= addedUpperLimits.Count())
                    AssertPercentileObjects(addedUpperLimits);
                else
                    DetermineUpperLimits(numberOfLimits, addedUpperLimits);
            }
        }

        private void AssertPercentileObjects(IEnumerable<Int32> upperLimits)
        {
            if (upperLimits.Last() != 100 || upperLimits.Distinct().Count() != upperLimits.Count())
                throw new ArgumentException();

            table.Clear();
            table.Add(new PercentileObject() { LowerLimit = 1, UpperLimit = upperLimits.First() });

            for (var i = 1; i < upperLimits.Count(); i++)
                table.Add(new PercentileObject() { LowerLimit = upperLimits.ElementAt(i - 1) + 1, UpperLimit = upperLimits.ElementAt(i) });

            var results = percentileResultProvider.GetAllResults(tableName);
            Assert.That(results.Contains(String.Empty), Is.False);
        }
    }
}