using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level1CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level1Coins";
        }

        [Test]
        public void Level1EmptyPercentile()
        {
            AssertEmpty(1, 14);
        }

        [Test]
        public void Level1CopperPercentile()
        {
            var result = String.Format("{0},1d6*1000", CoinConstants.Copper);
            AssertContent(result, 15, 29);
        }

        [Test]
        public void Level1SilverPercentile()
        {
            var result = String.Format("{0},1d8*100", CoinConstants.Silver);
            AssertContent(result, 30, 52);
        }

        [Test]
        public void Level1GoldPercentile()
        {
            var result = String.Format("{0},2d8*10", CoinConstants.Gold);
            AssertContent(result, 53, 95);
        }

        [Test]
        public void Level1PlatinumPercentile()
        {
            var result = String.Format("{0},1d4*10", CoinConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}