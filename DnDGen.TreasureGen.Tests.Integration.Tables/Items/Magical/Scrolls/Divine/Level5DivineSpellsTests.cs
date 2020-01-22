using NUnit.Framework;
using DnDGen.TreasureGen.Tables;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Divine
{
    [TestFixture]
    public class Level5DivineSpellsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 5, "Divine"); }
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

        [TestCase("Animal growth", 1, 3)]
        [TestCase("Atonement", 4, 5)]
        [TestCase("Baleful polymorph", 7, 9)]
        [TestCase("Break enchantment", 10, 13)]
        [TestCase("Call lightning storm", 14, 16)]
        [TestCase("Greater command", 17, 20)]
        [TestCase("Control winds", 23, 24)]
        [TestCase("Mass cure light wounds", 25, 30)]
        [TestCase("Dispel chaos/evil/good/law", 31, 34)]
        [TestCase("Disrupting weapon", 35, 38)]
        [TestCase("Flame strike", 39, 41)]
        [TestCase("Hallow", 42, 43)]
        [TestCase("Ice storm", 44, 46)]
        [TestCase("Mass inflict light wounds", 47, 49)]
        [TestCase("Insect plague", 50, 52)]
        [TestCase("Plane shift", 54, 56)]
        [TestCase("Raise dead", 57, 58)]
        [TestCase("Righteous might", 59, 61)]
        [TestCase("Scrying", 62, 63)]
        [TestCase("Slay living", 64, 66)]
        [TestCase("Spell resistance", 67, 69)]
        [TestCase("Stoneskin", 70, 71)]
        [TestCase("Summon monster V", 72, 74)]
        [TestCase("Summon nature's ally V", 75, 77)]
        [TestCase("Transmute mud to rock", 80, 82)]
        [TestCase("Transmute rock to mud", 83, 85)]
        [TestCase("True seeing", 86, 89)]
        [TestCase("Unhallow", 90, 91)]
        [TestCase("Wall of fire", 92, 94)]
        [TestCase("Wall of stone", 95, 97)]
        [TestCase("Wall of thorns", 98, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Awaken", 6)]
        [TestCase("Commune", 21)]
        [TestCase("Commune with nature", 22)]
        [TestCase("Mark of justice", 53)]
        [TestCase("Symbol of pain", 78)]
        [TestCase("Symbol of sleep", 79)]
        public override void Percentile(string content, int roll)
        {
            base.Percentile(content, roll);
        }
    }
}