using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons.Medium
{
    [TestFixture]
    public class MediumRangedWeaponSpecialAbilitiesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MediumRangedWeaponSpecialAbilities";
        }

        [TestCase(SpecialAbilityConstants.Bane, 1, 8)]
        [TestCase(SpecialAbilityConstants.Distance, 9, 16)]
        [TestCase(SpecialAbilityConstants.Flaming, 17, 28)]
        [TestCase(SpecialAbilityConstants.Frost, 29, 40)]
        [TestCase(SpecialAbilityConstants.Merciful, 41, 42)]
        [TestCase(SpecialAbilityConstants.Returning, 43, 47)]
        [TestCase(SpecialAbilityConstants.Shock, 48, 59)]
        [TestCase(SpecialAbilityConstants.Seeking, 60, 64)]
        [TestCase(SpecialAbilityConstants.Thundering, 65, 68)]
        [TestCase(SpecialAbilityConstants.Anarchic, 69, 71)]
        [TestCase(SpecialAbilityConstants.Axiomatic, 72, 74)]
        [TestCase(SpecialAbilityConstants.FlamingBurst, 75, 79)]
        [TestCase(SpecialAbilityConstants.Holy, 80, 82)]
        [TestCase(SpecialAbilityConstants.IcyBurst, 83, 87)]
        [TestCase(SpecialAbilityConstants.ShockingBurst, 88, 92)]
        [TestCase(SpecialAbilityConstants.Unholy, 93, 95)]
        [TestCase("BonusSpecialAbility", 96, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}