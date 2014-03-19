using System;
using EquipmentGen.Common.Coins;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level4Coins")]
    public class Level4CoinTests : PercentileTests
    {
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