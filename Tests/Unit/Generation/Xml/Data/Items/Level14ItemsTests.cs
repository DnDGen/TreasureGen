using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level14ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level14Items";
        }

        [Test]
        public void Level14ItemsEmptyPercentile()
        {
            AssertEmpty(1, 19);
        }

        [Test]
        public void Level14ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d6", ItemsConstants.Minor);
            AssertContent(content, 20, 58);
        }

        [Test]
        public void Level14ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Medium);
            AssertContent(content, 59, 92);
        }

        [Test]
        public void Level14ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Major);
            AssertContent(content, 93, 100);
        }
    }
}