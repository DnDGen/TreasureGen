using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level3CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level3Coins";
        }

        [Test]
        public void Level3EmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level3CopperPercentile()
        {
            var result = String.Format("{0},2d10*1000", CoinConstants.Copper);
            AssertContent(result, 12, 21);
        }

        [Test]
        public void Level3SilverPercentile()
        {
            var result = String.Format("{0},4d8*100", CoinConstants.Silver);
            AssertContent(result, 22, 41);
        }

        [Test]
        public void Level3GoldPercentile()
        {
            var result = String.Format("{0},1d4*100", CoinConstants.Gold);
            AssertContent(result, 42, 95);
        }

        [Test]
        public void Level3PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*10", CoinConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}