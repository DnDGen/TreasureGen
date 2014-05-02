using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class MajorRingsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MajorRings"; }
        }

        [TestCase("Minor ENERGY resistance", 0, 1, 2)]
        [TestCase("Protection", 3, 3, 7)]
        [TestCase("Minor spell storing", 0, 8, 10)]
        [TestCase("Invisibility", 0, 11, 15)]
        [TestCase("Wizardry (I)", 0, 16, 19)]
        [TestCase("Evasion", 0, 20, 25)]
        [TestCase("X-ray vision", 0, 26, 28)]
        [TestCase("Blinking", 0, 29, 32)]
        [TestCase("Major ENERGY resistance", 0, 33, 39)]
        [TestCase("Protection", 4, 40, 49)]
        [TestCase("Wizardry (II)", 0, 50, 55)]
        [TestCase("Freedom of movement", 0, 56, 60)]
        [TestCase("Greater ENERGY resistance", 0, 61, 63)]
        [TestCase("Friend shield (pair)", 0, 64, 65)]
        [TestCase("Protection", 5, 66, 70)]
        [TestCase("Shooting stars", 0, 71, 74)]
        [TestCase("Spell storing", 0, 75, 79)]
        [TestCase("Wizardry (III)", 0, 80, 83)]
        [TestCase("Telekinesis", 0, 84, 86)]
        [TestCase("Regeneration", 0, 87, 88)]
        [TestCase("Spell turning", 0, 90, 92)]
        [TestCase("Wizardry (IV)", 0, 93, 94)]
        public void Percentile(String name, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", name, bonus);
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Three wishes", 0, 89)]
        [TestCase("Djinni calling", 0, 95)]
        [TestCase("Elemental command (air)", 0, 96)]
        [TestCase("Elemental command (earth)", 0, 97)]
        [TestCase("Elemental command (fire)", 0, 98)]
        [TestCase("Elemental command (water)", 0, 99)]
        [TestCase("Major spell storing", 0, 100)]
        public void Percentile(String name, Int32 bonus, Int32 roll)
        {
            var content = String.Format("{0},{1}", name, bonus);
            AssertPercentile(content, roll);
        }
    }
}