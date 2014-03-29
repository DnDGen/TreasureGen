using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Minor
{
    [TestFixture]
    public class MinorShieldSpecialAbilitiesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MinorShieldSpecialAbilities";
        }

        [Test]
        public void ArrowCatchingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ArrowCatching, 1, 20);
        }

        [Test]
        public void BashingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Bashing, 21, 40);
        }

        [Test]
        public void BlindingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Blinding, 41, 50);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.LightFortification, 51, 75);
        }

        [Test]
        public void ArrowDeflectionPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ArrowDeflection, 76, 92);
        }

        [Test]
        public void AnimatedPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Animated, 93, 97);
        }

        [Test]
        public void SpellResistance13Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance13, 98, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 100);
        }
    }
}