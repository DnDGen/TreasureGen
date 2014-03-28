using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Medium
{
    [TestFixture, PercentileTable("MediumShieldSpecialAbilities")]
    public class MediumShieldSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void ArrowCatchingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ArrowCatching, 1, 10);
        }

        [Test]
        public void BashingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Bashing, 11, 20);
        }

        [Test]
        public void BlindingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Blinding, 21, 25);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.LightFortification, 26, 40);
        }

        [Test]
        public void ArrowDeflectionPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ArrowDeflection, 41, 50);
        }

        [Test]
        public void AnimatedPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Animated, 51, 57);
        }

        [Test]
        public void SpellResistance13Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance13, 58, 59);
        }

        [Test]
        public void AcidResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.AcidResistance, 60, 63);
        }

        [Test]
        public void ColdResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ColdResistance, 64, 67);
        }

        [Test]
        public void ElectricityResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ElectricityResistance, 68, 71);
        }

        [Test]
        public void FireResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.FireResistance, 72, 75);
        }

        [Test]
        public void SonicResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.SonicResistance, 76, 79);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GhostTouchArmor, 80, 85);
        }

        [Test]
        public void ModerateFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ModerateFortification, 86, 95);
        }

        [Test]
        public void SpellResistance15Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance15, 96, 98);
        }

        [Test]
        public void WildPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Wild, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 100);
        }
    }
}