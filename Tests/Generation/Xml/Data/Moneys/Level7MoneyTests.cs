using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level7MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level7Money";
        }

        [Test]
        public void Level7EmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level7CopperPercentile()
        {
            var result = String.Format("{0},1d10*10000", MoneyConstants.Copper);
            AssertContent(result, 12, 18);
        }

        [Test]
        public void Level7SilverPercentile()
        {
            var result = String.Format("{0},1d12*1000", MoneyConstants.Silver);
            AssertContent(result, 19, 35);
        }

        [Test]
        public void Level7GoldPercentile()
        {
            var result = String.Format("{0},2d6*100", MoneyConstants.Gold);
            AssertContent(result, 36, 93);
        }

        [Test]
        public void Level7PlatinumPercentile()
        {
            var result = String.Format("{0},3d4*10", MoneyConstants.Platinum);
            AssertContent(result, 94, 100);
        }
    }
}