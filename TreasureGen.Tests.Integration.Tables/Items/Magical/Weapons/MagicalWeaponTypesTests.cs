using NUnit.Framework;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Weapons
{
    [TestFixture]
    public class MagicalWeaponTypesTests : PercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.MagicalWeaponTypes; }
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

        [TestCase("CommonMelee", 1, 70)]
        [TestCase("Uncommon", 71, 80)]
        [TestCase("CommonRanged", 81, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}