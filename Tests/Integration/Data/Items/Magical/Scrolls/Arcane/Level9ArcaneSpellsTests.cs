using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level9ArcaneSpellsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level9ArcaneSpells";
        }

        [TestCase("Astral projection", 1, 3)]
        [TestCase("Bigby's crushing hand", 4, 7)]
        [TestCase("Dominate monster", 8, 12)]
        [TestCase("Energy drain", 13, 16)]
        [TestCase("Etherealness", 17, 21)]
        [TestCase("Foresight", 22, 25)]
        [TestCase("Freedom", 26, 31)]
        [TestCase("Gate", 32, 36)]
        [TestCase("Mass hold monster", 37, 40)]
        [TestCase("Imprisonment", 41, 44)]
        [TestCase("Meteor swarm", 45, 49)]
        [TestCase("Mordenkainen's disjunction", 50, 53)]
        [TestCase("Power word kill", 54, 58)]
        [TestCase("Prismatic sphere", 59, 62)]
        [TestCase("Refuge", 63, 66)]
        [TestCase("Shades", 67, 70)]
        [TestCase("Shapechange", 71, 76)]
        [TestCase("Soul bind", 77, 79)]
        [TestCase("Summon monster IX", 80, 83)]
        [TestCase("Teleportation circle", 84, 86)]
        [TestCase("Time stop", 87, 91)]
        [TestCase("Wail of the banshee", 92, 95)]
        [TestCase("Weird", 96, 99)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Wish", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}