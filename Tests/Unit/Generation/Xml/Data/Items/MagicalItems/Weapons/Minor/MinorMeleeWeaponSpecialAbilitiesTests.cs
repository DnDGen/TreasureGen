using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Weapons.Minor
{
    [TestFixture, PercentileTable("MinorMeleeWeaponSpecialAbilities")]
    public class MinorMeleeWeaponSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void BanePercentile()
        {
            AssertContent(SpecialAbilityConstants.Bane, 1, 10);
        }

        [Test]
        public void DefendingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Defending, 11, 17);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Flaming, 18, 27);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertContent(SpecialAbilityConstants.Frost, 28, 37);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertContent(SpecialAbilityConstants.Shock, 38, 47);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertContent(SpecialAbilityConstants.GhostTouchWeapon, 48, 56);
        }

        [Test]
        public void KeenPercentile()
        {
            AssertContent(SpecialAbilityConstants.Keen, 57, 67);
        }

        [Test]
        public void KiFocusPercentile()
        {
            AssertContent(SpecialAbilityConstants.KiFocus, 68, 71);
        }

        [Test]
        public void MercifulPercentile()
        {
            AssertContent(SpecialAbilityConstants.Merciful, 72, 75);
        }

        [Test]
        public void MightyCleavingPercentile()
        {
            AssertContent(SpecialAbilityConstants.MightyCleaving, 76, 82);
        }

        [Test]
        public void SpellStoringPercentile()
        {
            AssertContent(SpecialAbilityConstants.SpellStoring, 83, 87);
        }

        [Test]
        public void ThrowingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Throwing, 88, 91);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Thundering, 92, 95);
        }

        [Test]
        public void ViciousPercentile()
        {
            AssertContent(SpecialAbilityConstants.Vicious, 96, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 100);
        }
    }
}