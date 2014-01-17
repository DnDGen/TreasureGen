using System;
using System.Linq;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class GoodPercentileResultProviderTests
    {
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private IGoodPercentileResultProvider provider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns("good type,roll to determine amount");

            provider = new GoodPercentileResultProvider(mockPercentileResultProvider.Object);
        }

        [Test]
        public void GetsResultFromLevelGoodsTable()
        {
            provider.GetGoodPercentileResult(1);
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("Level1Goods"), Times.Once);
        }

        [Test]
        public void GoodTypeIsFirstPartOfResult()
        {
            var result = provider.GetGoodPercentileResult(1);
            Assert.That(result.GoodType, Is.EqualTo("good type"));
        }

        [Test]
        public void RollToDetermineAmountIsSecondPartOfResult()
        {
            var result = provider.GetGoodPercentileResult(1);
            Assert.That(result.RollToDetermineAmount, Is.EqualTo("roll to determine amount"));
        }

        [Test]
        public void EmptyPercentileResultGivesEmptyGood()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns(String.Empty);

            var result = provider.GetGoodPercentileResult(1);
            Assert.That(result.GoodType, Is.EqualTo(String.Empty));
            Assert.That(result.RollToDetermineAmount, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GoodValuePercentileComesFromProvider()
        {
            var goodType = "good type";
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(goodType + "Value")).Returns("value roll,description 1,description 2");

            var result = provider.GetGoodValuePercentileResult(goodType);
            Assert.That(result.ValueRoll, Is.EqualTo("value roll"));
            Assert.That(result.Descriptions, Contains.Item("description 1"));
            Assert.That(result.Descriptions, Contains.Item("description 2"));
            Assert.That(result.Descriptions.Count(), Is.EqualTo(2));
        }
    }
}