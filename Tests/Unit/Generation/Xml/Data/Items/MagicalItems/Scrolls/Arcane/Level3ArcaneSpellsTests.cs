using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Scrolls.Arcane
{
    [TestFixture, PercentileTable("Level3ArcaneSpells")]
    public class Level3ArcaneSpellsTests : PercentileTests
    {
        [Test]
        public void ArcaneSightPercentile()
        {
            AssertContent("Arcane sight", 1, 2);
        }

        [Test]
        public void BlinkPercentile()
        {
            AssertContent("Blink", 3, 4);
        }

        [Test]
        public void ClairaudienceClairvoyancePercentile()
        {
            AssertContent("Clairaudience/clairvoyance", 5, 6);
        }

        [Test]
        public void CureSeriousWoundsPercentile()
        {
            AssertContent("Cure serious wounds", 7);
        }

        [Test]
        public void DaylightPercentile()
        {
            AssertContent("Daylight", 8, 10);
        }

        [Test]
        public void DeepSlumberPercentile()
        {
            AssertContent("Deep slumber", 11, 12);
        }

        [Test]
        public void DispelMagicPercentile()
        {
            AssertContent("Dispel magic", 13, 15);
        }

        [Test]
        public void DisplacementPercentile()
        {
            AssertContent("Displacement", 16, 17);
        }

        [Test]
        public void ExplosiveRunesPercentile()
        {
            AssertContent("Explosive runes", 18);
        }

        [Test]
        public void FireballPercentile()
        {
            AssertContent("Fireball", 19, 20);
        }
    }
}