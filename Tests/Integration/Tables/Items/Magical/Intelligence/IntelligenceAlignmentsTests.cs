using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceAlignmentsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Percentiles.Set.IntelligenceAlignments; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [Test]
        public void ChaoticGoodPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.ChaoticGood, 1, 5);
        }

        [Test]
        public void ChaoticNeutralPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.ChaoticNeutral, 6, 15);
        }

        [Test]
        public void ChaoticEvilPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.ChaoticGood, 16, 20);
        }

        [Test]
        public void NeutralEvilPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.NeutralEvil, 21, 25);
        }

        [Test]
        public void LawfulEvilPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.LawfulEvil, 26, 30);
        }

        [Test]
        public void LawfulGoodPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.LawfulGood, 31, 55);
        }

        [Test]
        public void LawfulNeutralPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.LawfulNeutral, 56, 60);
        }

        [Test]
        public void NeutralGoodPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.NeutralGood, 61, 80);
        }

        [Test]
        public void TrueNeutralPercentile()
        {
            base.Percentile(IntelligenceAlignmentConstants.TrueNeutral, 81, 100);
        }
    }
}