using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor
{
    [TestFixture, PercentileTable("MajorSpecificArmors")]
    public class MajorSpecificArmorsTests : PercentileTests
    {
        [Test]
        public void AdamantineBreastplatePercentile()
        {
            AssertContent("Adamantine breastplate", 1, 10);
        }

        [Test]
        public void DwarvenPlatePercentile()
        {
            AssertContent("Dwarven plate", 11, 20);
        }

        [Test]
        public void BandedMailOfLuckPercentile()
        {
            AssertContent("Banded mail of luck", 21, 32);
        }

        [Test]
        public void CelestialArmorPercentile()
        {
            AssertContent("Celestial armor", 33, 50);
        }

        [Test]
        public void PlateArmorOfTheDeepPercentile()
        {
            AssertContent("Plate armor of the deep", 51, 60);
        }

        [Test]
        public void BreastplateOfCommandPercentile()
        {
            AssertContent("Breastplate of command", 61, 75);
        }

        [Test]
        public void MithralFullPlateOfSpeedPercentile()
        {
            AssertContent("Mithral full plate of speed", 76, 90);
        }

        [Test]
        public void DemonArmorPercentile()
        {
            AssertContent("Demon armor", 91, 100);
        }
    }
}