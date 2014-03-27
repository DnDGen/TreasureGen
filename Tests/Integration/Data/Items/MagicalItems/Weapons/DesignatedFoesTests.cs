using System;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons
{
    [TestFixture, PercentileTable("DesignatedFoes")]
    public class DesignatedFoesTests : PercentileTests
    {
        [TestCase("Aquatic-humanoid", 40)]
        [TestCase("Gnoll", 45)]
        [TestCase("Gnome", 46)]
        [TestCase("Halfling", 50)]
        [TestCase("Air-outsider", 73)]
        [TestCase("Earth-outsider", 77)]
        [TestCase("Fire-outsider", 81)]
        [TestCase("Water-outsider", 88)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }

        [TestCase("Aberration", 1, 5)]
        [TestCase("Animal", 6, 9)]
        [TestCase("Construct", 10, 16)]
        [TestCase("Dragon", 17, 22)]
        [TestCase("Elemental", 23, 27)]
        [TestCase("Fey", 28, 32)]
        [TestCase("Giant", 33, 39)]
        [TestCase("Dwarf", 41, 42)]
        [TestCase("Elf", 43, 44)]
        [TestCase("Goblinoid", 47, 49)]
        [TestCase("Human", 51, 54)]
        [TestCase("Reptilian-humanoid", 55, 57)]
        [TestCase("Orc", 58, 60)]
        [TestCase("Magical-beast", 61, 65)]
        [TestCase("Mounstrous-humanoid", 66, 70)]
        [TestCase("Ooze", 71, 72)]
        [TestCase("Chaotic-outsider", 74, 76)]
        [TestCase("Evil-outsider", 78, 80)]
        [TestCase("Good-outsider", 82, 84)]
        [TestCase("Lawful-outsider", 85, 87)]
        [TestCase("Plant", 89, 90)]
        [TestCase("Undead", 91, 98)]
        [TestCase("Vermin", 99, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}