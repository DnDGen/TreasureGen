using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor.Minor
{
    [TestFixture, PercentileTable("MinorArmorSpecialAbilities")]
    public class MinorArmorSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void GlameredPercentile()
        {
            AssertContent(SpecialAbilityConstants.Glamered, 1, 25);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.LightFortification, 26, 32);
        }

        [Test]
        public void SlickPercentile()
        {
            AssertContent(SpecialAbilityConstants.Slick, 33, 52);
        }

        [Test]
        public void ShadowPercentile()
        {
            AssertContent(SpecialAbilityConstants.Shadow, 53, 72);
        }

        [Test]
        public void SilentMovesPercentile()
        {
            AssertContent(SpecialAbilityConstants.SilentMoves, 73, 92);
        }

        [Test]
        public void SpellResistance13Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance13, 93, 96);
        }

        [Test]
        public void ImprovedSlickPercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedSlick, 97);
        }

        [Test]
        public void ImprovedShadowPercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedShadow, 98);
        }

        [Test]
        public void ImprovedSilentMovesPercentile()
        {
            AssertContent(SpecialAbilityConstants.ImprovedSilentMoves, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 100);
        }
    }
}