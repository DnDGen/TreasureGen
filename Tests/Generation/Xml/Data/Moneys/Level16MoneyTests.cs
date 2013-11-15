using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level16MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level16Money";
        }

        [Test]
        public void Level16EmptyPercentile()
        {
            AssertEmpty(1, 3);
        }

        [Test]
        public void Level16GoldPercentile()
        {
            var result = String.Format("{0},1d12*1000", MoneyConstants.Gold);
            AssertContent(result, 4, 74);
        }

        [Test]
        public void Level16PlatinumPercentile()
        {
            var result = String.Format("{0},3d4*100", MoneyConstants.Platinum);
            AssertContent(result, 75, 100);
        }
    }
}