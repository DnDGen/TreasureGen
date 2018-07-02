using NUnit.Framework;
using TreasureGen.Tables;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class FullAlignmentsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.FullAlignments; }
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

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void ChaoticGoodPercentile()
        {
            base.Percentile(AlignmentConstants.ChaoticGood, 1, 11);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void ChaoticNeutralPercentile()
        {
            base.Percentile(AlignmentConstants.ChaoticNeutral, 12, 22);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void ChaoticEvilPercentile()
        {
            base.Percentile(AlignmentConstants.ChaoticEvil, 23, 33);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void NeutralEvilPercentile()
        {
            base.Percentile(AlignmentConstants.NeutralEvil, 34, 44);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulEvilPercentile()
        {
            base.Percentile(AlignmentConstants.LawfulEvil, 45, 55);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulGoodPercentile()
        {
            base.Percentile(AlignmentConstants.LawfulGood, 56, 67);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulNeutralPercentile()
        {
            base.Percentile(AlignmentConstants.LawfulNeutral, 68, 78);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void NeutralGoodPercentile()
        {
            base.Percentile(AlignmentConstants.NeutralGood, 79, 89);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void TrueNeutralPercentile()
        {
            base.Percentile(AlignmentConstants.TrueNeutral, 90, 100);
        }
    }
}