using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, PercentileTable("Tools")]
    public class ToolsTests : PercentileTests
    {
        [Test]
        public void EmptyBackpackPercentile()
        {
            AssertPercentile("Empty backpack", 1, 3);
        }

        [Test]
        public void CrowbarPercentile()
        {
            AssertPercentile("Crowbar", 4, 6);
        }

        [Test]
        public void BullseyeLanternPercentile()
        {
            AssertPercentile("Bullseye lantern", 7, 11);
        }

        [Test]
        public void SimpleLockPercentile()
        {
            AssertPercentile("Simple lock", 12, 16);
        }

        [Test]
        public void AverageLockPercentile()
        {
            AssertPercentile("Average lock", 17, 21);
        }

        [Test]
        public void GoodLockPercentile()
        {
            AssertPercentile("Good lock", 22, 28);
        }

        [Test]
        public void SuperiorLockPercentile()
        {
            AssertPercentile("Superior lock", 29, 35);
        }

        [Test]
        public void MasterworkManaclesPercentile()
        {
            AssertPercentile("Masterwork manacles", 36, 40);
        }

        [Test]
        public void SmallSteelMirrorPercentile()
        {
            AssertPercentile("Small steel mirror", 41, 43);
        }

        [Test]
        public void SilkRopePercentile()
        {
            AssertPercentile("Silk rope (50')", 44, 46);
        }

        [Test]
        public void SpyglassPercentile()
        {
            AssertPercentile("Spyglass", 47, 53);
        }

        [Test]
        public void MasterworkArtisansToolsPercentile()
        {
            AssertPercentile("Masterwork artisan's tools", 54, 58);
        }

        [Test]
        public void ClimbersKitPercentile()
        {
            AssertPercentile("Climber's kit", 59, 63);
        }

        [Test]
        public void DisguiseKitPercentile()
        {
            AssertPercentile("Disguise kit", 64, 68);
        }

        [Test]
        public void HealersKitPercentile()
        {
            AssertPercentile("Healer's kit", 69, 73);
        }

        [Test]
        public void SilverHolySymbolPercentile()
        {
            AssertPercentile("Silver holy symbol", 74, 77);
        }

        [Test]
        public void HourglassPercentile()
        {
            AssertPercentile("Hourglass", 78, 81);
        }

        [Test]
        public void MagnifyingGlassPercentile()
        {
            AssertPercentile("Magnifying glass", 82, 88);
        }

        [Test]
        public void MasterworkMusicalInstrumentPercentile()
        {
            AssertPercentile("Masterwork musical instrument", 89, 95);
        }

        [Test]
        public void MasterworkThievesToolsPercentile()
        {
            AssertPercentile("Masterwork thieves' tools", 96, 100);
        }
    }
}