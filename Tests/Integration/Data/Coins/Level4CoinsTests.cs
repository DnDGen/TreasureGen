﻿using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level4CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level4Coins";
        }

        [Test]
        public void Level4EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 11);
        }

        [Test]
        public void Level4CopperPercentile()
        {
            var result = String.Format("{0},3d10*1000", CoinConstants.Copper);
            AssertPercentile(result, 12, 21);
        }

        [Test]
        public void Level4SilverPercentile()
        {
            var result = String.Format("{0},4d12*1000", CoinConstants.Silver);
            AssertPercentile(result, 22, 41);
        }

        [Test]
        public void Level4GoldPercentile()
        {
            var result = String.Format("{0},1d6*100", CoinConstants.Gold);
            AssertPercentile(result, 42, 95);
        }

        [Test]
        public void Level4PlatinumPercentile()
        {
            var result = String.Format("{0},1d8*10", CoinConstants.Platinum);
            AssertPercentile(result, 96, 100);
        }
    }
}