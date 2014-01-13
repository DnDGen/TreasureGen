using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level19CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level19Coins";
        }

        [Test]
        public void Level19EmptyPercentile()
        {
            AssertEmpty(1, 2);
        }

        [Test]
        public void Level19GoldPercentile()
        {
            var result = String.Format("{0},3d8*1000", CoinConstants.Gold);
            AssertContent(result, 3, 65);
        }

        [Test]
        public void Level19PlatinumPercentile()
        {
            var result = String.Format("{0},3d10*100", CoinConstants.Platinum);
            AssertContent(result, 66, 100);
        }
    }
}