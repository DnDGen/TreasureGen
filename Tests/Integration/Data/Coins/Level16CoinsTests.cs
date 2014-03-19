using System;
using EquipmentGen.Common.Coins;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level16Coins")]
    public class Level16CoinTests : PercentileTests
    {
        [Test]
        public void Level16EmptyPercentile()
        {
            AssertEmpty(1, 3);
        }

        [Test]
        public void Level16GoldPercentile()
        {
            var result = String.Format("{0},1d12*1000", CoinConstants.Gold);
            AssertContent(result, 4, 74);
        }

        [Test]
        public void Level16PlatinumPercentile()
        {
            var result = String.Format("{0},3d4*100", CoinConstants.Platinum);
            AssertContent(result, 75, 100);
        }
    }
}