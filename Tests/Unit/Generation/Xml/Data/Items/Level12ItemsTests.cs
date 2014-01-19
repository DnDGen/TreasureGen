using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level12ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level12Items";
        }

        [Test]
        public void Level12ItemsEmptyPercentile()
        {
            AssertEmpty(1, 27);
        }

        [Test]
        public void Level12ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d6", ItemsConstants.Power.Minor);
            AssertContent(content, 28, 82);
        }

        [Test]
        public void Level12ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Medium);
            AssertContent(content, 83, 97);
        }

        [Test]
        public void Level12ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Major);
            AssertContent(content, 98, 100);
        }
    }
}