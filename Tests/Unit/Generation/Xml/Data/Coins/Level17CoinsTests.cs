using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level17CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level17Coins";
        }

        [Test]
        public void Level17EmptyPercentile()
        {
            AssertEmpty(1, 3);
        }

        [Test]
        public void Level17GoldPercentile()
        {
            var result = String.Format("{0},3d4*1000", CoinConstants.Gold);
            AssertContent(result, 4, 68);
        }

        [Test]
        public void Level17PlatinumPercentile()
        {
            var result = String.Format("{0},2d10*100", CoinConstants.Platinum);
            AssertContent(result, 69, 100);
        }
    }
}