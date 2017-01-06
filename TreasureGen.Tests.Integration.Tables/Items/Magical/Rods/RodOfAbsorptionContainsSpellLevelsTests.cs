using NUnit.Framework;
using System;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Rods
{
    [TestFixture]
    public class RodOfAbsorptionContainsSpellLevelsTests : BooleanPercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.RodOfAbsorptionContainsSpellLevels; }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(false, 1, 70)]
        [TestCase(true, 71, 100)]
        public override void BooleanPercentile(Boolean isTrue, int lower, int upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}