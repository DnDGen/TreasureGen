using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;
using System;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level1MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level1Money";
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertEmpty(1, 14);
        }

        [Test]
        public void Level1CopperPercentile()
        {
            var result = String.Format("{0},1d6*1000", MoneyConstants.Copper);
            AssertContent(result, 15, 29);
        }

        [Test]
        public void Level1SilverPercentile()
        {
            var result = String.Format("{0},1d8*100", MoneyConstants.Silver);
            AssertContent(result, 30, 52);
        }

        [Test]
        public void Level1GoldPercentile()
        {
            var result = String.Format("{0},2d8*10", MoneyConstants.Gold);
            AssertContent(result, 53, 95);
        }

        [Test]
        public void Level1PlatinumPercentile()
        {
            var result = String.Format("{0},1d4*10", MoneyConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}