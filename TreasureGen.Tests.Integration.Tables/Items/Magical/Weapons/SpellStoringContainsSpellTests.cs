using NUnit.Framework;
using System;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Weapons
{
    [TestFixture]
    public class SpellStoringContainsSpellTests : BooleanPercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.SpellStoringContainsSpell; }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(true, 1, 50)]
        [TestCase(false, 51, 100)]
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