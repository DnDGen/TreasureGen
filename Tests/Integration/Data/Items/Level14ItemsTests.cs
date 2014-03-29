﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level14ItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level14Items";
        }

        [Test]
        public void Level14ItemsEmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 19);
        }

        [Test]
        public void Level14ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d6", PowerConstants.Minor);
            AssertPercentile(content, 20, 58);
        }

        [Test]
        public void Level14ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Medium);
            AssertPercentile(content, 59, 92);
        }

        [Test]
        public void Level14ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertPercentile(content, 93, 100);
        }
    }
}