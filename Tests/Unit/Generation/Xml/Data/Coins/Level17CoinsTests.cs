using System;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture, PercentileTable("Level17Coins")]
    public class Level17CoinTests : PercentileTests
    {
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