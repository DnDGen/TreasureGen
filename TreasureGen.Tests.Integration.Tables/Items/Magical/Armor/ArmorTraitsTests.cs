using NUnit.Framework;
using TreasureGen.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor
{
    [TestFixture]
    public class ArmorTraitsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, ItemTypeConstants.Armor); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(TraitConstants.Markings, 1, 30)]
        [TestCase(EmptyContent, 31, 100)]
        public override void Percentile(string content, int lower, int upper)
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