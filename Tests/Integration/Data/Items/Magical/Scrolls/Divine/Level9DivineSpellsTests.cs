using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Divine
{
    [TestFixture]
    public class Level9DivineSpellsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level9DivineSpells";
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
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("True resurrection", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}