﻿using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level11CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level11Coins"; }
        }

        [TestCase(EmptyContent, 1, 8)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Silver, "3d10*1000", 9, 14)]
        [TestCase(CoinConstants.Gold, "4d8*100", 15, 75)]
        [TestCase(CoinConstants.Platinum, "4d10*10", 76, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}