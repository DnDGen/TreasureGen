using NUnit.Framework;
using System;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Weapons.Medium
{
    [TestFixture]
    public class MediumWeaponsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Weapon); }
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

        [TestCase(ItemTypeConstants.Weapon, 63, 68)]
        [TestCase("SpecialAbility", 69, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(1, 1, 10)]
        [TestCase(2, 11, 29)]
        [TestCase(3, 30, 58)]
        [TestCase(4, 59, 62)]
        public void Percentile(int bonus, int lower, int upper)
        {
            var content = Convert.ToString(bonus);
            Percentile(content, lower, upper);
        }
    }
}