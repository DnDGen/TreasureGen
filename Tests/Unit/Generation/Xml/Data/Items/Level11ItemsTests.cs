using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level11ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level11Items";
        }

        [Test]
        public void Level11ItemsEmptyPercentile()
        {
            AssertEmpty(1, 31);
        }

        [Test]
        public void Level11ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Minor);
            AssertContent(content, 32, 84);
        }

        [Test]
        public void Level11ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Medium);
            AssertContent(content, 85, 98);
        }

        [Test]
        public void Level11ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Major);
            AssertContent(content, 99, 100);
        }
    }
}