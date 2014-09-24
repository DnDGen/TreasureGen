using System;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Divine
{
    [TestFixture]
    public class Level3DivineSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 3, "Divine"); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Animate dead", 1, 2)]
        [TestCase("Bestow curse", 3, 4)]
        [TestCase("Blindness/deafness", 5, 6)]
        [TestCase("Call lightning", 7, 8)]
        [TestCase("Contagion", 9, 10)]
        [TestCase("Continual flame", 11, 12)]
        [TestCase("Create food and water", 13, 14)]
        [TestCase("Cure serious wounds", 15, 18)]
        [TestCase("Daylight", 20, 21)]
        [TestCase("Deeper darkness", 22, 23)]
        [TestCase("Diminish plants", 24, 25)]
        [TestCase("Dispel magic", 26, 27)]
        [TestCase("Dominate animal", 28, 29)]
        [TestCase("Glyph of warding", 30, 31)]
        [TestCase("Helping hand", 33, 34)]
        [TestCase("Inflict serious wounds", 35, 36)]
        [TestCase("Invisibility purge", 37, 38)]
        [TestCase("Locate object", 39, 40)]
        [TestCase("Magic circle against chaos/evil/good/law", 41, 46)]
        [TestCase("Greater magic fang", 47, 48)]
        [TestCase("Magic vestment", 49, 50)]
        [TestCase("Meld into stone", 51, 52)]
        [TestCase("Neutralize poison", 53, 55)]
        [TestCase("Obscure object", 56, 57)]
        [TestCase("Plant growth", 58, 59)]
        [TestCase("Prayer", 60, 62)]
        [TestCase("Protection from energy", 63, 64)]
        [TestCase("Quench", 65, 66)]
        [TestCase("Remove blindness/deafness", 67, 69)]
        [TestCase("Remove curse", 70, 71)]
        [TestCase("Remove disease", 72, 73)]
        [TestCase("Searing light", 74, 76)]
        [TestCase("Sleet storm", 77, 78)]
        [TestCase("Snare", 79, 80)]
        [TestCase("Speak with dead", 81, 83)]
        [TestCase("Speak with plants", 84, 85)]
        [TestCase("Spike growth", 86, 87)]
        [TestCase("Stone shape", 88, 89)]
        [TestCase("Summon monster III", 90, 91)]
        [TestCase("Summon nature's ally III", 92, 93)]
        [TestCase("Water breathing", 94, 96)]
        [TestCase("Water walk", 97, 98)]
        [TestCase("Wind wall", 99, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Darkvision", 19)]
        [TestCase("Heal mount", 32)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}