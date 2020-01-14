using NUnit.Framework;
using DnDGen.TreasureGen.Tables;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class KnowledgeCategoriesTests : PercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.KnowledgeCategories; }
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

        [TestCase("Arcana", 1, 10)]
        [TestCase("Architecture", 11, 20)]
        [TestCase("Dungeoneering", 21, 30)]
        [TestCase("Geography", 31, 40)]
        [TestCase("History", 41, 50)]
        [TestCase("Local", 51, 60)]
        [TestCase("Nature", 61, 70)]
        [TestCase("Nobility", 71, 80)]
        [TestCase("Religion", 81, 90)]
        [TestCase("The planes", 91, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}