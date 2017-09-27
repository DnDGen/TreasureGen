using DnDGen.Core.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Goods;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Goods;

namespace TreasureGen.Tests.Unit.Generators.Goods
{
    [TestFixture]
    public class GoodsGeneratorTests
    {
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionsSelector;
        private IGoodsGenerator generator;

        private TypeAndAmountSelection selection;
        private TypeAndAmountSelection valueSelection;
        private List<string> descriptions;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionSelector>();
            generator = new GoodsGenerator(mockTypeAndAmountPercentileSelector.Object, mockCollectionsSelector.Object);
            selection = new TypeAndAmountSelection();
            valueSelection = new TypeAndAmountSelection();

            selection.Type = "type";
            selection.Amount = 2;
            valueSelection.Type = "first value";
            valueSelection.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<string>())).Returns(selection);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, selection.Type);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(valueSelection);

            descriptions = new List<string> { "description 1", "description 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.GOODTYPEDescriptions, selection.Type);

            var count = 0;
            mockCollectionsSelector.Setup(p => p.SelectRandomFrom(tableName, It.IsAny<string>())).Returns(() => descriptions[count++ % descriptions.Count]);
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
            var goods = generator.GenerateAtLevel(1);
            var firstGood = goods.First();
            var secondGood = goods.Last();

            Assert.That(firstGood.Description, Is.EqualTo("description 1"));
            Assert.That(secondGood.Description, Is.EqualTo("description 2"));
        }
    }
}