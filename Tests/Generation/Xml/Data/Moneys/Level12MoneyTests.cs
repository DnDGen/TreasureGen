using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level12MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level12Money";
        }

        [Test]
        public void Level12EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level12SilverPercentile()
        {
            var result = String.Format("{0},3d12*1000", MoneyConstants.Silver);
            AssertContent(result, 9, 14);
        }

        [Test]
        public void Level12GoldPercentile()
        {
            var result = String.Format("{0},1d4*1000", MoneyConstants.Gold);
            AssertContent(result, 15, 75);
        }

        [Test]
        public void Level12PlatinumPercentile()
        {
            var result = String.Format("{0},1d4*100", MoneyConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}