using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor.Minor
{
    [TestFixture, PercentileTable("MinorShieldSpecialAbilities")]
    public class MinorShieldSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void ArrowCatchingPercentile()
        {
            AssertContent("Arrow catching,1,0", 1, 20);
        }

        [Test]
        public void BashingPercentile()
        {
            AssertContent("Bashing,1,0", 21, 40);
        }

        [Test]
        public void BlindingPercentile()
        {
            AssertContent("Blinding,1,0", 41, 50);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertContent("Fortification,1,0", 51, 75);
        }

        [Test]
        public void ArrowDeflectionPercentile()
        {
            AssertContent("Arrow deflection,2,0", 76, 92);
        }

        [Test]
        public void AnimatedPercentile()
        {
            AssertContent("Animated,2,0", 93, 97);
        }

        [Test]
        public void SpellResistance13Percentile()
        {
            AssertContent("Spell resistance,2,13", 98, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility,0,0", 100);
        }
    }
}