using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Armor.Major
{
    [TestFixture, PercentileTable("MajorArmorSpecialAbilities")]
    public class MajorArmorSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void GlameredPercentile()
        {
            AssertContent(SpecialAbilityConstants.Glamered, 1, 3);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.LightFortification, 4);
        }

        [Test]
        public void ImprovedSlickPercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedSlick, 5, 7);
        }

        [Test]
        public void ImprovedShadowPercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedShadow, 8, 10);
        }

        [Test]
        public void ImprovedSilentMovesPercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedSilentMoves, 11, 13);
        }

        [Test]
        public void AcidResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.AcidResistance, 14, 16);
        }

        [Test]
        public void ColdResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ColdResistance, 17, 19);
        }

        [Test]
        public void ElectricityResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ElectricityResistance, 20, 22);
        }

        [Test]
        public void FireResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.FireResistance, 23, 25);
        }

        [Test]
        public void SonicResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.SonicResistance, 26, 28);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertContent(SpecialAbilityConstants.GhostTouchArmor, 29, 33);
        }

        [Test]
        public void InvulnerabilityPercentile()
        {
            AssertContent(SpecialAbilityConstants.Invulnerability, 34, 35);
        }

        [Test]
        public void ModerateFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.ModerateFortification, 36, 40);
        }

        [Test]
        public void SpellResistance15Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance15, 41, 42);
        }

        [Test]
        public void WildPercentile()
        {
            AssertContent(SpecialAbilityConstants.Wild, 43);
        }

        [Test]
        public void GreaterSlickPercentile()
        {
            AssertContent(SpecialAbilityConstants.GreaterSlick, 44, 48);
        }

        [Test]
        public void GreaterShadowPercentile()
        {
            AssertContent(SpecialAbilityConstants.GreaterShadow, 49, 53);
        }

        [Test]
        public void GreaterSilentMovesPercentile()
        {
            AssertContent(SpecialAbilityConstants.GreaterSilentMoves, 54, 58);
        }

        [Test]
        public void ImprovedAcidResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedAcidResistance, 59, 63);
        }

        [Test]
        public void ImprovedColdResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedColdResistance, 64, 68);
        }

        [Test]
        public void ImprovedElectricityResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedElectricityResistance, 69, 73);
        }

        [Test]
        public void ImprovedFireResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedFireResistance, 74, 78);
        }

        [Test]
        public void ImprovedSonicResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedSonicResistance, 79, 83);
        }

        [Test]
        public void SpellResistance17Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance17, 84, 88);
        }

        [Test]
        public void EtherealnessPercentile()
        {
            AssertContent(SpecialAbilityConstants.Etherealness, 89);
        }

        [Test]
        public void UndeadControllingPercentile()
        {
            AssertContent(SpecialAbilityConstants.UndeadControlling, 90);
        }

        [Test]
        public void HeavyFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.HeavyFortification, 91, 92);
        }

        [Test]
        public void SpellResistance19Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance19, 93, 94);
        }

        [Test]
        public void GreaterAcidResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.GreaterAcidResistance, 95);
        }

        [Test]
        public void GreaterColdResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.GreaterColdResistance, 96);
        }

        [Test]
        public void GreaterElectricityResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.GreaterElectricityResistance, 97);
        }

        [Test]
        public void GreaterFireResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.GreaterFireResistance, 98);
        }

        [Test]
        public void GreaterSonicResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.GreaterSonicResistance, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 100);
        }
    }
}