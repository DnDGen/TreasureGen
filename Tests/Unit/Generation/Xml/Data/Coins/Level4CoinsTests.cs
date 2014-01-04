using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level4CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level4Coins";
        }

        [Test]
        public void Level4EmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level4CopperPercentile()
        {
            var result = String.Format("{0},3d10*1000", CoinConstants.Copper);
            AssertContent(result, 12, 21);
        }

        [Test]
        public void Level4SilverPercentile()
        {
            var result = String.Format("{0},4d12*1000", CoinConstants.Silver);
            AssertContent(result, 22, 41);
        }

        [Test]
        public void Level4GoldPercentile()
        {
            var result = String.Format("{0},1d6*100", CoinConstants.Gold);
            AssertContent(result, 42, 95);
        }

        [Test]
        public void Level4PlatinumPercentile()
        {
            var result = String.Format("{0},1d8*10", CoinConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}