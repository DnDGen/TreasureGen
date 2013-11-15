using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level20CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level20Coins";
        }

        [Test]
        public void Level20EmptyPercentile()
        {
            AssertEmpty(1, 2);
        }

        [Test]
        public void Level20GoldPercentile()
        {
            var result = String.Format("{0},4d8*1000", CoinConstants.Gold);
            AssertContent(result, 3, 65);
        }

        [Test]
        public void Level20PlatinumPercentile()
        {
            var result = String.Format("{0},4d10*100", CoinConstants.Platinum);
            AssertContent(result, 66, 100);
        }
    }
}