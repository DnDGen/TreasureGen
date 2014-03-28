using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Medium
{
    [TestFixture, PercentileTable("MediumArmorSpecialAbilities")]
    public class MediumArmorSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void GlameredPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Glamered, 1, 5);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.LightFortification, 6, 8);
        }

        [Test]
        public void SlickPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Slick, 9, 11);
        }

        [Test]
        public void ShadowPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Shadow, 12, 14);
        }

        [Test]
        public void SilentMovesPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.SilentMoves, 15, 17);
        }

        [Test]
        public void SpellResistance13Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance13, 18, 19);
        }

        [Test]
        public void ImprovedSlickPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedSlick, 20, 29);
        }

        [Test]
        public void ImprovedShadowPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedShadow, 30, 39);
        }

        [Test]
        public void ImprovedSilentMovesPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedSilentMoves, 40, 49);
        }

        [Test]
        public void AcidResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.AcidResistance, 50, 54);
        }

        [Test]
        public void ColdResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ColdResistance, 55, 59);
        }

        [Test]
        public void ElectricityResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ElectricityResistance, 60, 64);
        }

        [Test]
        public void FireResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.FireResistance, 65, 69);
        }

        [Test]
        public void SonicResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.SonicResistance, 70, 74);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GhostTouchArmor, 75, 79);
        }

        [Test]
        public void InvulnerabilityPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Invulnerability, 80, 84);
        }

        [Test]
        public void ModerateFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ModerateFortification, 85, 89);
        }

        [Test]
        public void SpellResistance15Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance15, 90, 94);
        }

        [Test]
        public void WildPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Wild, 95, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 100);
        }
    }
}