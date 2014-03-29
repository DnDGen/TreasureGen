using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Major
{
    [TestFixture]
    public class MajorShieldSpecialAbilitiesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MajorShieldSpecialAbilities";
        }

        [Test]
        public void ArrowCatchingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ArrowCatching, 1, 5);
        }

        [Test]
        public void BashingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Bashing, 6, 8);
        }

        [Test]
        public void BlindingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Blinding, 9, 10);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.LightFortification, 11, 15);
        }

        [Test]
        public void ArrowDeflectionPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ArrowDeflection, 16, 20);
        }

        [Test]
        public void AnimatedPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Animated, 21, 25);
        }

        [Test]
        public void AcidResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.AcidResistance, 26, 28);
        }

        [Test]
        public void ColdResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ColdResistance, 29, 31);
        }

        [Test]
        public void ElectricityResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ElectricityResistance, 32, 34);
        }

        [Test]
        public void FireResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.FireResistance, 35, 37);
        }

        [Test]
        public void SonicResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.SonicResistance, 38, 40);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.GhostTouchArmor, 41, 46);
        }

        [Test]
        public void ModerateFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ModerateFortification, 47, 56);
        }

        [Test]
        public void SpellResistance15Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance15, 57, 58);
        }

        [Test]
        public void WildPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Wild, 59);
        }

        [Test]
        public void ImprovedAcidResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedAcidResistance, 60, 64);
        }

        [Test]
        public void ImprovedColdResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedColdResistance, 65, 69);
        }

        [Test]
        public void ImprovedElectricityResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedElectricityResistance, 70, 74);
        }

        [Test]
        public void ImprovedFireResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedFireResistance, 75, 79);
        }

        [Test]
        public void ImprovedSonicResistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedSonicResistance, 80, 84);
        }

        [Test]
        public void SpellResistance17Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance17, 85, 86);
        }

        [Test]
        public void UndeadControllingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.UndeadControlling, 87);
        }

        [Test]
        public void HeavyFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.HeavyFortification, 88, 91);
        }

        [Test]
        public void ReflectingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Reflecting, 92, 93);
        }

        [Test]
        public void SpellResistance19Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance19, 94);
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