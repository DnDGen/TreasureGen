using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Rings
{
    [TestFixture, PercentileTable("MediumRings")]
    public class MediumRingsTests : PercentileTests
    {
        [Test]
        public void CounterspellsPercentile()
        {
            AssertContent("Counterspells", 1, 5);
        }

        [Test]
        public void MindShieldingPercentile()
        {
            AssertContent("Mind shielding", 6, 8);
        }

        [Test]
        public void ProtectionPlus2Percentile()
        {
            AssertContent("Protection +2", 9, 18);
        }

        [Test]
        public void ForceShieldPercentile()
        {
            AssertContent("Force shield", 19, 23);
        }

        [Test]
        public void RamPercentile()
        {
            AssertContent("Ram", 24, 28);
        }

        [Test]
        public void ImprovedClimbingPercentile()
        {
            AssertContent("Improved climbing", 29, 34);
        }

        [Test]
        public void ImprovedJumpingPercentile()
        {
            AssertContent("Improved jumping", 35, 40);
        }

        [Test]
        public void ImprovedSwimmingPercentile()
        {
            AssertContent("Improved swimming", 41, 46);
        }

        [Test]
        public void AnimalFriendshipPercentile()
        {
            AssertContent("Animal friendship", 47, 51);
        }

        [Test]
        public void MinorEnergyResistancePercentile()
        {
            AssertContent("Minor energy resistance", 52, 56);
        }

        [Test]
        public void ChameleonPowerPercentile()
        {
            AssertContent("Chameleon power", 57, 61);
        }

        [Test]
        public void WaterWalkingPercentile()
        {
            AssertContent("Water walking", 62, 66);
        }

        [Test]
        public void ProtectionPlus3Percentile()
        {
            AssertContent("Protection +3", 67, 71);
        }

        [Test]
        public void MinorSpellStoringPercentile()
        {
            AssertContent("Minor spell storing", 72, 76);
        }

        [Test]
        public void InvisibilityPercentile()
        {
            AssertContent("Invisibility", 77, 81);
        }

        [Test]
        public void WizardryIPercentile()
        {
            AssertContent("Wizardry (I)", 82, 85);
        }

        [Test]
        public void EvasionPercentile()
        {
            AssertContent("Evasion", 86, 90);
        }

        [Test]
        public void XRayVisionPercentile()
        {
            AssertContent("X-ray vision", 91, 93);
        }

        [Test]
        public void BlinkingPercentile()
        {
            AssertContent("Blinking", 94, 97);
        }

        [Test]
        public void MajorEnergyResistancePercentile()
        {
            AssertContent("Major energy resistance", 98, 100);
        }
    }
}