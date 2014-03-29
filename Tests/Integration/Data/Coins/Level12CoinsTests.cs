﻿using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level12CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level12Coins";
        }

        [Test]
        public void Level12EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 8);
        }

        [Test]
        public void Level12SilverPercentile()
        {
            var result = String.Format("{0},3d12*1000", CoinConstants.Silver);
            AssertPercentile(result, 9, 14);
        }

        [Test]
        public void Level12GoldPercentile()
        {
            var result = String.Format("{0},1d4*1000", CoinConstants.Gold);
            AssertPercentile(result, 15, 75);
        }

        [Test]
        public void Level12PlatinumPercentile()
        {
            var result = String.Format("{0},1d4*100", CoinConstants.Platinum);
            AssertPercentile(result, 76, 100);
        }
    }
}