using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor.Medium
{
    [TestFixture, PercentileTable("MediumShieldSpecialAbilities")]
    public class MediumShieldSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void ArrowCatchingPercentile()
        {
            AssertContent(SpecialAbilityConstants.ArrowCatching, 1, 10);
        }

        [Test]
        public void BashingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Bashing, 11, 20);
        }

        [Test]
        public void BlindingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Blinding, 21, 25);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.LightFortification, 26, 40);
        }

        [Test]
        public void ArrowDeflectionPercentile()
        {
            AssertContent(SpecialAbilityConstants.ArrowDeflection, 41, 50);
        }

        [Test]
        public void AnimatedPercentile()
        {
            AssertContent(SpecialAbilityConstants.Animated, 51, 57);
        }

        [Test]
        public void SpellResistance13Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance13, 58, 59);
        }

        [Test]
        public void AcidResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.AcidResistance, 60, 63);
        }

        [Test]
        public void ColdResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ColdResistance, 64, 67);
        }

        [Test]
        public void ElectricityResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.ElectricityResistance, 68, 71);
        }

        [Test]
        public void FireResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.FireResistance, 72, 75);
        }

        [Test]
        public void SonicResistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.SonicResistance, 76, 79);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertContent(SpecialAbilityConstants.GhostTouchArmor, 80, 85);
        }

        [Test]
        public void ModerateFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.ModerateFortification, 86, 95);
        }

        [Test]
        public void SpellResistance15Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance15, 96, 98);
        }

        [Test]
        public void WildPercentile()
        {
            AssertContent(SpecialAbilityConstants.Wild, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 100);
        }
    }
}