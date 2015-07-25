using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IsMeleeIntelligentTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, AttributeConstants.Melee); }
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

        [TestCase(true, 1, 15)]
        [TestCase(false, 16, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}