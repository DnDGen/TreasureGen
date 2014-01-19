using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level20ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level20Items";
        }

        [Test]
        public void Level20ItemsEmptyPercentile()
        {
            AssertEmpty(1, 25);
        }

        [Test]
        public void Level20ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Power.Medium);
            AssertContent(content, 26, 65);
        }

        [Test]
        public void Level20ItemsMajorPercentile()
        {
            var content = String.Format("{0},1d3", ItemsConstants.Power.Major);
            AssertContent(content, 66, 100);
        }
    }
}