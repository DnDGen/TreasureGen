using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Generators.Goods;
using EquipmentGen.Generators.Interfaces.Goods;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Goods
{
    [TestFixture]
    public class GoodsGeneratorTests
    {
        private Mock<IDice> mockDice;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private IGoodsGenerator generator;

        private TypeAndAmountPercentileResult typeAndAmountResult;
        private TypeAndAmountPercentileResult valueResult;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            generator = new GoodsGenerator(mockDice.Object, mockTypeAndAmountPercentileSelector.Object, mockAttributesSelector.Object);
            typeAndAmountResult = new TypeAndAmountPercentileResult();
            valueResult = new TypeAndAmountPercentileResult();

            typeAndAmountResult.Type = "type";
            typeAndAmountResult.Amount = 2;
            valueResult.Type = "first value";
            valueResult.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns(typeAndAmountResult);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(typeAndAmountResult.Type + "Values")).Returns(valueResult);

            var descriptions = new[] { "description 1", "description 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom(typeAndAmountResult.Type + "Descriptions", It.IsAny<String>())).Returns(descriptions);
            mockDice.Setup(d => d.Roll(1).d(2)).Returns(2);
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
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom("Level1Goods"), Times.Once);
        }

        [Test]
        public void EmptyGoodsIfNoGoodType()
        {
            typeAndAmountResult.Type = String.Empty;
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods, Is.Empty);
        }

        [Test]
        public void ReturnsNumberOfGoods()
        {
            typeAndAmountResult.Amount = 9266;
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods.Count(), Is.EqualTo(9266));
        }

        [Test]
        public void ValueDeterminedByValueResult()
        {
            var secondValueResult = new TypeAndAmountPercentileResult();
            secondValueResult.Type = "second value";
            secondValueResult.Amount = 90210;
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(typeAndAmountResult.Type + "Values"))
                .Returns(valueResult).Returns(secondValueResult);

            var goods = generator.GenerateAtLevel(1);
            var firstGood = goods.First();
            var secondGood = goods.Last();

            Assert.That(firstGood.ValueInGold, Is.EqualTo(9266));
            Assert.That(secondGood.ValueInGold, Is.EqualTo(90210));
        }

        [Test]
        public void DescriptionDeterminedByValueResult()
        {
            mockDice.SetupSequence(d => d.Roll(1).d(2)).Returns(1).Returns(2);

            var good = generator.GenerateAtLevel(1);
            var firstGood = good.First();
            var secondGood = good.Last();

            Assert.That(firstGood.Description, Is.EqualTo("description 1"));
            Assert.That(secondGood.Description, Is.EqualTo("description 2"));
        }
    }
}