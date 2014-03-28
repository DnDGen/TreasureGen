using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Rings
{
    [TestFixture, PercentileTable("MinorRings")]
    public class MinorRingsTests : PercentileTests
    {
        [Test]
        public void ProtectionPlus1Percentile()
        {
            AssertPercentile("Protection +1", 1, 18);
        }

        [Test]
        public void FeatherFallingPercentile()
        {
            AssertPercentile("Feather falling", 19, 28);
        }

        [Test]
        public void SustenancePercentile()
        {
            AssertPercentile("Sustenance", 29, 36);
        }

        [Test]
        public void ClimbingPercentile()
        {
            AssertPercentile("Climbing", 37, 44);
        }

        [Test]
        public void JumpingPercentile()
        {
            AssertPercentile("Jumping", 45, 52);
        }

        [Test]
        public void SwimmingPercentile()
        {
            AssertPercentile("Swimming", 53, 60);
        }

        [Test]
        public void CounterspellsPercentile()
        {
            AssertPercentile("Counterspells", 61, 70);
        }

        [Test]
        public void MindShieldingPercentile()
        {
            AssertPercentile("Mind shielding", 71, 75);
        }

        [Test]
        public void ProtectionPlus2Percentile()
        {
            AssertPercentile("Protection +2", 76, 80);
        }

        [Test]
        public void ForceShieldPercentile()
        {
            AssertPercentile("Force shield", 81, 85);
        }

        [Test]
        public void RamPercentile()
        {
            AssertPercentile("Ram", 86, 90);
        }

        [Test]
        public void AnimalFriendshipPercentile()
        {
            AssertPercentile("Animal friendship", 91, 93);
        }

        [Test]
        public void MinorEnergyResistancePercentile()
        {
            AssertPercentile("Minor energy resistance", 94, 96);
        }

        [Test]
        public void ChameleonPowerPercentile()
        {
            AssertPercentile("Chameleon power", 97, 98);
        }

        [Test]
        public void WaterWalkingPercentile()
        {
            AssertPercentile("Water walking", 99, 100);
        }
    }
}