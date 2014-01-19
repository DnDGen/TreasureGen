using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level1ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level1Items";
        }

        [Test]
        public void Level1ItemsEmptyPercentile()
        {
            AssertEmpty(1, 71);
        }

        [Test]
        public void Level1ItemsMundanePercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Mundane);
            AssertContent(content, 72, 95);
        }

        [Test]
        public void Level1ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Minor);
            AssertContent(content, 96, 100);
        }
    }
}