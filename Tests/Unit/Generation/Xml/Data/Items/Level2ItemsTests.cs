using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level2ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level2Items";
        }

        [Test]
        public void Level2ItemsEmptyPercentile()
        {
            AssertEmpty(1, 49);
        }

        [Test]
        public void Level2ItemsMundanePercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Mundane);
            AssertContent(content, 50, 85);
        }

        [Test]
        public void Level2ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Minor);
            AssertContent(content, 86, 100);
        }
    }
}