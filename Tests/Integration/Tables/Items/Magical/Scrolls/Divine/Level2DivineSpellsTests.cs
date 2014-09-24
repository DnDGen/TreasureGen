using System;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Divine
{
    [TestFixture]
    public class Level2DivineSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 2, "Divine"); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Animal messenger", 1)]
        [TestCase("Animal trance", 2)]
        [TestCase("Chill metal", 18)]
        [TestCase("Death knell", 27)]
        [TestCase("Fire trap", 40)]
        [TestCase("Gentle repose", 47)]
        [TestCase("Gust of wind", 48)]
        [TestCase("Heat metal", 49)]
        [TestCase("Reduce animal", 62)]
        [TestCase("Snare", 77)]
        [TestCase("Soften earth and stone", 78)]
        [TestCase("Speak with plants", 81)]
        [TestCase("Status", 86)]
        [TestCase("Tree shape", 93)]
        [TestCase("Wood shape", 98)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }

        [TestCase("Augury", 3, 4)]
        [TestCase("Barkskin", 5, 6)]
        [TestCase("Bear's endurance", 7, 9)]
        [TestCase("Bull's strength", 10, 12)]
        [TestCase("Calm emotions", 13, 14)]
        [TestCase("Cat's grace", 15, 17)]
        [TestCase("Consecrate", 19, 20)]
        [TestCase("Cure moderate wounds", 21, 24)]
        [TestCase("Darkness", 25, 26)]
        [TestCase("Delay poison", 28, 30)]
        [TestCase("Desecrate", 31, 32)]
        [TestCase("Eagle's splendor", 33, 35)]
        [TestCase("Enthrall", 36, 37)]
        [TestCase("Find traps", 38, 39)]
        [TestCase("Flame blade", 41, 42)]
        [TestCase("Flaming sphere", 43, 44)]
        [TestCase("Fog cloud", 45, 46)]
        [TestCase("Hold animal", 50, 51)]
        [TestCase("Hold person", 52, 54)]
        [TestCase("Inflict moderate wounds", 55, 56)]
        [TestCase("Make whole", 57, 58)]
        [TestCase("Owl's wisdom", 59, 61)]
        [TestCase("Remove paralysis", 63, 64)]
        [TestCase("Resist energy", 65, 67)]
        [TestCase("Lesser restoration", 68, 70)]
        [TestCase("Shatter", 71, 72)]
        [TestCase("Shield other", 73, 74)]
        [TestCase("Silence", 75, 76)]
        [TestCase("Sound burst", 79, 80)]
        [TestCase("Spider climb", 82, 83)]
        [TestCase("Spiritual weapon", 84, 85)]
        [TestCase("Summon monster II", 87, 88)]
        [TestCase("Summon nature's ally II", 89, 90)]
        [TestCase("Summon swarm", 91, 92)]
        [TestCase("Undetectable alignment", 94, 95)]
        [TestCase("Warp wood", 96, 97)]
        [TestCase("Zone of truth", 99, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}