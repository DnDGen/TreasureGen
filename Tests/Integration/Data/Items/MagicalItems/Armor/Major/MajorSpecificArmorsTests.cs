using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Major
{
    [TestFixture, PercentileTable("MajorSpecificArmors")]
    public class MajorSpecificArmorsTests : PercentileTests
    {
        [Test]
        public void AdamantineBreastplatePercentile()
        {
            AssertPercentile("Adamantine breastplate", 1, 10);
        }

        [Test]
        public void DwarvenPlatePercentile()
        {
            AssertPercentile("Dwarven plate", 11, 20);
        }

        [Test]
        public void BandedMailOfLuckPercentile()
        {
            AssertPercentile("Banded mail of luck", 21, 32);
        }

        [Test]
        public void CelestialArmorPercentile()
        {
            AssertPercentile("Celestial armor", 33, 50);
        }

        [Test]
        public void PlateArmorOfTheDeepPercentile()
        {
            AssertPercentile("Plate armor of the deep", 51, 60);
        }

        [Test]
        public void BreastplateOfCommandPercentile()
        {
            AssertPercentile("Breastplate of command", 61, 75);
        }

        [Test]
        public void MithralFullPlateOfSpeedPercentile()
        {
            AssertPercentile("Mithral full plate of speed", 76, 90);
        }

        [Test]
        public void DemonArmorPercentile()
        {
            AssertPercentile("Demon armor", 91, 100);
        }
    }
}