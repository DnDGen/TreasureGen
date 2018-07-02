using NUnit.Framework;
using System;
using TreasureGen.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IsRingIntelligentTests : BooleanPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, ItemTypeConstants.Ring); }
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

        [TestCase(false, 2, 100)]
        public override void BooleanPercentile(Boolean isTrue, int lower, int upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }

        [TestCase(true, 1)]
        public override void BooleanPercentile(Boolean isTrue, int roll)
        {
            base.BooleanPercentile(isTrue, roll);
        }
    }
}