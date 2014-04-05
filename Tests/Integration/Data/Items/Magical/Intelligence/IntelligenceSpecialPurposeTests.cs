using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceSpecialPurposeTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "IntelligenceSpecialPurposes";
        }

        [TestCase("Defeat/slay diametrically opposed alignment", 1, 20)]
        [TestCase("Defeat/slay arcane spellcasters (including spellcasting monsters and those that use spell-like abilities)", 21, 30)]
        [TestCase("Defeat/slay divine spellcasters (including divine entities and servitors)", 31, 40)]
        [TestCase("Defeat/slay nonspellcasters", 41, 50)]
        [TestCase("Defeat/slay DesignatedFoe", 51, 60)]
        [TestCase("Defend DesignatedFoe", 61, 70)]
        [TestCase("Defeat/slay the servants of a specific diety", 71, 80)]
        [TestCase("Defend the servants of a specific diety", 81, 90)]
        [TestCase("Defeat/slay all (other than the item and the wielder)", 91, 95)]
        [TestCase("Defend arcane spellcasters", 96, 97)]
        [TestCase("Defend divine spellcasters", 98, 99)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Defend nonspellcasters", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}