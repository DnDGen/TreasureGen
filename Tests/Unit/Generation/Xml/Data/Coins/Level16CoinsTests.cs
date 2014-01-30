﻿using System;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
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