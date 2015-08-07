using NUnit.Framework;
using System;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class IsMasterworkTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Percentiles.Set.IsMasterwork; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(false, 1, 90)]
        [TestCase(true, 91, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}
