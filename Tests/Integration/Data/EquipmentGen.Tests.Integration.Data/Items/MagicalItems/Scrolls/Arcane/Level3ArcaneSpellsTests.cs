using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Scrolls.Arcane
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

        [Test]
        public void FlameArrowPercentile()
        {
            AssertContent("Flame arrow", 21, 22);
        }

        [Test]
        public void FlyPercentile()
        {
            AssertContent("Fly", 23, 25);
        }

        [Test]
        public void GaseousFormPercentile()
        {
            AssertContent("Gaseous form", 26, 27);
        }

        [Test]
        public void GentleReposePercentile()
        {
            AssertContent("Gentle repose", 28, 29);
        }

        [Test]
        public void GlibnessPercentile()
        {
            AssertContent("Glibness", 30);
        }

        [Test]
        public void GoodHopePercentile()
        {
            AssertContent("Good hope", 31);
        }

        [Test]
        public void HaltUndeadPercentile()
        {
            AssertContent("Halt undead", 32, 33);
        }

        [Test]
        public void HastePercentile()
        {
            AssertContent("Haste", 34, 36);
        }

        [Test]
        public void HeroismPercentile()
        {
            AssertContent("Heroism", 37, 38);
        }

        [Test]
        public void HoldPersonPercentile()
        {
            AssertContent("Hold person", 39, 40);
        }

        [Test]
        public void IllusoryScriptPercentile()
        {
            AssertContent("Illusory script", 41);
        }

        [Test]
        public void InvisibilitySpherePercentile()
        {
            AssertContent("Invisibility sphere", 42, 44);
        }

        [Test]
        public void KeenEdgePercentile()
        {
            AssertContent("Keen edge", 45, 47);
        }

        [Test]
        public void LeomundsTinyHutPercentile()
        {
            AssertContent("Leomund's tiny hut", 48, 49);
        }

        [Test]
        public void LightningBoltPercentile()
        {
            AssertContent("Lightning bolt", 50, 51);
        }

        [Test]
        public void MagicCircleAgainstChaosEvilGoodLawPercentile()
        {
            AssertContent("Magic circle against chaos/evil/good/law", 52, 59);
        }

        [Test]
        public void GreaterMagicWeaponPercentile()
        {
            AssertContent("Greater magic weapon", 60, 62);
        }

        [Test]
        public void MajorImagePercentile()
        {
            AssertContent("Major image", 63, 64);
        }

        [Test]
        public void NondetectionPercentile()
        {
            AssertContent("Nondetection", 65, 66);
        }

        [Test]
        public void PhantomSteedPercentile()
        {
            AssertContent("Phantom steed", 67, 68);
        }

        [Test]
        public void ProtectionFromEnergyPercentile()
        {
            AssertContent("Protection from energy", 69, 71);
        }

        [Test]
        public void RagePercentile()
        {
            AssertContent("Rage", 72, 73);
        }

        [Test]
        public void RayOfExhaustionPercentile()
        {
            AssertContent("Ray of exhaustion", 74, 75);
        }

        [Test]
        public void SculptSoundPercentile()
        {
            AssertContent("Sculpt sound", 76);
        }

        [Test]
        public void SecretPagePercentile()
        {
            AssertContent("Secret page", 77);
        }

        [Test]
        public void SepiaSnakeSigilPercentile()
        {
            AssertContent("Sepia snake sigil", 78);
        }

        [Test]
        public void ShrinkItemPercentile()
        {
            AssertContent("Shrink item", 79);
        }

        [Test]
        public void SleetStormPercentile()
        {
            AssertContent("Sleet storm", 80, 81);
        }

        [Test]
        public void SlowPercentile()
        {
            AssertContent("Slow", 82, 83);
        }

        [Test]
        public void SpeakWithAnimalsPercentile()
        {
            AssertContent("Speak with animals", 84);
        }

        [Test]
        public void StinkingCloudPercentile()
        {
            AssertContent("Stinking cloud", 85, 86);
        }

        [Test]
        public void SuggestionPercentile()
        {
            AssertContent("Suggestion", 87, 88);
        }

        [Test]
        public void SummonMonsterIIIPercentile()
        {
            AssertContent("Summon monster III", 89, 90);
        }

        [Test]
        public void TonguesPercentile()
        {
            AssertContent("Tongues", 91, 93);
        }

        [Test]
        public void VampiricTouchPercentile()
        {
            AssertContent("Vampiric touch", 94, 95);
        }

        [Test]
        public void WaterBreathingPercentile()
        {
            AssertContent("Water breathing", 96, 98);
        }

        [Test]
        public void WindWallPercentile()
        {
            AssertContent("Wind wall", 99, 100);
        }
    }
}