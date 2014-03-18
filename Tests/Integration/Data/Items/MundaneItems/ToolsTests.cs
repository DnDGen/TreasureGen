using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, PercentileTable("Tools")]
    public class ToolsTests : PercentileTests
    {
        [Test]
        public void EmptyBackpackPercentile()
        {
            AssertContent("Empty backpack", 1, 3);
        }

        [Test]
        public void CrowbarPercentile()
        {
            AssertContent("Crowbar", 4, 6);
        }

        [Test]
        public void BullseyeLanternPercentile()
        {
            AssertContent("Bullseye lantern", 7, 11);
        }

        [Test]
        public void SimpleLockPercentile()
        {
            AssertContent("Simple lock", 12, 16);
        }

        [Test]
        public void AverageLockPercentile()
        {
            AssertContent("Average lock", 17, 21);
        }

        [Test]
        public void GoodLockPercentile()
        {
            AssertContent("Good lock", 22, 28);
        }

        [Test]
        public void SuperiorLockPercentile()
        {
            AssertContent("Superior lock", 29, 35);
        }

        [Test]
        public void MasterworkManaclesPercentile()
        {
            AssertContent("Masterwork manacles", 36, 40);
        }

        [Test]
        public void SmallSteelMirrorPercentile()
        {
            AssertContent("Small steel mirror", 41, 43);
        }

        [Test]
        public void SilkRopePercentile()
        {
            AssertContent("Silk rope (50')", 44, 46);
        }

        [Test]
        public void SpyglassPercentile()
        {
            AssertContent("Spyglass", 47, 53);
        }

        [Test]
        public void MasterworkArtisansToolsPercentile()
        {
            AssertContent("Masterwork artisan's tools", 54, 58);
        }

        [Test]
        public void ClimbersKitPercentile()
        {
            AssertContent("Climber's kit", 59, 63);
        }

        [Test]
        public void DisguiseKitPercentile()
        {
            AssertContent("Disguise kit", 64, 68);
        }

        [Test]
        public void HealersKitPercentile()
        {
            AssertContent("Healer's kit", 69, 73);
        }

        [Test]
        public void SilverHolySymbolPercentile()
        {
            AssertContent("Silver holy symbol", 74, 77);
        }

        [Test]
        public void HourglassPercentile()
        {
            AssertContent("Hourglass", 78, 81);
        }

        [Test]
        public void MagnifyingGlassPercentile()
        {
            AssertContent("Magnifying glass", 82, 88);
        }

        [Test]
        public void MasterworkMusicalInstrumentPercentile()
        {
            AssertContent("Masterwork musical instrument", 89, 95);
        }

        [Test]
        public void MasterworkThievesToolsPercentile()
        {
            AssertContent("Masterwork thieves' tools", 96, 100);
        }
    }
}