using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Rings
{
    [TestFixture, PercentileTable("MinorRings")]
    public class MinorRingsTests : PercentileTests
    {
        [Test]
        public void ProtectionPlus1Percentile()
        {
            AssertContent("Protection +1", 1, 18);
        }

        [Test]
        public void FeatherFallingPercentile()
        {
            AssertContent("Feather falling", 19, 28);
        }

        [Test]
        public void SustenancePercentile()
        {
            AssertContent("Sustenance", 29, 36);
        }

        [Test]
        public void ClimbingPercentile()
        {
            AssertContent("Climbing", 37, 44);
        }

        [Test]
        public void JumpingPercentile()
        {
            AssertContent("Jumping", 45, 52);
        }

        [Test]
        public void SwimmingPercentile()
        {
            AssertContent("Swimming", 53, 60);
        }

        [Test]
        public void CounterspellsPercentile()
        {
            AssertContent("Counterspells", 61, 70);
        }

        [Test]
        public void MindShieldingPercentile()
        {
            AssertContent("Mind shielding", 71, 75);
        }

        [Test]
        public void ProtectionPlus2Percentile()
        {
            AssertContent("Protection +2", 76, 80);
        }

        [Test]
        public void ForceShieldPercentile()
        {
            AssertContent("Force shield", 81, 85);
        }

        [Test]
        public void RamPercentile()
        {
            AssertContent("Ram", 86, 90);
        }

        [Test]
        public void AnimalFriendshipPercentile()
        {
            AssertContent("Animal friendship", 91, 93);
        }

        [Test]
        public void MinorEnergyResistancePercentile()
        {
            AssertContent("Minor energy resistance", 94, 96);
        }

        [Test]
        public void ChameleonPowerPercentile()
        {
            AssertContent("Chameleon power", 97, 98);
        }

        [Test]
        public void WaterWalkingPercentile()
        {
            AssertContent("Water walking", 99, 100);
        }
    }
}