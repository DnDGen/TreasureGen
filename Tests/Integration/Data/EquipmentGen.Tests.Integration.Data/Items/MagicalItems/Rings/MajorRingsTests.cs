using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Rings
{
    [TestFixture, PercentileTable("MajorRings")]
    public class MajorRingsTests : PercentileTests
    {
        [Test]
        public void MinorEnergyResistancePercentile()
        {
            AssertContent("Minor energy resistance", 1, 2);
        }

        [Test]
        public void ProtectionPlus3Percentile()
        {
            AssertContent("Protection +3", 3, 7);
        }

        [Test]
        public void MinorSpellStoringPercentile()
        {
            AssertContent("Minor spell storing", 8, 10);
        }

        [Test]
        public void InvisibilityPercentile()
        {
            AssertContent("Invisibility", 11, 15);
        }

        [Test]
        public void WizardryIPercentile()
        {
            AssertContent("Wizardry (I)", 16, 19);
        }

        [Test]
        public void EvasionPercentile()
        {
            AssertContent("Evasion", 20, 25);
        }

        [Test]
        public void XRayVisionPercentile()
        {
            AssertContent("X-ray vision", 26, 28);
        }

        [Test]
        public void BlinkingPercentile()
        {
            AssertContent("Blinking", 29, 32);
        }

        [Test]
        public void MajorEnergyResistancePercentile()
        {
            AssertContent("Major energy resistance", 33, 39);
        }

        [Test]
        public void ProtectionPlus4Percentile()
        {
            AssertContent("Protection +4", 40, 49);
        }

        [Test]
        public void WizardryIIPercentile()
        {
            AssertContent("Wizardry (II)", 50, 55);
        }

        [Test]
        public void FreedomOfMovementPercentile()
        {
            AssertContent("Freedom of movement", 56, 60);
        }

        [Test]
        public void GreaterEnergyResistancePercentile()
        {
            AssertContent("Greater energy resistance", 61, 63);
        }

        [Test]
        public void FriendShieldPercentile()
        {
            AssertContent("Friend shield (pair)", 64, 65);
        }

        [Test]
        public void ProtectionPlus5Percentile()
        {
            AssertContent("Protection +5", 66, 70);
        }

        [Test]
        public void ShootingStarsPercentile()
        {
            AssertContent("Shooting stars", 71, 74);
        }

        [Test]
        public void SpellStoringPercentile()
        {
            AssertContent("Spell storing", 75, 79);
        }

        [Test]
        public void WizardryIIIPercentile()
        {
            AssertContent("Wizardry (III)", 80, 83);
        }

        [Test]
        public void TelekinesisPercentile()
        {
            AssertContent("Telekinesis", 84, 86);
        }

        [Test]
        public void RegenerationPercentile()
        {
            AssertContent("Regeneration", 87, 88);
        }

        [Test]
        public void ThreeWishesPercentile()
        {
            AssertContent("Three wishes", 89);
        }

        [Test]
        public void SpellTurningPercentile()
        {
            AssertContent("Spell turning", 90, 92);
        }

        [Test]
        public void WizardryIVPercentile()
        {
            AssertContent("Wizardry (IV)", 93, 94);
        }

        [Test]
        public void DjinniCallingPercentile()
        {
            AssertContent("Djinni calling", 95);
        }

        [Test]
        public void ElementalCommandAirPercentile()
        {
            AssertContent("Elemental command (air)", 96);
        }

        [Test]
        public void ElementalCommandEarthPercentile()
        {
            AssertContent("Elemental command (earth)", 97);
        }

        [Test]
        public void ElementalCommandFirePercentile()
        {
            AssertContent("Elemental command (fire)", 98);
        }

        [Test]
        public void ElementalCommandWaterPercentile()
        {
            AssertContent("Elemental command (water)", 99);
        }

        [Test]
        public void MajorSpellStoringPercentile()
        {
            AssertContent("Major spell storing", 100);
        }
    }
}