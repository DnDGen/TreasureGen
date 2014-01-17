using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level9ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level9Items";
        }

        [Test]
        public void Level9ItemsEmptyPercentile()
        {
            AssertEmpty(1, 43);
        }

        [Test]
        public void Level9ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Minor);
            AssertContent(content, 44, 91);
        }

        [Test]
        public void Level9ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Medium);
            AssertContent(content, 92, 100);
        }
    }
}