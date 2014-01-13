using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level11CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level11Coins";
        }

        [Test]
        public void Level11EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level11SilverPercentile()
        {
            var result = String.Format("{0},3d10*1000", CoinConstants.Silver);
            AssertContent(result, 9, 14);
        }

        [Test]
        public void Level11GoldPercentile()
        {
            var result = String.Format("{0},4d8*100", CoinConstants.Gold);
            AssertContent(result, 15, 75);
        }

        [Test]
        public void Level11PlatinumPercentile()
        {
            var result = String.Format("{0},4d10*10", CoinConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}