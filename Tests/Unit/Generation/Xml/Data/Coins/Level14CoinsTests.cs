using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level14CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level14Coins";
        }

        [Test]
        public void Level14EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level14GoldPercentile()
        {
            var result = String.Format("{0},1d6*1000", CoinConstants.Gold);
            AssertContent(result, 9, 75);
        }

        [Test]
        public void Level14PlatinumPercentile()
        {
            var result = String.Format("{0},1d12*100", CoinConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}