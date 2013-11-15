using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;
using System;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level3MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level3Money";
        }

        [Test]
        public void Level3EmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level3CopperPercentile()
        {
            var result = String.Format("{0},2d10*1000", MoneyConstants.Copper);
            AssertContent(result, 12, 21);
        }

        [Test]
        public void Level3SilverPercentile()
        {
            var result = String.Format("{0},4d8*100", MoneyConstants.Silver);
            AssertContent(result, 22, 41);
        }

        [Test]
        public void Level3GoldPercentile()
        {
            var result = String.Format("{0},1d4*100", MoneyConstants.Gold);
            AssertContent(result, 42, 95);
        }

        [Test]
        public void Level3PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*10", MoneyConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}