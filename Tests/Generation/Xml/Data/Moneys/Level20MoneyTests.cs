using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level20MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level20Money";
        }

        [Test]
        public void Level20EmptyPercentile()
        {
            AssertEmpty(1, 2);
        }

        [Test]
        public void Level20GoldPercentile()
        {
            var result = String.Format("{0},4d8*1000", MoneyConstants.Gold);
            AssertContent(result, 3, 65);
        }

        [Test]
        public void Level20PlatinumPercentile()
        {
            var result = String.Format("{0},4d10*100", MoneyConstants.Platinum);
            AssertContent(result, 66, 100);
        }
    }
}