using Moq;
using NUnit.Framework;
using RollGen;
using System.Linq;
using TreasureGen.Domain.Generators.Goods;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Goods;

namespace TreasureGen.Tests.Unit.Generators.Goods
{
    [TestFixture]
    public class GoodsGeneratorTests
    {
        private Mock<Dice> mockDice;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICollectionsSelector> mockAttributesSelector;
        private IGoodsGenerator generator;

        private TypeAndAmountSelection selection;
        private TypeAndAmountSelection valueSelection;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<Dice>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockAttributesSelector = new Mock<ICollectionsSelector>();
            generator = new GoodsGenerator(mockDice.Object, mockTypeAndAmountPercentileSelector.Object, mockAttributesSelector.Object);
            selection = new TypeAndAmountSelection();
            valueSelection = new TypeAndAmountSelection();

            selection.Type = "type";
            selection.Amount = 2;
            valueSelection.Type = "first value";
            valueSelection.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns(selection);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, selection.Type);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(valueSelection);

            var descriptions = new[] { "description 1", "description 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.GOODTYPEDescriptions, selection.Type);
            mockAttributesSelector.Setup(p => p.SelectFrom(tableName, It.IsAny<string>())).Returns(descriptions);
            mockDice.Setup(d => d.Roll(1).d(2).AsSum()).Returns(2);
        }

        [Test]
        public void GoodsAreGenerated()
        {
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods, Is.Not.Null);
        }

        [Test]
        public void GetTypeAndAmountFromSelector()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, 1);
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom(tableName), Times.Once);
        }

        [Test]
        public void EmptyGoodsIfNoGoodType()
        {
            selection.Type = string.Empty;
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods, Is.Empty);
        }

        [Test]
        public void ReturnsNumberOfGoods()
        {
            selection.Amount = 9266;
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods.Count(), Is.EqualTo(9266));
        }

        [Test]
        public void ValueDeterminedByValueResult()
        {
            var secondValueResult = new TypeAndAmountSelection();
            secondValueResult.Type = "second value";
            secondValueResult.Amount = 90210;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, selection.Type);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns(valueSelection).Returns(secondValueResult);

            var goods = generator.GenerateAtLevel(1);
            var firstGood = goods.First();
            var secondGood = goods.Last();

            Assert.That(firstGood.ValueInGold, Is.EqualTo(9266));
            Assert.That(secondGood.ValueInGold, Is.EqualTo(90210));
        }

        [Test]
        public void DescriptionDeterminedByValueResult()
        {
            mockDice.SetupSequence(d => d.Roll(1).d(2).AsSum()).Returns(1).Returns(2);

            var goods = generator.GenerateAtLevel(1);
            var firstGood = goods.First();
            var secondGood = goods.Last();

            Assert.That(firstGood.Description, Is.EqualTo("description 1"));
            Assert.That(secondGood.Description, Is.EqualTo("description 2"));
        }
    }
}