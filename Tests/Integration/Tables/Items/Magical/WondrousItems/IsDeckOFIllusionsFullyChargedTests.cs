using System;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class IsDeckOFIllusionsFullyChargedTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Percentiles.Set.IsDeckOfIllusionsFullyCharged; }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(true, 1, 90)]
        [TestCase(false, 91, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}