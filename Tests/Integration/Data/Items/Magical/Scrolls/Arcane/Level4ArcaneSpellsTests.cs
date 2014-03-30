using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level4ArcaneSpellsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level4ArcaneSpells";
        }

        [TestCase("Animate dead", 1, 2)]
        [TestCase("Arcane eye", 3, 5)]
        [TestCase("Bestow curse", 6, 7)]
        [TestCase("Charm monster", 8, 10)]
        [TestCase("Confusion", 11, 13)]
        [TestCase("Contagion", 14, 15)]
        [TestCase("Crushing despair", 16, 17)]
        [TestCase("Dimension door", 20, 23)]
        [TestCase("Dimensional anchor", 24, 26)]
        [TestCase("Enervation", 27, 28)]
        [TestCase("Mass enlarge person", 29, 30)]
        [TestCase("Evard's black tentacles", 31, 32)]
        [TestCase("Fear", 33, 34)]
        [TestCase("Fire shield", 35, 37)]
        [TestCase("Fire trap", 38, 39)]
        [TestCase("Freedom of movement", 40, 42)]
        [TestCase("Lesser globe of invulnerability", 44, 46)]
        [TestCase("Hallucinatory terrain", 47, 48)]
        [TestCase("Ice storm", 49, 50)]
        [TestCase("Illusory wall", 51, 52)]
        [TestCase("Greater invisibility", 53, 55)]
        [TestCase("Leomund's secure shelter", 56, 57)]
        [TestCase("Minor creation", 59, 60)]
        [TestCase("Otiluke's resilient sphere", 63, 64)]
        [TestCase("Phantasmal killer", 65, 66)]
        [TestCase("Polymorph", 67, 68)]
        [TestCase("Rainbow pattern", 69, 70)]
        [TestCase("Mass reduce person", 72, 73)]
        [TestCase("Remove curse", 74, 76)]
        [TestCase("Scrying", 78, 79)]
        [TestCase("Shadow conjuration", 80, 81)]
        [TestCase("Shout", 82, 83)]
        [TestCase("Solid fog", 84, 85)]
        [TestCase("Stone shape", 87, 88)]
        [TestCase("Stoneskin", 89, 91)]
        [TestCase("Summon monster IV", 92, 93)]
        [TestCase("Wall of fire", 94, 96)]
        [TestCase("Wall of ice", 97, 99)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Cure critical wounds", 18)]
        [TestCase("Detect scrying", 19)]
        [TestCase("Lesser geas", 43)]
        [TestCase("Locate creature", 58)]
        [TestCase("Modify memory", 61)]
        [TestCase("Neutralize poison", 62)]
        [TestCase("Rary's mnemonic enhancer", 71)]
        [TestCase("Repel vermin", 77)]
        [TestCase("Speak with plants", 86)]
        [TestCase("Zone of silence", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}