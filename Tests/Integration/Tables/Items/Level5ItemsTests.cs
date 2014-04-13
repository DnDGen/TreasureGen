﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level5ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level5Items"; }
        }

        [TestCase(EmptyContent, 1, 57)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Mundane, "1d4", 58, 67)]
        [TestCase(PowerConstants.Minor, "1d3", 68, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}