using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level9MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level9Money";
        }

        [Test]
        public void Level9EmptyPercentile()
        {
            AssertEmpty(1, 10);
        }

        [Test]
        public void Level9CopperPercentile()
        {
            var result = String.Format("{0},2d6*10000", MoneyConstants.Copper);
            AssertContent(result, 11, 15);
        }

        [Test]
        public void Level9SilverPercentile()
        {
            var result = String.Format("{0},2d8*1000", MoneyConstants.Silver);
            AssertContent(result, 16, 29);
        }

        [Test]
        public void Level9GoldPercentile()
        {
            var result = String.Format("{0},5d4*100", MoneyConstants.Gold);
            AssertContent(result, 30, 85);
        }

        [Test]
        public void Level9PlatinumPercentile()
        {
            var result = String.Format("{0},2d12*10", MoneyConstants.Platinum);
            AssertContent(result, 86, 100);
        }
    }
}