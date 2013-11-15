using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level4MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level4Money";
        }

        [Test]
        public void Level4EmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level4CopperPercentile()
        {
            var result = String.Format("{0},3d10*1000", MoneyConstants.Copper);
            AssertContent(result, 12, 21);
        }

        [Test]
        public void Level4SilverPercentile()
        {
            var result = String.Format("{0},4d12*1000", MoneyConstants.Silver);
            AssertContent(result, 22, 41);
        }

        [Test]
        public void Level4GoldPercentile()
        {
            var result = String.Format("{0},1d6*100", MoneyConstants.Gold);
            AssertContent(result, 42, 95);
        }

        [Test]
        public void Level4PlatinumPercentile()
        {
            var result = String.Format("{0},1d8*10", MoneyConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}