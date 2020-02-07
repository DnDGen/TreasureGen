using DnDGen.Infrastructure.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Percentiles;
using Moq;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class ReplacePercentileSelectorDecoratorTests
    {
        private ITreasurePercentileSelector decorator;
        private Mock<IPercentileSelector> mockInnerSelector;
        private Mock<IReplacementSelector> mockReplacementSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IPercentileSelector>();
            mockReplacementSelector = new Mock<IReplacementSelector>();

            decorator = new PercentileSelectorStringReplacementDecorator(mockInnerSelector.Object, mockReplacementSelector.Object);
        }

        [Test]
        public void DecoratorSelectsFromInnerSelector()
        {
            mockInnerSelector.Setup(s => s.SelectFrom("table")).Returns("percentile");
            mockReplacementSelector.Setup(s => s.SelectRandom("percentile")).Returns("replacement");

            var result = decorator.SelectFrom("table");
            Assert.That(result, Is.EqualTo("replacement"));
        }

        [Test]
        public void DecoratorSelectsAllFromInnerSelector()
        {
            var percentiles = new[] { "first", "second" };
            var replacements = new[] { "third", "fourth" };
            mockInnerSelector.Setup(s => s.SelectAllFrom("table")).Returns(percentiles);
            mockReplacementSelector.Setup(s => s.SelectAll(percentiles)).Returns(replacements);

            var results = decorator.SelectAllFrom("table");
            Assert.That(results, Is.EquivalentTo(replacements));
        }
    }
}