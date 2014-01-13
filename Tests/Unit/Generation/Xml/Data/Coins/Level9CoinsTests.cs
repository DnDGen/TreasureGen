using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level9CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level9Coins";
        }

        [Test]
        public void Level9EmptyPercentile()
        {
            AssertEmpty(1, 10);
        }

        [Test]
        public void Level9CopperPercentile()
        {
            var result = String.Format("{0},2d6*10000", CoinConstants.Copper);
            AssertContent(result, 11, 15);
        }

        [Test]
        public void Level9SilverPercentile()
        {
            var result = String.Format("{0},2d8*1000", CoinConstants.Silver);
            AssertContent(result, 16, 29);
        }

        [Test]
        public void Level9GoldPercentile()
        {
            var result = String.Format("{0},5d4*100", CoinConstants.Gold);
            AssertContent(result, 30, 85);
        }

        [Test]
        public void Level9PlatinumPercentile()
        {
            var result = String.Format("{0},2d12*10", CoinConstants.Platinum);
            AssertContent(result, 86, 100);
        }
    }
}