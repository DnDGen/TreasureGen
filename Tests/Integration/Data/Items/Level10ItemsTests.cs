﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level10ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level10Items";
        }

        [Test]
        public void Level10ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 40);
        }

        [Test]
        public void Level10ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Minor);
            AssertPercentile(content, 41, 88);
        }

        [Test]
        public void Level10ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 89, 99);
        }

        [Test]
        public void Level10ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 100);
        }
    }
}