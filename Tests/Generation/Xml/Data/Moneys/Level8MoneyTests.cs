using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level8MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level8Money";
        }

        [Test]
        public void Level8EmptyPercentile()
        {
            AssertEmpty(1, 10);
        }

        [Test]
        public void Level8CopperPercentile()
        {
            var result = String.Format("{0},1d12*10000", MoneyConstants.Copper);
            AssertContent(result, 11, 15);
        }

        [Test]
        public void Level8SilverPercentile()
        {
            var result = String.Format("{0},2d6*1000", MoneyConstants.Silver);
            AssertContent(result, 16, 29);
        }

        [Test]
        public void Level8GoldPercentile()
        {
            var result = String.Format("{0},2d8*100", MoneyConstants.Gold);
            AssertContent(result, 30, 87);
        }

        [Test]
        public void Level8PlatinumPercentile()
        {
            var result = String.Format("{0},3d6*10", MoneyConstants.Platinum);
            AssertContent(result, 88, 100);
        }
    }
}