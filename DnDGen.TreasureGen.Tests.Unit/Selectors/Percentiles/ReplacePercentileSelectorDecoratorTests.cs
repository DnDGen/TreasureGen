using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.Infrastructure.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class ReplacePercentileSelectorDecoratorTests
    {
        private ITreasurePercentileSelector decorator;
        private Mock<IPercentileSelector> mockInnerSelector;
        private Mock<ICollectionSelector> mockCollectionsSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionSelector>();

            var replacementStrings = new[] { "FIRST", "SECOND" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ReplacementStrings, TableNameConstants.Collections.Set.ReplacementStrings))
                .Returns(replacementStrings);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ReplacementStrings, "FIRST")).Returns(new[] { "first table" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ReplacementStrings, "SECOND")).Returns(new[] { "second table" });

            decorator = new PercentileSelectorStringReplacementDecorator(mockInnerSelector.Object, mockCollectionsSelector.Object);
        }

        [Test]
        public void DecoratorSelectsFromInnerSelector()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table")).Returns("percentile");
            var result = decorator.SelectFrom("table");
            Assert.That(result, Is.EqualTo("percentile"));
        }

        [Test]
        public void DecoratorSelectsAllFromInnerSelector()
        {
            var percentiles = new[] { "first", "second" };
            mockInnerSelector.Setup(s => s.SelectAllFrom("table")).Returns(percentiles);

            var result = decorator.SelectAllFrom("table");
            Assert.That(result, Is.EquivalentTo(percentiles));
        }

        [Test]
        public void ReplaceStringsInResultWithResultFromMatchingTable()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table")).Returns("this is the SECOND percentile");
            mockInnerSelector.Setup(s => s.SelectFrom("second table")).Returns("new second");

            var result = decorator.SelectFrom("table");
            Assert.That(result, Is.EqualTo("this is the new second percentile"));
        }

        [Test]
        public void ReplaceMultipleStringsInResultWithResultFromMatchingTable()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table")).Returns("this is the SECOND percentile with FIRST");
            mockInnerSelector.Setup(s => s.SelectFrom("second table")).Returns("new second");
            mockInnerSelector.Setup(s => s.SelectFrom("first table")).Returns("new first");

            var result = decorator.SelectFrom("table");
            Assert.That(result, Is.EqualTo("this is the new second percentile with new first"));
        }

        [Test]
        public void ReplaceStringsInAllResultsWithResultsFromMatchingTable()
        {
            var percentiles = new[] { "this is FIRST", "this is the SECOND percentile", "non-replaced", "FIRST also" };
            mockInnerSelector.Setup(s => s.SelectAllFrom("table")).Returns(percentiles);
            mockInnerSelector.Setup(s => s.SelectAllFrom("first table")).Returns(new[] { "1-1", "1-2" });
            mockInnerSelector.Setup(s => s.SelectAllFrom("second table")).Returns(new[] { "2-1", "2-2", "2-3" });

            var results = decorator.SelectAllFrom("table");
            Assert.That(results, Contains.Item("this is 1-1"));
            Assert.That(results, Contains.Item("this is 1-2"));
            Assert.That(results, Contains.Item("this is the 2-1 percentile"));
            Assert.That(results, Contains.Item("this is the 2-2 percentile"));
            Assert.That(results, Contains.Item("this is the 2-3 percentile"));
            Assert.That(results, Contains.Item("1-1 also"));
            Assert.That(results, Contains.Item("1-2 also"));
            Assert.That(results, Contains.Item("non-replaced"));
            Assert.That(results, Is.Not.Contains("this is FIRST"));
            Assert.That(results, Is.Not.Contains("this is the SECOND percentile"));
            Assert.That(results, Is.Not.Contains("FIRST also"));
            Assert.That(results.Count(), Is.EqualTo(8));
        }

        [Test]
        public void ReplaceMultipleStringsInAllResultsWithResultsFromMatchingTable()
        {
            var percentiles = new[] { "this is FIRST", "this is the SECOND percentile", "non-replaced", "FIRST also with SECOND" };
            mockInnerSelector.Setup(s => s.SelectAllFrom("table")).Returns(percentiles);
            mockInnerSelector.Setup(s => s.SelectAllFrom("first table")).Returns(new[] { "1-1", "1-2" });
            mockInnerSelector.Setup(s => s.SelectAllFrom("second table")).Returns(new[] { "2-1", "2-2", "2-3" });

            var results = decorator.SelectAllFrom("table");
            Assert.That(results, Contains.Item("this is 1-1"));
            Assert.That(results, Contains.Item("this is 1-2"));
            Assert.That(results, Contains.Item("this is the 2-1 percentile"));
            Assert.That(results, Contains.Item("this is the 2-2 percentile"));
            Assert.That(results, Contains.Item("this is the 2-3 percentile"));
            Assert.That(results, Contains.Item("1-1 also with 2-1"));
            Assert.That(results, Contains.Item("1-1 also with 2-2"));
            Assert.That(results, Contains.Item("1-1 also with 2-3"));
            Assert.That(results, Contains.Item("1-2 also with 2-1"));
            Assert.That(results, Contains.Item("1-2 also with 2-2"));
            Assert.That(results, Contains.Item("1-2 also with 2-3"));
            Assert.That(results, Contains.Item("non-replaced"));
            Assert.That(results, Is.Not.Contains("this is FIRST"));
            Assert.That(results, Is.Not.Contains("this is the SECOND percentile"));
            Assert.That(results, Is.Not.Contains("FIRST also with SECOND"));
            Assert.That(results.Count(), Is.EqualTo(12));
        }
    }
}