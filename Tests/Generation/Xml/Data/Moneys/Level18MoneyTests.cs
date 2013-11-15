using System;
using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Moneys
{
    [TestFixture]
    public class Level18MoneyTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level18Money";
        }

        [Test]
        public void Level18EmptyPercentile()
        {
            AssertEmpty(1, 2);
        }

        [Test]
        public void Level18GoldPercentile()
        {
            var result = String.Format("{0},3d6*1000", MoneyConstants.Gold);
            AssertContent(result, 3, 65);
        }

        [Test]
        public void Level18PlatinumPercentile()
        {
            var result = String.Format("{0},5d4*100", MoneyConstants.Platinum);
            AssertContent(result, 66, 100);
        }
    }
}