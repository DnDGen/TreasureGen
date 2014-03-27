using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Major
{
    [TestFixture, PercentileTable("MajorArmorSpecialAbilities")]
    public class MajorArmorSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void GlameredPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Glamered, 1, 3);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.LightFortification, 4);
        }

        [Test]
        public void ImprovedSlickPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedSlick, 5, 7);
        }

        [Test]
        public void ImprovedShadowPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedShadow, 8, 10);
        }

        [Test]
        public void ImprovedSilentMovesPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedSilentMoves, 11, 13);
        }

        [Test]
        public void AcidResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.AcidResistance, 14, 16);
        }

        [Test]
        public void ColdResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ColdResistance, 17, 19);
        }

        [Test]
        public void ElectricityResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ElectricityResistance, 20, 22);
        }

        [Test]
        public void FireResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.FireResistance, 23, 25);
        }

        [Test]
        public void SonicResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.SonicResistance, 26, 28);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GhostTouchArmor, 29, 33);
        }

        [Test]
        public void InvulnerabilityPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Invulnerability, 34, 35);
        }

        [Test]
        public void ModerateFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ModerateFortification, 36, 40);
        }

        [Test]
        public void SpellResistance15Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance15, 41, 42);
        }

        [Test]
        public void WildPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Wild, 43);
        }

        [Test]
        public void GreaterSlickPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GreaterSlick, 44, 48);
        }

        [Test]
        public void GreaterShadowPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GreaterShadow, 49, 53);
        }

        [Test]
        public void GreaterSilentMovesPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GreaterSilentMoves, 54, 58);
        }

        [Test]
        public void ImprovedAcidResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedAcidResistance, 59, 63);
        }

        [Test]
        public void ImprovedColdResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedColdResistance, 64, 68);
        }

        [Test]
        public void ImprovedElectricityResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedElectricityResistance, 69, 73);
        }

        [Test]
        public void ImprovedFireResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedFireResistance, 74, 78);
        }

        [Test]
        public void ImprovedSonicResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedSonicResistance, 79, 83);
        }

        [Test]
        public void SpellResistance17Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance17, 84, 88);
        }

        [Test]
        public void EtherealnessPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Etherealness, 89);
        }

        [Test]
        public void UndeadControllingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.UndeadControlling, 90);
        }

        [Test]
        public void HeavyFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.HeavyFortification, 91, 92);
        }

        [Test]
        public void SpellResistance19Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance19, 93, 94);
        }

        [Test]
        public void GreaterAcidResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GreaterAcidResistance, 95);
        }

        [Test]
        public void GreaterColdResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GreaterColdResistance, 96);
        }

        [Test]
        public void GreaterElectricityResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GreaterElectricityResistance, 97);
        }

        [Test]
        public void GreaterFireResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GreaterFireResistance, 98);
        }

        [Test]
        public void GreaterSonicResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GreaterSonicResistance, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 100);
        }
    }
}