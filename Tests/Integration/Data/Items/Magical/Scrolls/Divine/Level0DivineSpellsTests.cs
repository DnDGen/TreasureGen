using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Divine
{
    [TestFixture]
    public class Level0DivineSpellsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level0DivineSpells";
        }

        [TestCase("Create water", 1, 7)]
        [TestCase("Cure minor wounds", 8, 14)]
        [TestCase("Detect magic", 15, 22)]
        [TestCase("Detect poison", 23, 29)]
        [TestCase("Flare", 30, 36)]
        [TestCase("Guidance", 37, 43)]
        [TestCase("Inflict minor wounds", 44, 50)]
        [TestCase("Know direction", 51, 57)]
        [TestCase("Light", 58, 65)]
        [TestCase("Mending", 66, 72)]
        [TestCase("Purify food and drink", 73, 79)]
        [TestCase("Read magic", 80, 86)]
        [TestCase("Resistance", 87, 93)]
        [TestCase("Virtue", 94, 100)]
        public void Level0DivineSpellsPercentile(String spell, Int32 lower, Int32 upper)
        {
            AssertPercentile(spell, lower, upper);
        }
    }
}