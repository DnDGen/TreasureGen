using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level13MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level13Money";
        }

        [Test]
        public void Level13EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level13GoldPercentile()
        {
            var result = String.Format("{0},1d4*1000", MoneyConstants.Gold);
            AssertContent(result, 9, 75);
        }

        [Test]
        public void Level13PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*100", MoneyConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}