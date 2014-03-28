using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons.Minor
{
    [TestFixture, PercentileTable("MinorMeleeWeaponSpecialAbilities")]
    public class MinorMeleeWeaponSpecialAbilitiesTests : PercentileTests
    {
        [TestCase(SpecialAbilityConstants.Bane, 1, 10)]
        [TestCase(SpecialAbilityConstants.Defending, 11, 17)]
        [TestCase(SpecialAbilityConstants.Flaming, 18, 27)]
        [TestCase(SpecialAbilityConstants.Frost, 28, 37)]
        [TestCase(SpecialAbilityConstants.Shock, 38, 47)]
        [TestCase(SpecialAbilityConstants.GhostTouchWeapon, 48, 56)]
        [TestCase(SpecialAbilityConstants.Keen, 57, 67)]
        [TestCase(SpecialAbilityConstants.KiFocus, 68, 71)]
        [TestCase(SpecialAbilityConstants.Merciful, 72, 75)]
        [TestCase(SpecialAbilityConstants.MightyCleaving, 76, 82)]
        [TestCase(SpecialAbilityConstants.SpellStoring, 83, 87)]
        [TestCase(SpecialAbilityConstants.Throwing, 88, 91)]
        [TestCase(SpecialAbilityConstants.Thundering, 92, 95)]
        [TestCase(SpecialAbilityConstants.Vicious, 96, 99)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("BonusSpecialAbility", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}