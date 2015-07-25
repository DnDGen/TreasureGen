using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceAlignmentsTests : PercentileTests
    {
        protected override String tableName
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
            base.Percentile(IntelligenceAlignmentConstants.ChaoticGood, 1, 5);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void ChaoticNeutralPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.ChaoticNeutral, 6, 15);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void ChaoticEvilPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.ChaoticEvil, 16, 20);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void NeutralEvilPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.NeutralEvil, 21, 25);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulEvilPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.LawfulEvil, 26, 30);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulGoodPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.LawfulGood, 31, 55);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void LawfulNeutralPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.LawfulNeutral, 56, 60);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void NeutralGoodPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.NeutralGood, 61, 80);
        }

        //INFO: Doing this because the full alignment constants are static properties, not constants
        [Test]
        public void TrueNeutralPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.TrueNeutral, 81, 100);
        }
    }
}