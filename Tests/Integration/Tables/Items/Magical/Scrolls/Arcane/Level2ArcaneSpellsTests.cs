using System;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level2ArcaneSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 2, "Arcane"); }
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

        [TestCase("Animal messenger", 1)]
        [TestCase("Animal trance", 2)]
        [TestCase("Arcane lock", 3)]
        [TestCase("Calm emotions", 14)]
        [TestCase("Continual flame", 20)]
        [TestCase("Cure moderate wounds", 21)]
        [TestCase("Darkness", 22)]
        [TestCase("Daze monster", 26)]
        [TestCase("Delay poison", 27)]
        [TestCase("Enthrall", 35)]
        [TestCase("Fog cloud", 40)]
        [TestCase("Ghoul touch", 44)]
        [TestCase("Gust of wind", 47)]
        [TestCase("Leomund's trap", 56)]
        [TestCase("Locate object", 59)]
        [TestCase("Magic mouth", 60)]
        [TestCase("Minor image", 63)]
        [TestCase("Misdirection", 66)]
        [TestCase("Obscure object", 67)]
        [TestCase("Rope trick", 79)]
        [TestCase("Scare", 80)]
        [TestCase("Shatter", 86)]
        [TestCase("Silence", 87)]
        [TestCase("Sound burst", 88)]
        [TestCase("Spectral hand", 89)]
        [TestCase("Tasha's hideous laughter", 96)]
        [TestCase("Touch of idiocy", 97)]
        [TestCase("Whispering wind", 100)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }

        [TestCase("Bear's endurance", 4, 6)]
        [TestCase("Blindness/deafness", 7, 8)]
        [TestCase("Blur", 9, 10)]
        [TestCase("Bull's strength", 11, 13)]
        [TestCase("Cat's grace", 15, 17)]
        [TestCase("Command undead", 18, 19)]
        [TestCase("Darkvision", 23, 25)]
        [TestCase("Detect thoughts", 28, 29)]
        [TestCase("Disguise self", 30, 31)]
        [TestCase("Eagle's splendor", 32, 34)]
        [TestCase("False life", 36, 37)]
        [TestCase("Flaming sphere", 38, 39)]
        [TestCase("Fox's cunning", 41, 43)]
        [TestCase("Glitterdust", 45, 46)]
        [TestCase("Hypnotic pattern", 48, 49)]
        [TestCase("Invisibility", 50, 52)]
        [TestCase("Knock", 53, 55)]
        [TestCase("Levitate", 57, 58)]
        [TestCase("Melf's acid arrow", 61, 62)]
        [TestCase("Mirror image", 64, 65)]
        [TestCase("Owl's wisdom", 68, 70)]
        [TestCase("Protection from arrows", 71, 73)]
        [TestCase("Pyrotechnics", 74, 75)]
        [TestCase("Resist energy", 76, 78)]
        [TestCase("Scorching ray", 81, 82)]
        [TestCase("See invisibility", 83, 85)]
        [TestCase("Spider climb", 90, 91)]
        [TestCase("Summon monster II", 92, 93)]
        [TestCase("Summon swarm", 94, 95)]
        [TestCase("Web", 98, 99)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}