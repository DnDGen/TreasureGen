using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level5ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level5Items";
        }

        [Test]
        public void Level5ItemsEmptyPercentile()
        {
            AssertEmpty(1, 57);
        }

        [Test]
        public void Level5ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d4", ItemsConstants.Power.Mundane);
            AssertContent(content, 58, 67);
        }

        [Test]
        public void Level5ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d3", ItemsConstants.Power.Minor);
            AssertContent(content, 68, 100);
        }
    }
}