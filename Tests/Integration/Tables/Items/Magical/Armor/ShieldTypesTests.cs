using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class ShieldTypesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, AttributeConstants.Shield); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(ArmorConstants.Buckler, 1, 10)]
        [TestCase(ArmorConstants.LightWoodenShield, 11, 15)]
        [TestCase(ArmorConstants.LightSteelShield, 16, 20)]
        [TestCase(ArmorConstants.HeavyWoodenShield, 21, 30)]
        [TestCase(ArmorConstants.HeavySteelShield, 31, 95)]
        [TestCase(ArmorConstants.TowerShield, 96, 100)]
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