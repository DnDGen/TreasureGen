using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Arcane
{
    [TestFixture]
    public class Level0ArcaneSpellsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level0ArcaneSpells";
        }

        [Test]
        public void AcidSplashPercentile()
        {
            AssertPercentile("Acid splash", 1, 4);
        }

        [Test]
        public void ArcaneMarkPercentile()
        {
            AssertPercentile("Arcane mark", 5, 8);
        }

        [Test]
        public void DancingLightsPercentile()
        {
            AssertPercentile("Dancing lights", 9, 13);
        }

        [Test]
        public void DazePercentile()
        {
            AssertPercentile("Daze", 14, 17);
        }

        [Test]
        public void DetectMagicPercentile()
        {
            AssertPercentile("Detect magic", 18, 24);
        }

        [Test]
        public void DetectPoisonPercentile()
        {
            AssertPercentile("Detect poison", 25, 28);
        }

        [Test]
        public void DisruptUndeadPercentile()
        {
            AssertPercentile("Disrupt undead", 29, 32);
        }

        [Test]
        public void FlarePercentile()
        {
            AssertPercentile("Flare", 33, 37);
        }

        [Test]
        public void GhostSoundPercentile()
        {
            AssertPercentile("Ghost sound", 38, 42);
        }

        [Test]
        public void KnowDirectionPercentile()
        {
            AssertPercentile("Know direction", 43, 44);
        }

        [Test]
        public void LightPercentile()
        {
            AssertPercentile("Light", 45, 50);
        }

        [Test]
        public void LullabyPercentile()
        {
            AssertPercentile("Lullaby", 51, 52);
        }

        [Test]
        public void MageHandPercentile()
        {
            AssertPercentile("Mage hand", 53, 57);
        }

        [Test]
        public void MendingPercentile()
        {
            AssertPercentile("Mending", 58, 62);
        }

        [Test]
        public void MessagePercentile()
        {
            AssertPercentile("Message", 63, 67);
        }

        [Test]
        public void OpenClosePercentile()
        {
            AssertPercentile("Open/close", 68, 72);
        }

        [Test]
        public void PrestidigitationPercentile()
        {
            AssertPercentile("Prestidigitation", 73, 77);
        }

        [Test]
        public void RayOfFrostPercentile()
        {
            AssertPercentile("Ray of frost", 78, 81);
        }

        [Test]
        public void ReadMagicPercentile()
        {
            AssertPercentile("Read magic", 82, 87);
        }

        [Test]
        public void ResistancePercentile()
        {
            AssertPercentile("Resistance", 88, 94);
        }

        [Test]
        public void SummonInstrumentPercentile()
        {
            AssertPercentile("Summon instrument", 95, 96);
        }

        [Test]
        public void TouchOfFatiguePercentile()
        {
            AssertPercentile("Touch of fatigue", 97, 100);
        }
    }
}