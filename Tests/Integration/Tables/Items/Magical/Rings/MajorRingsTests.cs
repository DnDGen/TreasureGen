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

        [TestCase("Minor energy resistance", 1, 2)]
        [TestCase("Protection +3", 3, 7)]
        [TestCase("Minor spell storing", 8, 10)]
        [TestCase("Invisibility", 11, 15)]
        [TestCase("Wizardry (I)", 16, 19)]
        [TestCase("Evasion", 20, 25)]
        [TestCase("X-ray vision", 26, 28)]
        [TestCase("Blinking", 29, 32)]
        [TestCase("Major energy resistance", 33, 39)]
        [TestCase("Protection +4", 40, 49)]
        [TestCase("Wizardry (II)", 50, 55)]
        [TestCase("Freedom of movement", 56, 60)]
        [TestCase("Greater energy resistance", 61, 63)]
        [TestCase("Friend shield (pair)", 64, 65)]
        [TestCase("Protection +5", 66, 70)]
        [TestCase("Shooting stars", 71, 74)]
        [TestCase("Spell storing", 75, 79)]
        [TestCase("Wizardry (III)", 80, 83)]
        [TestCase("Telekinesis", 84, 86)]
        [TestCase("Regeneration", 87, 88)]
        [TestCase("Spell turning", 90, 92)]
        [TestCase("Wizardry (IV)", 93, 94)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Three wishes", 89)]
        [TestCase("Djinni calling", 95)]
        [TestCase("Elemental command (air)", 96)]
        [TestCase("Elemental command (earth)", 97)]
        [TestCase("Elemental command (fire)", 98)]
        [TestCase("Elemental command (water)", 99)]
        [TestCase("Major spell storing", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}