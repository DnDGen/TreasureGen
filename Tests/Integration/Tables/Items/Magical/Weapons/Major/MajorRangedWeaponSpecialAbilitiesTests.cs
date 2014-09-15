using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons.Major
{
    [TestFixture]
    public class MajorRangedWeaponSpecialAbilitiesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MajorRangedWeaponSpecialAbilities"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(SpecialAbilityConstants.Bane, 1, 4)]
        [TestCase(SpecialAbilityConstants.Distance, 5, 8)]
        [TestCase(SpecialAbilityConstants.Flaming, 9, 12)]
        [TestCase(SpecialAbilityConstants.Frost, 13, 16)]
        [TestCase(SpecialAbilityConstants.Returning, 17, 21)]
        [TestCase(SpecialAbilityConstants.Shock, 22, 25)]
        [TestCase(SpecialAbilityConstants.Seeking, 26, 27)]
        [TestCase(SpecialAbilityConstants.Thundering, 28, 29)]
        [TestCase(SpecialAbilityConstants.Anarchic, 30, 34)]
        [TestCase(SpecialAbilityConstants.Axiomatic, 35, 39)]
        [TestCase(SpecialAbilityConstants.FlamingBurst, 40, 49)]
        [TestCase(SpecialAbilityConstants.Holy, 50, 54)]
        [TestCase(SpecialAbilityConstants.IcyBurst, 55, 64)]
        [TestCase(SpecialAbilityConstants.ShockingBurst, 65, 74)]
        [TestCase(SpecialAbilityConstants.Unholy, 75, 79)]
        [TestCase(SpecialAbilityConstants.Speed, 80, 84)]
        [TestCase(SpecialAbilityConstants.BrilliantEnergy, 85, 90)]
        [TestCase("BonusSpecialAbility", 91, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}