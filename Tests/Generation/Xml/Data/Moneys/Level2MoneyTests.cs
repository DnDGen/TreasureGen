using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;
using System;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level2MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level2Money";
        }

        [Test]
        public void Level2EmptyPercentile()
        {
            AssertEmpty(1, 13);
        }

        [Test]
        public void Level2CopperPercentile()
        {
            var result = String.Format("{0},1d10*1000", MoneyConstants.Copper);
            AssertContent(result, 14, 23);
        }

        [Test]
        public void Level2SilverPercentile()
        {
            var result = String.Format("{0},2d10*100", MoneyConstants.Silver);
            AssertContent(result, 24, 43);
        }

        [Test]
        public void Level2GoldPercentile()
        {
            var result = String.Format("{0},4d10*10", MoneyConstants.Gold);
            AssertContent(result, 44, 95);
        }

        [Test]
        public void Level2PlatinumPercentile()
        {
            var result = String.Format("{0},2d8*10", MoneyConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}