using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons.Medium
{
    [TestFixture]
    public class MediumMeleeWeaponSpecialAbilitiesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MediumMeleeWeaponSpecialAbilities";
        }

        [Test]
        public void BanePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Bane, 1, 6);
        }

        [Test]
        public void DefendingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Defending, 7, 12);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Flaming, 13, 19);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Frost, 20, 26);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Shock, 27, 33);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GhostTouchWeapon, 34, 38);
        }

        [Test]
        public void KeenPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Keen, 39, 44);
        }

        [Test]
        public void KiFocusPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.KiFocus, 45, 48);
        }

        [Test]
        public void MercifulPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Merciful, 49, 50);
        }

        [Test]
        public void MightyCleavingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.MightyCleaving, 51, 54);
        }

        [Test]
        public void SpellStoringPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellStoring, 55, 59);
        }

        [Test]
        public void ThrowingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Throwing, 60, 63);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Thundering, 64, 65);
        }

        [Test]
        public void ViciousPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Vicious, 66, 69);
        }

        [Test]
        public void AnarchicPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Anarchic, 70, 72);
        }

        [Test]
        public void AxiomaticPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Axiomatic, 73, 75);
        }

        [Test]
        public void DisruptionPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Disruption, 76, 78);
        }

        [Test]
        public void FlamingBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.FlamingBurst, 79, 81);
        }

        [Test]
        public void IcyBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.IcyBurst, 82, 84);
        }

        [Test]
        public void HolyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Holy, 85, 87);
        }

        [Test]
        public void ShockingBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ShockingBurst, 88, 90);
        }

        [Test]
        public void UnholyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Unholy, 91, 93);
        }

        [Test]
        public void WoundingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Wounding, 94, 95);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 96, 100);
        }
    }
}