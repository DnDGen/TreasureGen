using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Major
{
    [TestFixture, PercentileTable("MajorShieldSpecialAbilities")]
    public class MajorShieldSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void ArrowCatchingPercentile()
        {
            AssertContent(SpecialAbilityConstants.ArrowCatching, 1, 5);
        }

        [Test]
        public void BashingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Bashing, 6, 8);
        }

        [Test]
        public void BlindingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Blinding, 9, 10);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.LightFortification, 11, 15);
        }

        [Test]
        public void ArrowDeflectionPercentile()
        {
            AssertContent(SpecialAbilityConstants.ArrowDeflection, 16, 20);
        }

        [Test]
        public void AnimatedPercentile()
        {
            AssertContent(SpecialAbilityConstants.Animated, 21, 25);
        }

        [Test]
        public void AcidResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.AcidResistance, 26, 28);
        }

        [Test]
        public void ColdResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ColdResistance, 29, 31);
        }

        [Test]
        public void ElectricityResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ElectricityResistance, 32, 34);
        }

        [Test]
        public void FireResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.FireResistance, 35, 37);
        }

        [Test]
        public void SonicResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.SonicResistance, 38, 40);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertContent(SpecialAbilityConstants.GhostTouchArmor, 41, 46);
        }

        [Test]
        public void ModerateFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.ModerateFortification, 47, 56);
        }

        [Test]
        public void SpellResistance15Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance15, 57, 58);
        }

        [Test]
        public void WildPercentile()
        {
            AssertContent(SpecialAbilityConstants.Wild, 59);
        }

        [Test]
        public void ImprovedAcidResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedAcidResistance, 60, 64);
        }

        [Test]
        public void ImprovedColdResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedColdResistance, 65, 69);
        }

        [Test]
        public void ImprovedElectricityResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedElectricityResistance, 70, 74);
        }

        [Test]
        public void ImprovedFireResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedFireResistance, 75, 79);
        }

        [Test]
        public void ImprovedSonicResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedSonicResistance, 80, 84);
        }

        [Test]
        public void SpellResistance17Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance17, 85, 86);
        }

        [Test]
        public void UndeadControllingPercentile()
        {
            AssertContent(SpecialAbilityConstants.UndeadControlling, 87);
        }

        [Test]
        public void HeavyFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.HeavyFortification, 88, 91);
        }

        [Test]
        public void ReflectingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Reflecting, 92, 93);
        }

        [Test]
        public void SpellResistance19Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance19, 94);
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