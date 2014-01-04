using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level13CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level13Coins";
        }

        [Test]
        public void Level13EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level13GoldPercentile()
        {
            var result = String.Format("{0},1d4*1000", CoinConstants.Gold);
            AssertContent(result, 9, 75);
        }

        [Test]
        public void Level13PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*100", CoinConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}