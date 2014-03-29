using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Major
{
    [TestFixture]
    public class MajorSpecificArmorsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MajorSpecificArmors";
        }

        [TestCase("Adamantine breastplate", 1, 10)]
        [TestCase("Dwarven plate", 11, 20)]
        [TestCase("Banded mail of luck", 21, 32)]
        [TestCase("Celestial armor", 33, 50)]
        [TestCase("Plate armor of the deep", 51, 60)]
        [TestCase("Breastplate of command", 61, 75)]
        [TestCase("Mithral full plate of speed", 76, 90)]
        [TestCase("Demon armor", 91, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}