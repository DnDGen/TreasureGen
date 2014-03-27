using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons.Minor
{
    [TestFixture, PercentileTable("MinorMeleeWeaponSpecialAbilities")]
    public class MinorMeleeWeaponSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void BanePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Bane, 1, 10);
        }

        [Test]
        public void DefendingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Defending, 11, 17);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Flaming, 18, 27);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Frost, 28, 37);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Shock, 38, 47);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GhostTouchWeapon, 48, 56);
        }

        [Test]
        public void KeenPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Keen, 57, 67);
        }

        [Test]
        public void KiFocusPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.KiFocus, 68, 71);
        }

        [Test]
        public void MercifulPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Merciful, 72, 75);
        }

        [Test]
        public void MightyCleavingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.MightyCleaving, 76, 82);
        }

        [Test]
        public void SpellStoringPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellStoring, 83, 87);
        }

        [Test]
        public void ThrowingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Throwing, 88, 91);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Thundering, 92, 95);
        }

        [Test]
        public void ViciousPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Vicious, 96, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 100);
        }
    }
}