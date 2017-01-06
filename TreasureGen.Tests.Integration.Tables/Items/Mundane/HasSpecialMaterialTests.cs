using NUnit.Framework;
using System;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class HasSpecialMaterialTests : BooleanPercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.HasSpecialMaterial; }
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

        [TestCase(false, 1, 95)]
        [TestCase(true, 96, 100)]
        public override void BooleanPercentile(Boolean isTrue, int lower, int upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}