using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons.Major
{
    [TestFixture, PercentileTable("MajorMeleeWeaponSpecialAbilities")]
    public class MajorMeleeWeaponSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void BanePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Bane, 1, 3);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Flaming, 4, 6);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Frost, 7, 9);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Shock, 10, 12);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GhostTouchWeapon, 13, 15);
        }

        [Test]
        public void KiFocusPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.KiFocus, 16, 19);
        }

        [Test]
        public void MightyCleavingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.MightyCleaving, 20, 21);
        }

        [Test]
        public void SpellStoringPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellStoring, 22, 24);
        }

        [Test]
        public void ThrowingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Throwing, 25, 28);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Thundering, 29, 32);
        }

        [Test]
        public void ViciousPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Vicious, 33, 36);
        }

        [Test]
        public void AnarchicPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Anarchic, 37, 41);
        }

        [Test]
        public void AxiomaticPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Axiomatic, 42, 46);
        }

        [Test]
        public void DisruptionPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Disruption, 47, 49);
        }

        [Test]
        public void FlamingBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.FlamingBurst, 50, 54);
        }

        [Test]
        public void IcyBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.IcyBurst, 55, 59);
        }

        [Test]
        public void HolyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Holy, 60, 64);
        }

        [Test]
        public void ShockingBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ShockingBurst, 65, 69);
        }

        [Test]
        public void UnholyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Unholy, 70, 74);
        }

        [Test]
        public void WoundingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Wounding, 75, 78);
        }

        [Test]
        public void SpeedPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Speed, 79, 83);
        }

        [Test]
        public void BrilliantEnergyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.BrilliantEnergy, 84, 86);
        }

        [Test]
        public void DancingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Dancing, 87, 88);
        }

        [Test]
        public void VorpalPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Vorpal, 89, 90);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 91, 100);
        }
    }
}