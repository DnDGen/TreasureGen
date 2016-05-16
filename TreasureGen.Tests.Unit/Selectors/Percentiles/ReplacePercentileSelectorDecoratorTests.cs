using Moq;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class ReplacePercentileSelectorDecoratorTests
    {
        private IPercentileSelector decorator;
        private Mock<IPercentileSelector> mockInnerSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();

            var replacementStrings = new[] { "FIRST", "SECOND" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.ReplacementStrings, TableNameConstants.Attributes.Set.ReplacementStrings))
                .Returns(replacementStrings);
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.ReplacementStrings, "FIRST")).Returns(new[] { "first table" });
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.ReplacementStrings, "SECOND")).Returns(new[] { "second table" });

            decorator = new ReplacePercentileSelectorDecorator(mockInnerSelector.Object, mockAttributesSelector.Object);
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
            Assert.That(result, Is.EqualTo(percentiles));
        }

        [Test]
        public void GetReplacementStringsOnConstruction()
        {
            mockAttributesSelector.Verify(s => s.SelectFrom(TableNameConstants.Attributes.Set.ReplacementStrings, TableNameConstants.Attributes.Set.ReplacementStrings),
                Times.Once);
            mockAttributesSelector.Verify(s => s.SelectFrom(TableNameConstants.Attributes.Set.ReplacementStrings, "FIRST"), Times.Once);
            mockAttributesSelector.Verify(s => s.SelectFrom(TableNameConstants.Attributes.Set.ReplacementStrings, "SECOND"), Times.Once);
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
    }
}