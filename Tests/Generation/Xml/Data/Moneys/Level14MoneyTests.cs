using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level14MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level14Money";
        }

        [Test]
        public void Level14EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level14GoldPercentile()
        {
            var result = String.Format("{0},1d6*1000", MoneyConstants.Gold);
            AssertContent(result, 9, 75);
        }

        [Test]
        public void Level14PlatinumPercentile()
        {
            var result = String.Format("{0},1d12*100", MoneyConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}