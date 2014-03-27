using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Rings
{
    [TestFixture, PercentileTable("MediumRings")]
    public class MediumRingsTests : PercentileTests
    {
        [Test]
        public void CounterspellsPercentile()
        {
            AssertPercentile("Counterspells", 1, 5);
        }

        [Test]
        public void MindShieldingPercentile()
        {
            AssertPercentile("Mind shielding", 6, 8);
        }

        [Test]
        public void ProtectionPlus2Percentile()
        {
            AssertPercentile("Protection +2", 9, 18);
        }

        [Test]
        public void ForceShieldPercentile()
        {
            AssertPercentile("Force shield", 19, 23);
        }

        [Test]
        public void RamPercentile()
        {
            AssertPercentile("Ram", 24, 28);
        }

        [Test]
        public void ImprovedClimbingPercentile()
        {
            AssertPercentile("Improved climbing", 29, 34);
        }

        [Test]
        public void ImprovedJumpingPercentile()
        {
            AssertPercentile("Improved jumping", 35, 40);
        }

        [Test]
        public void ImprovedSwimmingPercentile()
        {
            AssertPercentile("Improved swimming", 41, 46);
        }

        [Test]
        public void AnimalFriendshipPercentile()
        {
            AssertPercentile("Animal friendship", 47, 51);
        }

        [Test]
        public void MinorEnergyResistancePercentile()
        {
            AssertPercentile("Minor energy resistance", 52, 56);
        }

        [Test]
        public void ChameleonPowerPercentile()
        {
            AssertPercentile("Chameleon power", 57, 61);
        }

        [Test]
        public void WaterWalkingPercentile()
        {
            AssertPercentile("Water walking", 62, 66);
        }

        [Test]
        public void ProtectionPlus3Percentile()
        {
            AssertPercentile("Protection +3", 67, 71);
        }

        [Test]
        public void MinorSpellStoringPercentile()
        {
            AssertPercentile("Minor spell storing", 72, 76);
        }

        [Test]
        public void InvisibilityPercentile()
        {
            AssertPercentile("Invisibility", 77, 81);
        }

        [Test]
        public void WizardryIPercentile()
        {
            AssertPercentile("Wizardry (I)", 82, 85);
        }

        [Test]
        public void EvasionPercentile()
        {
            AssertPercentile("Evasion", 86, 90);
        }

        [Test]
        public void XRayVisionPercentile()
        {
            AssertPercentile("X-ray vision", 91, 93);
        }

        [Test]
        public void BlinkingPercentile()
        {
            AssertPercentile("Blinking", 94, 97);
        }

        [Test]
        public void MajorEnergyResistancePercentile()
        {
            AssertPercentile("Major energy resistance", 98, 100);
        }
    }
}