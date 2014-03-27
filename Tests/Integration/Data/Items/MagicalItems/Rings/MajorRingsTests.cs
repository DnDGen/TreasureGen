using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Rings
{
    [TestFixture, PercentileTable("MajorRings")]
    public class MajorRingsTests : PercentileTests
    {
        [Test]
        public void MinorEnergyResistancePercentile()
        {
            AssertPercentile("Minor energy resistance", 1, 2);
        }

        [Test]
        public void ProtectionPlus3Percentile()
        {
            AssertPercentile("Protection +3", 3, 7);
        }

        [Test]
        public void MinorSpellStoringPercentile()
        {
            AssertPercentile("Minor spell storing", 8, 10);
        }

        [Test]
        public void InvisibilityPercentile()
        {
            AssertPercentile("Invisibility", 11, 15);
        }

        [Test]
        public void WizardryIPercentile()
        {
            AssertPercentile("Wizardry (I)", 16, 19);
        }

        [Test]
        public void EvasionPercentile()
        {
            AssertPercentile("Evasion", 20, 25);
        }

        [Test]
        public void XRayVisionPercentile()
        {
            AssertPercentile("X-ray vision", 26, 28);
        }

        [Test]
        public void BlinkingPercentile()
        {
            AssertPercentile("Blinking", 29, 32);
        }

        [Test]
        public void MajorEnergyResistancePercentile()
        {
            AssertPercentile("Major energy resistance", 33, 39);
        }

        [Test]
        public void ProtectionPlus4Percentile()
        {
            AssertPercentile("Protection +4", 40, 49);
        }

        [Test]
        public void WizardryIIPercentile()
        {
            AssertPercentile("Wizardry (II)", 50, 55);
        }

        [Test]
        public void FreedomOfMovementPercentile()
        {
            AssertPercentile("Freedom of movement", 56, 60);
        }

        [Test]
        public void GreaterEnergyResistancePercentile()
        {
            AssertPercentile("Greater energy resistance", 61, 63);
        }

        [Test]
        public void FriendShieldPercentile()
        {
            AssertPercentile("Friend shield (pair)", 64, 65);
        }

        [Test]
        public void ProtectionPlus5Percentile()
        {
            AssertPercentile("Protection +5", 66, 70);
        }

        [Test]
        public void ShootingStarsPercentile()
        {
            AssertPercentile("Shooting stars", 71, 74);
        }

        [Test]
        public void SpellStoringPercentile()
        {
            AssertPercentile("Spell storing", 75, 79);
        }

        [Test]
        public void WizardryIIIPercentile()
        {
            AssertPercentile("Wizardry (III)", 80, 83);
        }

        [Test]
        public void TelekinesisPercentile()
        {
            AssertPercentile("Telekinesis", 84, 86);
        }

        [Test]
        public void RegenerationPercentile()
        {
            AssertPercentile("Regeneration", 87, 88);
        }

        [Test]
        public void ThreeWishesPercentile()
        {
            AssertPercentile("Three wishes", 89);
        }

        [Test]
        public void SpellTurningPercentile()
        {
            AssertPercentile("Spell turning", 90, 92);
        }

        [Test]
        public void WizardryIVPercentile()
        {
            AssertPercentile("Wizardry (IV)", 93, 94);
        }

        [Test]
        public void DjinniCallingPercentile()
        {
            AssertPercentile("Djinni calling", 95);
        }

        [Test]
        public void ElementalCommandAirPercentile()
        {
            AssertPercentile("Elemental command (air)", 96);
        }

        [Test]
        public void ElementalCommandEarthPercentile()
        {
            AssertPercentile("Elemental command (earth)", 97);
        }

        [Test]
        public void ElementalCommandFirePercentile()
        {
            AssertPercentile("Elemental command (fire)", 98);
        }

        [Test]
        public void ElementalCommandWaterPercentile()
        {
            AssertPercentile("Elemental command (water)", 99);
        }

        [Test]
        public void MajorSpellStoringPercentile()
        {
            AssertPercentile("Major spell storing", 100);
        }
    }
}