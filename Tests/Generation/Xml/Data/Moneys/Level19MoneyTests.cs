using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level19MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level19Money";
        }

        [Test]
        public void Level19EmptyPercentile()
        {
            AssertEmpty(1, 2);
        }

        [Test]
        public void Level19GoldPercentile()
        {
            var result = String.Format("{0},3d8*1000", MoneyConstants.Gold);
            AssertContent(result, 3, 65);
        }

        [Test]
        public void Level19PlatinumPercentile()
        {
            var result = String.Format("{0},3d10*100", MoneyConstants.Platinum);
            AssertContent(result, 66, 100);
        }
    }
}