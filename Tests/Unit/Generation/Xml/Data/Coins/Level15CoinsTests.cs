using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level15CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level15Coins";
        }

        [Test]
        public void Level15EmptyPercentile()
        {
            AssertEmpty(1, 3);
        }

        [Test]
        public void Level15GoldPercentile()
        {
            var result = String.Format("{0},1d8*1000", CoinConstants.Gold);
            AssertContent(result, 4, 74);
        }

        [Test]
        public void Level15PlatinumPercentile()
        {
            var result = String.Format("{0},3d4*100", CoinConstants.Platinum);
            AssertContent(result, 75, 100);
        }
    }
}