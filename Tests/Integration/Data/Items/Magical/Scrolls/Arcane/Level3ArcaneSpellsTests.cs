using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Arcane
{
    [TestFixture]
    public class Level3ArcaneSpellsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level3ArcaneSpells";
        }

        [Test]
        public void ArcaneSightPercentile()
        {
            AssertPercentile("Arcane sight", 1, 2);
        }

        [Test]
        public void BlinkPercentile()
        {
            AssertPercentile("Blink", 3, 4);
        }

        [Test]
        public void ClairaudienceClairvoyancePercentile()
        {
            AssertPercentile("Clairaudience/clairvoyance", 5, 6);
        }

        [Test]
        public void CureSeriousWoundsPercentile()
        {
            AssertPercentile("Cure serious wounds", 7);
        }

        [Test]
        public void DaylightPercentile()
        {
            AssertPercentile("Daylight", 8, 10);
        }

        [Test]
        public void DeepSlumberPercentile()
        {
            AssertPercentile("Deep slumber", 11, 12);
        }

        [Test]
        public void DispelMagicPercentile()
        {
            AssertPercentile("Dispel magic", 13, 15);
        }

        [Test]
        public void DisplacementPercentile()
        {
            AssertPercentile("Displacement", 16, 17);
        }

        [Test]
        public void ExplosiveRunesPercentile()
        {
            AssertPercentile("Explosive runes", 18);
        }

        [Test]
        public void FireballPercentile()
        {
            AssertPercentile("Fireball", 19, 20);
        }

        [Test]
        public void FlameArrowPercentile()
        {
            AssertPercentile("Flame arrow", 21, 22);
        }

        [Test]
        public void FlyPercentile()
        {
            AssertPercentile("Fly", 23, 25);
        }

        [Test]
        public void GaseousFormPercentile()
        {
            AssertPercentile("Gaseous form", 26, 27);
        }

        [Test]
        public void GentleReposePercentile()
        {
            AssertPercentile("Gentle repose", 28, 29);
        }

        [Test]
        public void GlibnessPercentile()
        {
            AssertPercentile("Glibness", 30);
        }

        [Test]
        public void GoodHopePercentile()
        {
            AssertPercentile("Good hope", 31);
        }

        [Test]
        public void HaltUndeadPercentile()
        {
            AssertPercentile("Halt undead", 32, 33);
        }

        [Test]
        public void HastePercentile()
        {
            AssertPercentile("Haste", 34, 36);
        }

        [Test]
        public void HeroismPercentile()
        {
            AssertPercentile("Heroism", 37, 38);
        }

        [Test]
        public void HoldPersonPercentile()
        {
            AssertPercentile("Hold person", 39, 40);
        }

        [Test]
        public void IllusoryScriptPercentile()
        {
            AssertPercentile("Illusory script", 41);
        }

        [Test]
        public void InvisibilitySpherePercentile()
        {
            AssertPercentile("Invisibility sphere", 42, 44);
        }

        [Test]
        public void KeenEdgePercentile()
        {
            AssertPercentile("Keen edge", 45, 47);
        }

        [Test]
        public void LeomundsTinyHutPercentile()
        {
            AssertPercentile("Leomund's tiny hut", 48, 49);
        }

        [Test]
        public void LightningBoltPercentile()
        {
            AssertPercentile("Lightning bolt", 50, 51);
        }

        [Test]
        public void MagicCircleAgainstChaosEvilGoodLawPercentile()
        {
            AssertPercentile("Magic circle against chaos/evil/good/law", 52, 59);
        }

        [Test]
        public void GreaterMagicWeaponPercentile()
        {
            AssertPercentile("Greater magic weapon", 60, 62);
        }

        [Test]
        public void MajorImagePercentile()
        {
            AssertPercentile("Major image", 63, 64);
        }

        [Test]
        public void NondetectionPercentile()
        {
            AssertPercentile("Nondetection", 65, 66);
        }

        [Test]
        public void PhantomSteedPercentile()
        {
            AssertPercentile("Phantom steed", 67, 68);
        }

        [Test]
        public void ProtectionFromEnergyPercentile()
        {
            AssertPercentile("Protection from energy", 69, 71);
        }

        [Test]
        public void RagePercentile()
        {
            AssertPercentile("Rage", 72, 73);
        }

        [Test]
        public void RayOfExhaustionPercentile()
        {
            AssertPercentile("Ray of exhaustion", 74, 75);
        }

        [Test]
        public void SculptSoundPercentile()
        {
            AssertPercentile("Sculpt sound", 76);
        }

        [Test]
        public void SecretPagePercentile()
        {
            AssertPercentile("Secret page", 77);
        }

        [Test]
        public void SepiaSnakeSigilPercentile()
        {
            AssertPercentile("Sepia snake sigil", 78);
        }

        [Test]
        public void ShrinkItemPercentile()
        {
            AssertPercentile("Shrink item", 79);
        }

        [Test]
        public void SleetStormPercentile()
        {
            AssertPercentile("Sleet storm", 80, 81);
        }

        [Test]
        public void SlowPercentile()
        {
            AssertPercentile("Slow", 82, 83);
        }

        [Test]
        public void SpeakWithAnimalsPercentile()
        {
            AssertPercentile("Speak with animals", 84);
        }

        [Test]
        public void StinkingCloudPercentile()
        {
            AssertPercentile("Stinking cloud", 85, 86);
        }

        [Test]
        public void SuggestionPercentile()
        {
            AssertPercentile("Suggestion", 87, 88);
        }

        [Test]
        public void SummonMonsterIIIPercentile()
        {
            AssertPercentile("Summon monster III", 89, 90);
        }

        [Test]
        public void TonguesPercentile()
        {
            AssertPercentile("Tongues", 91, 93);
        }

        [Test]
        public void VampiricTouchPercentile()
        {
            AssertPercentile("Vampiric touch", 94, 95);
        }

        [Test]
        public void WaterBreathingPercentile()
        {
            AssertPercentile("Water breathing", 96, 98);
        }

        [Test]
        public void WindWallPercentile()
        {
            AssertPercentile("Wind wall", 99, 100);
        }
    }
}