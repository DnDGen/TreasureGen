using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Weapons.Medium
{
    [TestFixture, PercentileTable("MediumMeleeWeaponSpecialAbilities")]
    public class MediumMeleeWeaponSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void BanePercentile()
        {
            AssertContent(SpecialAbilityConstants.Bane, 1, 6);
        }

        [Test]
        public void DefendingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Defending, 7, 12);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Flaming, 13, 19);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertContent(SpecialAbilityConstants.Frost, 20, 26);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertContent(SpecialAbilityConstants.Shock, 27, 33);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertContent(SpecialAbilityConstants.GhostTouchWeapon, 34, 38);
        }

        [Test]
        public void KeenPercentile()
        {
            AssertContent(SpecialAbilityConstants.Keen, 39, 44);
        }

        [Test]
        public void KiFocusPercentile()
        {
            AssertContent(SpecialAbilityConstants.KiFocus, 45, 48);
        }

        [Test]
        public void MercifulPercentile()
        {
            AssertContent(SpecialAbilityConstants.Merciful, 49, 50);
        }

        [Test]
        public void MightyCleavingPercentile()
        {
            AssertContent(SpecialAbilityConstants.MightyCleaving, 51, 54);
        }

        [Test]
        public void SpellStoringPercentile()
        {
            AssertContent(SpecialAbilityConstants.SpellStoring, 55, 59);
        }

        [Test]
        public void ThrowingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Throwing, 60, 63);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Thundering, 64, 65);
        }

        [Test]
        public void ViciousPercentile()
        {
            AssertContent(SpecialAbilityConstants.Vicious, 66, 69);
        }

        [Test]
        public void AnarchicPercentile()
        {
            AssertContent(SpecialAbilityConstants.Anarchic, 70, 72);
        }

        [Test]
        public void AxiomaticPercentile()
        {
            AssertContent(SpecialAbilityConstants.Axiomatic, 73, 75);
        }

        [Test]
        public void DisruptionPercentile()
        {
            AssertContent(SpecialAbilityConstants.Disruption, 76, 78);
        }

        [Test]
        public void FlamingBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.FlamingBurst, 79, 81);
        }

        [Test]
        public void IcyBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.IcyBurst, 82, 84);
        }

        [Test]
        public void HolyPercentile()
        {
            AssertContent(SpecialAbilityConstants.Holy, 85, 87);
        }

        [Test]
        public void ShockingBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.ShockingBurst, 88, 90);
        }

        [Test]
        public void UnholyPercentile()
        {
            AssertContent(SpecialAbilityConstants.Unholy, 91, 93);
        }

        [Test]
        public void WoundingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Wounding, 94, 95);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 96, 100);
        }
    }
}