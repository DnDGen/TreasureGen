using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Tables;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumArmorsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Armor); }
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

        [TestCase("1", 1, 1, 10)]
        [TestCase("2", 2, 11, 20)]
        [TestCase("3", 3, 31, 50)]
        [TestCase("4", 51, 57)]
        [TestCase(ItemTypeConstants.Armor, 0, 58, 63)]
        [TestCase("SpecialAbility", 1, 64, 100)]
        public override void Percentile(string value, int lower, int upper)
        {
            base.Percentile(value, lower, upper);
        }
    }
}