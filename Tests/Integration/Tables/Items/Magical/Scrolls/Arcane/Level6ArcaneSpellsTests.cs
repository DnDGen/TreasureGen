using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level6ArcaneSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level6ArcaneSpells"; }
        }

        [TestCase("Acid fog", 1, 2)]
        [TestCase("Analyze dweomer", 3, 5)]
        [TestCase("Antimagic field", 7, 9)]
        [TestCase("Mass bear's endurance", 10, 12)]
        [TestCase("Bigby's forceful hand", 13, 14)]
        [TestCase("Mass bull's strength", 15, 17)]
        [TestCase("Mass cat's grace", 18, 20)]
        [TestCase("Chain lightning", 21, 23)]
        [TestCase("Circle of death", 24, 25)]
        [TestCase("Control water", 27, 28)]
        [TestCase("Disintegrate", 31, 33)]
        [TestCase("Greater dispel magic", 34, 37)]
        [TestCase("Mass eagle's splendor", 38, 40)]
        [TestCase("Eyebite", 41, 42)]
        [TestCase("Flesh to stone", 44, 45)]
        [TestCase("Mass fox's cunning", 46, 48)]
        [TestCase("Globe of invulnerability", 50, 52)]
        [TestCase("Greater heroism", 55, 56)]
        [TestCase("Mislead", 58, 59)]
        [TestCase("Move earth", 61, 62)]
        [TestCase("Otiluke's freezing sphere", 63, 64)]
        [TestCase("Mass owl's wisdom", 65, 67)]
        [TestCase("Permanent image", 68, 69)]
        [TestCase("Planar binding", 70, 71)]
        [TestCase("Programmed image", 72, 73)]
        [TestCase("Repulsion", 74, 75)]
        [TestCase("Shadow walk", 76, 78)]
        [TestCase("Stone to flesh", 79, 81)]
        [TestCase("Mass suggestion", 82, 83)]
        [TestCase("Summon monster VI", 84, 85)]
        [TestCase("Tenser's transformation", 89, 90)]
        [TestCase("True seeing", 91, 93)]
        [TestCase("Undeath to death", 94, 95)]
        [TestCase("Veil", 96, 97)]
        [TestCase("Wall of iron", 98, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Animate objects", 6)]
        [TestCase("Contingency", 26)]
        [TestCase("Create undead", 29)]
        [TestCase("Mass cure moderate wounds", 30)]
        [TestCase("Find the path", 43)]
        [TestCase("Geas/quest", 49)]
        [TestCase("Guards and wards", 53)]
        [TestCase("Heroes' feast", 54)]
        [TestCase("Legend lore", 57)]
        [TestCase("Mordenkainen's lubrication", 60)]
        [TestCase("Symbol of fear", 86)]
        [TestCase("Symbol of persuasion", 87)]
        [TestCase("Sympathetic vibration", 88)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}