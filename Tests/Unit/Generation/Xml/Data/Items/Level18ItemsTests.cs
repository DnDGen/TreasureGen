using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level18ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level18Items";
        }

        [Test]
        public void Level18ItemsEmptyPercentile()
        {
            AssertEmpty(1, 24);
        }

        [Test]
        public void Level18ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Power.Medium);
            AssertContent(content, 25, 80);
        }

        [Test]
        public void Level18ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Major);
            AssertContent(content, 81, 100);
        }
    }
}