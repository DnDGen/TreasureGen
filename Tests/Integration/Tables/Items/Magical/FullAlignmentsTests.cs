using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class FullAlignmentsTests : PercentileTests
    {
        protected override String tableName
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
            base.Percentile(IntelligenceAlignmentConstants.ChaoticGood, 1, 11);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void ChaoticNeutralPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.ChaoticNeutral, 12, 22);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void ChaoticEvilPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.ChaoticEvil, 23, 33);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void NeutralEvilPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.NeutralEvil, 34, 44);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulEvilPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.LawfulEvil, 45, 55);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulGoodPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.LawfulGood, 56, 67);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulNeutralPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.LawfulNeutral, 68, 78);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void NeutralGoodPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.NeutralGood, 79, 89);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void TrueNeutralPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.TrueNeutral, 90, 100);
        }
    }
}