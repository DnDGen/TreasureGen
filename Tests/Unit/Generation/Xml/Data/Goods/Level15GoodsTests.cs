﻿using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture, PercentileTable("Level15Goods")]
    public class Level15GoodsTests : PercentileTests
    {
        [Test]
        public void Level15EmptyPercentile()
        {
            AssertEmpty(1, 9);
        }

        [Test]
        public void Level15GemPercentile()
        {
            var content = String.Format("{0},2d10", GoodsConstants.Gem);
            AssertContent(content, 10, 65);
        }

        [Test]
        public void Level15ArtPercentile()
        {
            var content = String.Format("{0},2d8", GoodsConstants.Art);
            AssertContent(content, 66, 100);
        }
    }
}