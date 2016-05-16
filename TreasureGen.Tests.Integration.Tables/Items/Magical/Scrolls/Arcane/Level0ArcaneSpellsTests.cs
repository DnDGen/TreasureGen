using System;
using TreasureGen.Domain.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level0ArcaneSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 0, "Arcane"); }
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

        [TestCase("Acid splash", 1, 4)]
        [TestCase("Arcane mark", 5, 8)]
        [TestCase("Dancing lights", 9, 13)]
        [TestCase("Daze", 14, 17)]
        [TestCase("Detect magic", 18, 24)]
        [TestCase("Detect poison", 25, 28)]
        [TestCase("Disrupt undead", 29, 32)]
        [TestCase("Flare", 33, 37)]
        [TestCase("Ghost sound", 38, 42)]
        [TestCase("Know direction", 43, 44)]
        [TestCase("Light", 45, 50)]
        [TestCase("Lullaby", 51, 52)]
        [TestCase("Mage hand", 53, 57)]
        [TestCase("Mending", 58, 62)]
        [TestCase("Message", 63, 67)]
        [TestCase("Open/close", 68, 72)]
        [TestCase("Prestidigitation", 73, 77)]
        [TestCase("Ray of frost", 78, 81)]
        [TestCase("Read magic", 82, 87)]
        [TestCase("Resistance", 88, 94)]
        [TestCase("Summon instrument", 95, 96)]
        [TestCase("Touch of fatigue", 97, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}