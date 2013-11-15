using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level17MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level17Money";
        }

        [Test]
        public void Level17EmptyPercentile()
        {
            AssertEmpty(1, 3);
        }

        [Test]
        public void Level17GoldPercentile()
        {
            var result = String.Format("{0},3d4*1000", MoneyConstants.Gold);
            AssertContent(result, 4, 68);
        }

        [Test]
        public void Level17PlatinumPercentile()
        {
            var result = String.Format("{0},2d10*100", MoneyConstants.Platinum);
            AssertContent(result, 69, 100);
        }
    }
}