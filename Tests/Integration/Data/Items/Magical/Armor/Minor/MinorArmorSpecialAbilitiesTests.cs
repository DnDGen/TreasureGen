using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Minor
{
    [TestFixture]
    public class MinorArmorSpecialAbilitiesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MinorArmorSpecialAbilities";
        }

        [TestCase(SpecialAbilityConstants.Glamered, 1, 25)]
        [TestCase(SpecialAbilityConstants.LightFortification, 26, 32)]
        [TestCase(SpecialAbilityConstants.Slick, 33, 52)]
        [TestCase(SpecialAbilityConstants.Shadow, 53, 72)]
        [TestCase(SpecialAbilityConstants.SilentMoves, 73, 92)]
        [TestCase(SpecialAbilityConstants.SpellResistance13, 93, 96)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(SpecialAbilityConstants.ImprovedSlick, 97)]
        [TestCase(SpecialAbilityConstants.ImprovedShadow, 98)]
        [TestCase(SpecialAbilityConstants.ImprovedSilentMoves, 99)]
        [TestCase("BonusSpecialAbility", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}