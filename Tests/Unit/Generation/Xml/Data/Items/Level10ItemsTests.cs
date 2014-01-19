using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level10ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level10Items";
        }

        [Test]
        public void Level10ItemsEmptyPercentile()
        {
            AssertEmpty(1, 40);
        }

        [Test]
        public void Level10ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Power.Minor);
            AssertContent(content, 41, 88);
        }

        [Test]
        public void Level10ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Medium);
            AssertContent(content, 89, 99);
        }

        [Test]
        public void Level10ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Major);
            AssertContent(content, 100);
        }
    }
}