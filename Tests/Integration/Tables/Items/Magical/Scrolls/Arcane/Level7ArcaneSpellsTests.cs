using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level7ArcaneSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level7ArcaneSpells"; }
        }

        [TestCase("Greater arcane sight", 1, 3)]
        [TestCase("Banishment", 4, 7)]
        [TestCase("Bigby's grasping hand", 8, 10)]
        [TestCase("Control undead", 11, 13)]
        [TestCase("Control weather", 14, 16)]
        [TestCase("Delayed blast fireball", 17, 19)]
        [TestCase("Drawmij's instant summons", 20, 21)]
        [TestCase("Ethereal jaunt", 22, 25)]
        [TestCase("Finger of death", 26, 28)]
        [TestCase("Forcecage", 29, 31)]
        [TestCase("Mass hold person", 32, 35)]
        [TestCase("Insanity", 36, 38)]
        [TestCase("Mass invisibility", 39, 42)]
        [TestCase("Mordenkainen's magnificent mansion", 44, 45)]
        [TestCase("Mordenkainen's sword", 46, 48)]
        [TestCase("Phase door", 49, 51)]
        [TestCase("Plane shift", 52, 54)]
        [TestCase("Power word blind", 55, 57)]
        [TestCase("Prismatic spray", 58, 61)]
        [TestCase("Project image", 62, 64)]
        [TestCase("Reverse gravity", 65, 67)]
        [TestCase("Greater scrying", 68, 70)]
        [TestCase("Sequester", 71, 73)]
        [TestCase("Greater shadow conjuration", 74, 76)]
        [TestCase("Spell turning", 78, 80)]
        [TestCase("Statue", 81, 82)]
        [TestCase("Summon monster VII", 83, 85)]
        [TestCase("Teleport object", 88, 90)]
        [TestCase("Greater teleport", 91, 95)]
        [TestCase("Vision", 96, 97)]
        [TestCase("Waves of exhaustion", 98, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Limited wish", 43)]
        [TestCase("Simulacrum", 77)]
        [TestCase("Symbol of stunning", 86)]
        [TestCase("Symbol of weakness", 87)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}