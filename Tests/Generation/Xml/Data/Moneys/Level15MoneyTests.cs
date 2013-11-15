﻿using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level15MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level15Money";
        }

        [Test]
        public void Level15EmptyPercentile()
        {
            AssertEmpty(1, 3);
        }

        [Test]
        public void Level15GoldPercentile()
        {
            var result = String.Format("{0},1d8*1000", MoneyConstants.Gold);
            AssertContent(result, 4, 74);
        }

        [Test]
        public void Level15PlatinumPercentile()
        {
            var result = String.Format("{0},3d4*100", MoneyConstants.Platinum);
            AssertContent(result, 75, 100);
        }
    }
}