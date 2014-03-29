﻿using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level2CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level2Coins";
        }

        [Test]
        public void Level2EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 13);
        }

        [Test]
        public void Level2CopperPercentile()
        {
            var result = String.Format("{0},1d10*1000", CoinConstants.Copper);
            AssertPercentile(result, 14, 23);
        }

        [Test]
        public void Level2SilverPercentile()
        {
            var result = String.Format("{0},2d10*100", CoinConstants.Silver);
            AssertPercentile(result, 24, 43);
        }

        [Test]
        public void Level2GoldPercentile()
        {
            var result = String.Format("{0},4d10*10", CoinConstants.Gold);
            AssertPercentile(result, 44, 95);
        }

        [Test]
        public void Level2PlatinumPercentile()
        {
            var result = String.Format("{0},2d8*10", CoinConstants.Platinum);
            AssertPercentile(result, 96, 100);
        }
    }
}