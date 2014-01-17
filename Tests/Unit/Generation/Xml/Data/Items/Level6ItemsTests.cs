using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level6ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level6Items";
        }

        [Test]
        public void Level6ItemsEmptyPercentile()
        {
            AssertEmpty(1, 54);
        }

        [Test]
        public void Level6ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Mundane);
            AssertContent(content, 55, 59);
        }

        [Test]
        public void Level6ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d3", ItemsConstants.Minor);
            AssertContent(content, 60, 99);
        }

        [Test]
        public void Level6ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Medium);
            AssertContent(content, 100);
        }
    }
}