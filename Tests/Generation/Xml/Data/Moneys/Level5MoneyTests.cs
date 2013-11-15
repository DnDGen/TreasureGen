using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level5MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level5Money";
        }

        [Test]
        public void Level5EmptyPercentile()
        {
            AssertEmpty(1, 10);
        }

        [Test]
        public void Level5CopperPercentile()
        {
            var result = String.Format("{0},1d4*10000", MoneyConstants.Copper);
            AssertContent(result, 11, 19);
        }

        [Test]
        public void Level5SilverPercentile()
        {
            var result = String.Format("{0},1d6*1000", MoneyConstants.Silver);
            AssertContent(result, 20, 38);
        }

        [Test]
        public void Level5GoldPercentile()
        {
            var result = String.Format("{0},1d8*100", MoneyConstants.Gold);
            AssertContent(result, 39, 95);
        }

        [Test]
        public void Level5PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*10", MoneyConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}