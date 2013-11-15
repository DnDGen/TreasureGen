using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level10MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level10Money";
        }

        [Test]
        public void Level10EmptyPercentile()
        {
            AssertEmpty(1, 10);
        }

        [Test]
        public void Level10SilverPercentile()
        {
            var result = String.Format("{0},2d10*1000", MoneyConstants.Silver);
            AssertContent(result, 11, 24);
        }

        [Test]
        public void Level10GoldPercentile()
        {
            var result = String.Format("{0},6d4*100", MoneyConstants.Gold);
            AssertContent(result, 25, 79);
        }

        [Test]
        public void Level10PlatinumPercentile()
        {
            var result = String.Format("{0},5d6*10", MoneyConstants.Platinum);
            AssertContent(result, 80, 100);
        }
    }
}