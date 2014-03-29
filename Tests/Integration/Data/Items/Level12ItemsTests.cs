﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level12ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level12Items";
        }

        [Test]
        public void Level12ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 27);
        }

        [Test]
        public void Level12ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d6", PowerConstants.Minor);
            AssertPercentile(content, 28, 82);
        }

        [Test]
        public void Level12ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 83, 97);
        }

        [Test]
        public void Level12ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 98, 100);
        }
    }
}