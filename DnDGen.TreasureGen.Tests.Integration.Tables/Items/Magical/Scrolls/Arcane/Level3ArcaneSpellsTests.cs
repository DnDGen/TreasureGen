using NUnit.Framework;
using DnDGen.TreasureGen.Tables;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level3ArcaneSpellsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 3, "Arcane"); }
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

        [TestCase("Arcane sight", 1, 2)]
        [TestCase("Blink", 3, 4)]
        [TestCase("Clairaudience/clairvoyance", 5, 6)]
        [TestCase("Daylight", 8, 10)]
        [TestCase("Deep slumber", 11, 12)]
        [TestCase("Dispel magic", 13, 15)]
        [TestCase("Displacement", 16, 17)]
        [TestCase("Fireball", 19, 20)]
        [TestCase("Flame arrow", 21, 22)]
        [TestCase("Fly", 23, 25)]
        [TestCase("Gaseous form", 26, 27)]
        [TestCase("Gentle repose", 28, 29)]
        [TestCase("Halt undead", 32, 33)]
        [TestCase("Haste", 34, 36)]
        [TestCase("Heroism", 37, 38)]
        [TestCase("Hold person", 39, 40)]
        [TestCase("Invisibility sphere", 42, 44)]
        [TestCase("Keen edge", 45, 47)]
        [TestCase("Leomund's tiny hut", 48, 49)]
        [TestCase("Lightning bolt", 50, 51)]
        [TestCase("Magic circle against chaos/evil/good/law", 52, 59)]
        [TestCase("Greater magic weapon", 60, 62)]
        [TestCase("Major image", 63, 64)]
        [TestCase("Nondetection", 65, 66)]
        [TestCase("Phantom steed", 67, 68)]
        [TestCase("Protection from energy", 69, 71)]
        [TestCase("Rage", 72, 73)]
        [TestCase("Ray of exhaustion", 74, 75)]
        [TestCase("Sleet storm", 80, 81)]
        [TestCase("Slow", 82, 83)]
        [TestCase("Stinking cloud", 85, 86)]
        [TestCase("Suggestion", 87, 88)]
        [TestCase("Summon monster III", 89, 90)]
        [TestCase("Tongues", 91, 93)]
        [TestCase("Vampiric touch", 94, 95)]
        [TestCase("Water breathing", 96, 98)]
        [TestCase("Wind wall", 99, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Cure serious wounds", 7)]
        [TestCase("Explosive runes", 18)]
        [TestCase("Glibness", 30)]
        [TestCase("Good hope", 31)]
        [TestCase("Illusory script", 41)]
        [TestCase("Sculpt sound", 76)]
        [TestCase("Secret page", 77)]
        [TestCase("Sepia snake sigil", 78)]
        [TestCase("Shrink item", 79)]
        [TestCase("Speak with animals", 84)]
        public override void Percentile(string content, int roll)
        {
            base.Percentile(content, roll);
        }
    }
}