using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level12CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level12Coins";
        }

        [Test]
        public void Level12EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level12SilverPercentile()
        {
            var result = String.Format("{0},3d12*1000", CoinConstants.Silver);
            AssertContent(result, 9, 14);
        }

        [Test]
        public void Level12GoldPercentile()
        {
            var result = String.Format("{0},1d4*1000", CoinConstants.Gold);
            AssertContent(result, 15, 75);
        }

        [Test]
        public void Level12PlatinumPercentile()
        {
            var result = String.Format("{0},1d4*100", CoinConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}