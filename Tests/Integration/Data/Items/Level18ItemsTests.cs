using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level18Items")]
    public class Level18ItemsTests : PercentileTests
    {
        [Test]
        public void Level18ItemsEmptyPercentile()
        {
            AssertEmpty(1, 24);
        }

        [Test]
        public void Level18ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Medium);
            AssertContent(content, 25, 80);
        }

        [Test]
        public void Level18ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Major);
            AssertContent(content, 81, 100);
        }
    }
}