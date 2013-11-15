using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level11MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level11Money";
        }

        [Test]
        public void Level11EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level11SilverPercentile()
        {
            var result = String.Format("{0},3d10*1000", MoneyConstants.Silver);
            AssertContent(result, 9, 14);
        }

        [Test]
        public void Level11GoldPercentile()
        {
            var result = String.Format("{0},4d8*100", MoneyConstants.Gold);
            AssertContent(result, 15, 75);
        }

        [Test]
        public void Level11PlatinumPercentile()
        {
            var result = String.Format("{0},4d10*10", MoneyConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}