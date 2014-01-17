using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level3ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level3Items";
        }

        [Test]
        public void Level3ItemsEmptyPercentile()
        {
            AssertEmpty(1, 49);
        }

        [Test]
        public void Level3ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d3", ItemsConstants.Mundane);
            AssertContent(content, 50, 79);
        }

        [Test]
        public void Level3ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Minor);
            AssertContent(content, 80, 100);
        }
    }
}