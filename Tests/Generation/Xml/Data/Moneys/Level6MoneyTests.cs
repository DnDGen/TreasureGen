using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level6MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level6Money";
        }

        [Test]
        public void Level6EmptyPercentile()
        {
            AssertEmpty(1, 10);
        }

        [Test]
        public void Level6CopperPercentile()
        {
            var result = String.Format("{0},1d6*10000", MoneyConstants.Copper);
            AssertContent(result, 11, 18);
        }

        [Test]
        public void Level6SilverPercentile()
        {
            var result = String.Format("{0},1d8*1000", MoneyConstants.Silver);
            AssertContent(result, 19, 37);
        }

        [Test]
        public void Level6GoldPercentile()
        {
            var result = String.Format("{0},1d10*100", MoneyConstants.Gold);
            AssertContent(result, 38, 95);
        }

        [Test]
        public void Level6PlatinumPercentile()
        {
            var result = String.Format("{0},1d12*10", MoneyConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}