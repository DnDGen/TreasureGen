using NUnit.Framework;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class ElementsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.Elements; }
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

        [TestCase("Acid", 1, 20)]
        [TestCase("Cold", 21, 40)]
        [TestCase("Electricity", 41, 60)]
        [TestCase("Fire", 61, 80)]
        [TestCase("Sonic", 81, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}