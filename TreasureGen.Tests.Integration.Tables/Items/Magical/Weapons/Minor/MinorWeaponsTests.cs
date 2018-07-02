using NUnit.Framework;
using System;
using TreasureGen.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Weapons.Minor
{
    [TestFixture]
    public class MinorWeaponsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.Weapon); }
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

        [TestCase(ItemTypeConstants.Weapon, 86, 90)]
        [TestCase("SpecialAbility", 91, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(1, 1, 70)]
        [TestCase(2, 71, 85)]
        public void Percentile(int bonus, int lower, int upper)
        {
            var content = Convert.ToString(bonus);
            Percentile(content, lower, upper);
        }
    }
}