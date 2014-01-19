using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level15ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level15Items";
        }

        [Test]
        public void Level15ItemsEmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level15ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d10", ItemsConstants.Power.Minor);
            AssertContent(content, 12, 46);
        }

        [Test]
        public void Level15ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Medium);
            AssertContent(content, 47, 90);
        }

        [Test]
        public void Level15ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Major);
            AssertContent(content, 91, 100);
        }
    }
}