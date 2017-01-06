using NUnit.Framework;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level9ArcaneSpellsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 9, "Arcane"); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
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
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Wish", 100)]
        public override void Percentile(string content, int roll)
        {
            base.Percentile(content, roll);
        }
    }
}