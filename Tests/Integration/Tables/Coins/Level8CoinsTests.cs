using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level8CoinsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level8Coins"; }
        }

        [TestCase(EmptyContent, 1, 10)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "1d12*10000", 11, 15)]
        [TestCase(CoinConstants.Silver, "2d6*1000", 16, 29)]
        [TestCase(CoinConstants.Gold, "2d8*100", 30, 87)]
        [TestCase(CoinConstants.Platinum, "3d6*10", 88, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}