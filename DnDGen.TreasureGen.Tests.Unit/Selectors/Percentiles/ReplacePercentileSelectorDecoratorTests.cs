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
            mockInnerSelector.Setup(s => s.SelectFrom(Config.Name, "table")).Returns("percentile");
            mockReplacementSelector.Setup(s => s.SelectRandom("percentile")).Returns("replacement");

            var result = decorator.SelectFrom(Config.Name, "table");
            Assert.That(result, Is.EqualTo("replacement"));
        }

        [Test]
        public void DecoratorSelectsAllFromInnerSelector()
        {
            var percentiles = new[] { "first", "second" };
            var replacements = new[] { "third", "fourth" };
            mockInnerSelector.Setup(s => s.SelectAllFrom(Config.Name, "table")).Returns(percentiles);
            mockReplacementSelector.Setup(s => s.SelectAll(percentiles, false)).Returns(replacements);

            var results = decorator.SelectAllFrom(Config.Name, "table");
            Assert.That(results, Is.EquivalentTo(replacements));
        }
    }
}