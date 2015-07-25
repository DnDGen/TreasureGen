using System;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Rods
{
    [TestFixture]
    public class RodOfAbsorptionContainsSpellLevelsTests : BooleanPercentileTests
    {
        protected override String tableName
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
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
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