using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level8ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level8Items";
        }

        [Test]
        public void Level8ItemsEmptyPercentile()
        {
            AssertEmpty(1, 48);
        }

        [Test]
        public void Level8ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Minor);
            AssertContent(content, 49, 96);
        }

        [Test]
        public void Level8ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Medium);
            AssertContent(content, 97, 100);
        }
    }
}