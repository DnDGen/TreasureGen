using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level16CoinsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level16Coins"; }
        }

        [TestCase(EmptyContent, 1, 3)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Gold, "1d12*1000", 4, 74)]
        [TestCase(CoinConstants.Platinum, "3d4*100", 75, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}