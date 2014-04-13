using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level5ArcaneSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level5ArcaneSpells"; }
        }

        [TestCase("Animal growth", 1, 2)]
        [TestCase("Baleful polymorph", 3, 5)]
        [TestCase("Bigby's interposing hand", 6, 7)]
        [TestCase("Blight", 8, 9)]
        [TestCase("Break enchantment", 10, 12)]
        [TestCase("Cloudkill", 13, 14)]
        [TestCase("Cone of cold", 15, 17)]
        [TestCase("Contact other plane", 18, 19)]
        [TestCase("Dismissal", 21, 23)]
        [TestCase("Greater dispel magic", 24, 26)]
        [TestCase("Dominate person", 27, 28)]
        [TestCase("Fabricate", 30, 31)]
        [TestCase("False vision", 32, 33)]
        [TestCase("Feeblemind", 34, 35)]
        [TestCase("Hold monster", 36, 39)]
        [TestCase("Major creation", 42, 43)]
        [TestCase("Mind fog", 44, 45)]
        [TestCase("Mirage arcana", 46, 47)]
        [TestCase("Mordenkainen's faithful hound", 48, 49)]
        [TestCase("Mordenkainen's private sanctum", 50, 51)]
        [TestCase("Nightmare", 52, 53)]
        [TestCase("Overland flight", 54, 57)]
        [TestCase("Passwall", 58, 60)]
        [TestCase("Persistent image", 62, 63)]
        [TestCase("Lesser planar binding", 64, 65)]
        [TestCase("Prying eyes", 66, 67)]
        [TestCase("Rary's telepathic bond", 68, 69)]
        [TestCase("Seeming", 70, 71)]
        [TestCase("Sending", 72, 74)]
        [TestCase("Shadow evocation", 75, 76)]
        [TestCase("Summon monster V", 78, 79)]
        [TestCase("Telekinesis", 82, 83)]
        [TestCase("Teleport", 84, 88)]
        [TestCase("Transmute mud to rock", 89, 90)]
        [TestCase("Transmute rock to mud", 91, 92)]
        [TestCase("Wall of force", 93, 95)]
        [TestCase("Wall of stone", 96, 98)]
        [TestCase("Waves of fatigue", 99, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Mass cure light wounds", 20)]
        [TestCase("Dream", 29)]
        [TestCase("Leomund's secret chest", 40)]
        [TestCase("Magic jar", 41)]
        [TestCase("Permanency", 61)]
        [TestCase("Song of discord", 77)]
        [TestCase("Symbol of pain", 80)]
        [TestCase("Symbol of sleep", 81)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}