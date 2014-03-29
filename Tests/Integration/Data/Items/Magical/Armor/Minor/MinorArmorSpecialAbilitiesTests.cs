using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Minor
{
    [TestFixture]
    public class MinorArmorSpecialAbilitiesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MinorArmorSpecialAbilities";
        }

        [Test]
        public void GlameredPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Glamered, 1, 25);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.LightFortification, 26, 32);
        }

        [Test]
        public void SlickPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Slick, 33, 52);
        }

        [Test]
        public void ShadowPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Shadow, 53, 72);
        }

        [Test]
        public void SilentMovesPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.SilentMoves, 73, 92);
        }

        [Test]
        public void SpellResistance13Percentile()
        {
            AssertPercentile(SpecialAbilityConstants.SpellResistance13, 93, 96);
        }

        [Test]
        public void ImprovedSlickPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedSlick, 97);
        }

        [Test]
        public void ImprovedShadowPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedShadow, 98);
        }

        [Test]
        public void ImprovedSilentMovesPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ImprovedSilentMoves, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 100);
        }
    }
}