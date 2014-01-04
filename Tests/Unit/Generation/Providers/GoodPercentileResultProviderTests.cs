using System;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Providers
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
    }
}