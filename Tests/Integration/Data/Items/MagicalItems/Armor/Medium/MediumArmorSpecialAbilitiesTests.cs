using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Medium
{
    [TestFixture, PercentileTable("MediumArmorSpecialAbilities")]
    public class MediumArmorSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void GlameredPercentile()
        {
            AssertContent(SpecialAbilityConstants.Glamered, 1, 5);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.LightFortification, 6, 8);
        }

        [Test]
        public void SlickPercentile()
        {
            AssertContent(SpecialAbilityConstants.Slick, 9, 11);
        }

        [Test]
        public void ShadowPercentile()
        {
            AssertContent(SpecialAbilityConstants.Shadow, 12, 14);
        }

        [Test]
        public void SilentMovesPercentile()
        {
            AssertContent(SpecialAbilityConstants.SilentMoves, 15, 17);
        }

        [Test]
        public void SpellResistance13Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance13, 18, 19);
        }

        [Test]
        public void ImprovedSlickPercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedSlick, 20, 29);
        }

        [Test]
        public void ImprovedShadowPercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedShadow, 30, 39);
        }

        [Test]
        public void ImprovedSilentMovesPercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedSilentMoves, 40, 49);
        }

        [Test]
        public void AcidResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.AcidResistance, 50, 54);
        }

        [Test]
        public void ColdResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ColdResistance, 55, 59);
        }

        [Test]
        public void ElectricityResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ElectricityResistance, 60, 64);
        }

        [Test]
        public void FireResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.FireResistance, 65, 69);
        }

        [Test]
        public void SonicResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.SonicResistance, 70, 74);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertContent(SpecialAbilityConstants.GhostTouchArmor, 75, 79);
        }

        [Test]
        public void InvulnerabilityPercentile()
        {
            AssertContent(SpecialAbilityConstants.Invulnerability, 80, 84);
        }

        [Test]
        public void ModerateFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.ModerateFortification, 85, 89);
        }

        [Test]
        public void SpellResistance15Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance15, 90, 94);
        }

        [Test]
        public void WildPercentile()
        {
            AssertContent(SpecialAbilityConstants.Wild, 95, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 100);
        }
    }
}