using System;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture, PercentileTable("Level13Coins")]
    public class Level13CoinTests : PercentileTests
    {
        [Test]
        public void Level13EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level13GoldPercentile()
        {
            var result = String.Format("{0},1d4*1000", CoinConstants.Gold);
            AssertContent(result, 9, 75);
        }

        [Test]
        public void Level13PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*100", CoinConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}