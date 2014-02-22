using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Weapons.Major
{
    [TestFixture, PercentileTable("MajorMeleeWeaponSpecialAbilities")]
    public class MajorMeleeWeaponSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void BanePercentile()
        {
            AssertContent(SpecialAbilityConstants.Bane, 1, 3);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Flaming, 4, 6);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertContent(SpecialAbilityConstants.Frost, 7, 9);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertContent(SpecialAbilityConstants.Shock, 10, 12);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertContent(SpecialAbilityConstants.GhostTouchWeapon, 13, 15);
        }

        [Test]
        public void KiFocusPercentile()
        {
            AssertContent(SpecialAbilityConstants.KiFocus, 16, 19);
        }

        [Test]
        public void MightyCleavingPercentile()
        {
            AssertContent(SpecialAbilityConstants.MightyCleaving, 20, 21);
        }

        [Test]
        public void SpellStoringPercentile()
        {
            AssertContent(SpecialAbilityConstants.SpellStoring, 22, 24);
        }

        [Test]
        public void ThrowingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Throwing, 25, 28);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Thundering, 29, 32);
        }

        [Test]
        public void ViciousPercentile()
        {
            AssertContent(SpecialAbilityConstants.Vicious, 33, 36);
        }

        [Test]
        public void AnarchicPercentile()
        {
            AssertContent(SpecialAbilityConstants.Anarchic, 37, 41);
        }

        [Test]
        public void AxiomaticPercentile()
        {
            AssertContent(SpecialAbilityConstants.Axiomatic, 42, 46);
        }

        [Test]
        public void DisruptionPercentile()
        {
            AssertContent(SpecialAbilityConstants.Disruption, 47, 49);
        }

        [Test]
        public void FlamingBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.FlamingBurst, 50, 54);
        }

        [Test]
        public void IcyBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.IcyBurst, 55, 59);
        }

        [Test]
        public void HolyPercentile()
        {
            AssertContent(SpecialAbilityConstants.Holy, 60, 64);
        }

        [Test]
        public void ShockingBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.ShockingBurst, 65, 69);
        }

        [Test]
        public void UnholyPercentile()
        {
            AssertContent(SpecialAbilityConstants.Unholy, 70, 74);
        }

        [Test]
        public void WoundingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Wounding, 75, 78);
        }

        [Test]
        public void SpeedPercentile()
        {
            AssertContent(SpecialAbilityConstants.Speed, 79, 83);
        }

        [Test]
        public void BrilliantEnergyPercentile()
        {
            AssertContent(SpecialAbilityConstants.BrilliantEnergy, 84, 86);
        }

        [Test]
        public void DancingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Dancing, 87, 88);
        }

        [Test]
        public void VorpalPercentile()
        {
            AssertContent(SpecialAbilityConstants.Vorpal, 89, 90);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 91, 100);
        }
    }
}