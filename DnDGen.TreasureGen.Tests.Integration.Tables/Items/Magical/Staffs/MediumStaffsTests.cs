﻿using NUnit.Framework;
using DnDGen.TreasureGen.Tables;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Magical.Staves
{
    [TestFixture]
    public class MediumStaffsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Staff); }
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

        [TestCase(1, 15, StaffConstants.Charming, 0)]
        [TestCase(16, 30, StaffConstants.Fire, 0)]
        [TestCase(31, 40, StaffConstants.SwarmingInsects, 0)]
        [TestCase(41, 60, StaffConstants.Healing, 0)]
        [TestCase(61, 75, StaffConstants.SizeAlteration, 0)]
        [TestCase(76, 90, StaffConstants.Illumination, 0)]
        [TestCase(91, 95, StaffConstants.Frost, 0)]
        [TestCase(96, 100, StaffConstants.Defense, 0)]
        public void TypeAndAmountPercentile(int lower, int upper, string type, int amount)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}