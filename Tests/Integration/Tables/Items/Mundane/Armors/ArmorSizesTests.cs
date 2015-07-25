using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane.Armors
{
    [TestFixture]
    public class ArmorSizesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Percentiles.Set.ArmorSizes; }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(TraitConstants.Small, 1, 10)]
        [TestCase(TraitConstants.Medium, 11, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}