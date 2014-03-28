using System;
using EquipmentGen.Common.Coins;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level14Coins")]
    public class Level14CoinTests : PercentileTests
    {
        [Test]
        public void Level14EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 8);
        }

        [Test]
        public void Level14GoldPercentile()
        {
            var result = String.Format("{0},1d6*1000", CoinConstants.Gold);
            AssertPercentile(result, 9, 75);
        }

        [Test]
        public void Level14PlatinumPercentile()
        {
            var result = String.Format("{0},1d12*100", CoinConstants.Platinum);
            AssertPercentile(result, 76, 100);
        }
    }
}