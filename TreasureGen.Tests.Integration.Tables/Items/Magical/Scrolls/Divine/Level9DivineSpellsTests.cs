using System;
using TreasureGen.Domain.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Divine
{
    [TestFixture]
    public class Level9DivineSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 9, "Divine"); }
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

        [TestCase("Antipathy", 1, 4)]
        [TestCase("Astral projection", 5, 7)]
        [TestCase("Elemental swarm", 8, 13)]
        [TestCase("Energy drain", 14, 19)]
        [TestCase("Etherealness", 20, 25)]
        [TestCase("Foresight", 26, 31)]
        [TestCase("Gate", 32, 37)]
        [TestCase("Mass heal", 38, 46)]
        [TestCase("Implosion", 47, 53)]
        [TestCase("Miracle", 54, 55)]
        [TestCase("Regenerate", 56, 61)]
        [TestCase("Shambler", 62, 66)]
        [TestCase("Shapechange", 67, 72)]
        [TestCase("Soul bind", 73, 77)]
        [TestCase("Storm of vengeance", 78, 83)]
        [TestCase("Summon monster IX", 84, 89)]
        [TestCase("Summon nature's ally IX", 90, 95)]
        [TestCase("Sympathy", 96, 99)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("True resurrection", 100)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}