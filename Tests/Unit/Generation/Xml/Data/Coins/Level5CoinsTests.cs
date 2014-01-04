using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level5CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level5Coins";
        }

        [Test]
        public void Level5EmptyPercentile()
        {
            AssertEmpty(1, 10);
        }

        [Test]
        public void Level5CopperPercentile()
        {
            var result = String.Format("{0},1d4*10000", CoinConstants.Copper);
            AssertContent(result, 11, 19);
        }

        [Test]
        public void Level5SilverPercentile()
        {
            var result = String.Format("{0},1d6*1000", CoinConstants.Silver);
            AssertContent(result, 20, 38);
        }

        [Test]
        public void Level5GoldPercentile()
        {
            var result = String.Format("{0},1d8*100", CoinConstants.Gold);
            AssertContent(result, 39, 95);
        }

        [Test]
        public void Level5PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*10", CoinConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}