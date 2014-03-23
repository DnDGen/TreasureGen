using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Arcane
{
    [TestFixture, PercentileTable("Level0ArcaneSpells")]
    public class Level0ArcaneSpellsTests : PercentileTests
    {
        [Test]
        public void AcidSplashPercentile()
        {
            AssertContent("Acid splash", 1, 4);
        }

        [Test]
        public void ArcaneMarkPercentile()
        {
            AssertContent("Arcane mark", 5, 8);
        }

        [Test]
        public void DancingLightsPercentile()
        {
            AssertContent("Dancing lights", 9, 13);
        }

        [Test]
        public void DazePercentile()
        {
            AssertContent("Daze", 14, 17);
        }

        [Test]
        public void DetectMagicPercentile()
        {
            AssertContent("Detect magic", 18, 24);
        }

        [Test]
        public void DetectPoisonPercentile()
        {
            AssertContent("Detect poison", 25, 28);
        }

        [Test]
        public void DisruptUndeadPercentile()
        {
            AssertContent("Disrupt undead", 29, 32);
        }

        [Test]
        public void FlarePercentile()
        {
            AssertContent("Flare", 33, 37);
        }

        [Test]
        public void GhostSoundPercentile()
        {
            AssertContent("Ghost sound", 38, 42);
        }

        [Test]
        public void KnowDirectionPercentile()
        {
            AssertContent("Know direction", 43, 44);
        }

        [Test]
        public void LightPercentile()
        {
            AssertContent("Light", 45, 50);
        }

        [Test]
        public void LullabyPercentile()
        {
            AssertContent("Lullaby", 51, 52);
        }

        [Test]
        public void MageHandPercentile()
        {
            AssertContent("Mage hand", 53, 57);
        }

        [Test]
        public void MendingPercentile()
        {
            AssertContent("Mending", 58, 62);
        }

        [Test]
        public void MessagePercentile()
        {
            AssertContent("Message", 63, 67);
        }

        [Test]
        public void OpenClosePercentile()
        {
            AssertContent("Open/close", 68, 72);
        }

        [Test]
        public void PrestidigitationPercentile()
        {
            AssertContent("Prestidigitation", 73, 77);
        }

        [Test]
        public void RayOfFrostPercentile()
        {
            AssertContent("Ray of frost", 78, 81);
        }

        [Test]
        public void ReadMagicPercentile()
        {
            AssertContent("Read magic", 82, 87);
        }

        [Test]
        public void ResistancePercentile()
        {
            AssertContent("Resistance", 88, 94);
        }

        [Test]
        public void SummonInstrumentPercentile()
        {
            AssertContent("Summon instrument", 95, 96);
        }

        [Test]
        public void TouchOfFatiguePercentile()
        {
            AssertContent("Touch of fatigue", 97, 100);
        }
    }
}