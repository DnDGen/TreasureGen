using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level10CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level10Coins";
        }

        [Test]
        public void Level10EmptyPercentile()
        {
            AssertEmpty(1, 10);
        }

        [Test]
        public void Level10SilverPercentile()
        {
            var result = String.Format("{0},2d10*1000", CoinConstants.Silver);
            AssertContent(result, 11, 24);
        }

        [Test]
        public void Level10GoldPercentile()
        {
            var result = String.Format("{0},6d4*100", CoinConstants.Gold);
            AssertContent(result, 25, 79);
        }

        [Test]
        public void Level10PlatinumPercentile()
        {
            var result = String.Format("{0},5d6*10", CoinConstants.Platinum);
            AssertContent(result, 80, 100);
        }
    }
}