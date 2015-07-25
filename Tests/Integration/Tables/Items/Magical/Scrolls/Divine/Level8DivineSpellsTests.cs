using System;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Divine
{
    [TestFixture]
    public class Level8DivineSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 8, "Divine"); }
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

        [TestCase("Animal shapes", 1, 4)]
        [TestCase("Antimagic field", 5, 10)]
        [TestCase("Cloak of chaos", 11, 13)]
        [TestCase("Control plants", 14, 17)]
        [TestCase("Create greater undead", 18, 20)]
        [TestCase("Mass cure critical wounds", 21, 27)]
        [TestCase("Dimensional lock", 28, 32)]
        [TestCase("Discern location", 33, 36)]
        [TestCase("Earthquake", 37, 41)]
        [TestCase("Finger of death", 42, 45)]
        [TestCase("Firestorm", 46, 49)]
        [TestCase("Holy aura", 50, 52)]
        [TestCase("Mass inflict critical wounds", 53, 56)]
        [TestCase("Greater planar ally", 57, 60)]
        [TestCase("Repel metal or stone", 61, 65)]
        [TestCase("Reverse gravity", 66, 69)]
        [TestCase("Shield of law", 70, 72)]
        [TestCase("Greater spell immunity", 73, 76)]
        [TestCase("Summon monster VIII", 77, 80)]
        [TestCase("Summon nature's ally VIII", 81, 84)]
        [TestCase("Sunburst", 85, 89)]
        [TestCase("Symbol of death", 90, 91)]
        [TestCase("Symbol of insanity", 92, 93)]
        [TestCase("Unholy aura", 94, 96)]
        [TestCase("Whirlwind", 97, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}