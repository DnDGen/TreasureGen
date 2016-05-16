using System;
using TreasureGen.Domain.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Divine
{
    [TestFixture]
    public class Level6DivineSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 6, "Divine"); }
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

        [TestCase("Animate objects", 1, 3)]
        [TestCase("Antilife shell", 4, 6)]
        [TestCase("Banishment", 7, 9)]
        [TestCase("Mass bear's endurance", 10, 13)]
        [TestCase("Blade barrier", 14, 16)]
        [TestCase("Mass bull's strength", 17, 20)]
        [TestCase("Mass cat's grace", 21, 24)]
        [TestCase("Mass cure moderate wounds", 26, 29)]
        [TestCase("Greater dispel magic", 30, 33)]
        [TestCase("Mass eagle's splendor", 34, 37)]
        [TestCase("Find the path", 38, 40)]
        [TestCase("Fire seeds", 41, 43)]
        [TestCase("Harm", 47, 49)]
        [TestCase("Heal", 50, 52)]
        [TestCase("Heroes' feast", 53, 55)]
        [TestCase("Mass inflict moderate wounds", 56, 58)]
        [TestCase("Ironwood", 59, 61)]
        [TestCase("Move earth", 63, 65)]
        [TestCase("Mass owl's wisdom", 66, 69)]
        [TestCase("Planar ally", 70, 71)]
        [TestCase("Repel wood", 72, 74)]
        [TestCase("Spellstaff", 75, 77)]
        [TestCase("Stone tell", 78, 80)]
        [TestCase("Summon monster VI", 81, 83)]
        [TestCase("Summon nature's ally VI", 84, 86)]
        [TestCase("Transport via plants", 89, 91)]
        [TestCase("Undeath to death", 92, 94)]
        [TestCase("Windwalk", 95, 97)]
        [TestCase("Word of recall", 98, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Create undead", 25)]
        [TestCase("Forbiddance", 44)]
        [TestCase("Geas/quest", 45)]
        [TestCase("Greater glyph of warding", 46)]
        [TestCase("Liveoak", 62)]
        [TestCase("Symbol of fear", 87)]
        [TestCase("Symbol of persuasion", 88)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}