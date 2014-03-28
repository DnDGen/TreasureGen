using System;
using EquipmentGen.Common.Coins;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level18Coins")]
    public class Level18CoinTests : PercentileTests
    {
        [Test]
        public void Level18EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 2);
        }

        [Test]
        public void Level18GoldPercentile()
        {
            var result = String.Format("{0},3d6*1000", CoinConstants.Gold);
            AssertPercentile(result, 3, 65);
        }

        [Test]
        public void Level18PlatinumPercentile()
        {
            var result = String.Format("{0},5d4*100", CoinConstants.Platinum);
            AssertPercentile(result, 66, 100);
        }
    }
}