using NUnit.Framework;
using TreasureGen.Tables;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class AlignmentsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.IntelligenceAlignments; }
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
            base.Percentile(AlignmentConstants.ChaoticGood, 1, 5);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void ChaoticNeutralPercentile()
        {
            base.Percentile(AlignmentConstants.ChaoticNeutral, 6, 15);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void ChaoticEvilPercentile()
        {
            base.Percentile(AlignmentConstants.ChaoticEvil, 16, 20);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void NeutralEvilPercentile()
        {
            base.Percentile(AlignmentConstants.NeutralEvil, 21, 25);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulEvilPercentile()
        {
            base.Percentile(AlignmentConstants.LawfulEvil, 26, 30);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulGoodPercentile()
        {
            base.Percentile(AlignmentConstants.LawfulGood, 31, 55);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulNeutralPercentile()
        {
            base.Percentile(AlignmentConstants.LawfulNeutral, 56, 60);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void NeutralGoodPercentile()
        {
            base.Percentile(AlignmentConstants.NeutralGood, 61, 80);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void TrueNeutralPercentile()
        {
            base.Percentile(AlignmentConstants.TrueNeutral, 81, 100);
        }
    }
}