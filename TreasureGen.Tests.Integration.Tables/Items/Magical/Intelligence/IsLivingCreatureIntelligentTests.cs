using NUnit.Framework;
using System;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IsLivingCreatureIntelligentTests : BooleanPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, ItemTypeConstants.LivingCreature); }
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

        [TestCase(false, 1, 100)]
        public override void BooleanPercentile(Boolean isTrue, int lower, int upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}