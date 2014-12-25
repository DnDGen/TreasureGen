using System;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level8ArcaneSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 8, "Arcane"); }
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

        [TestCase("Antipathy", 1, 2)]
        [TestCase("Bigby's clenched fist", 3, 5)]
        [TestCase("Binding", 6, 8)]
        [TestCase("Mass charm monster", 9, 12)]
        [TestCase("Create greater undead", 14, 16)]
        [TestCase("Demand", 17, 19)]
        [TestCase("Dimensional lock", 20, 22)]
        [TestCase("Discern location", 23, 26)]
        [TestCase("Horrid wilting", 27, 29)]
        [TestCase("Incendiary cloud", 30, 32)]
        [TestCase("Iron body", 33, 35)]
        [TestCase("Maze", 36, 38)]
        [TestCase("Mind blank", 39, 41)]
        [TestCase("Moment of prescience", 42, 44)]
        [TestCase("Otiluke's telekinetic sphere", 45, 48)]
        [TestCase("Otto's irresistible dance", 49, 51)]
        [TestCase("Greater planar binding", 52, 54)]
        [TestCase("Polar ray", 55, 57)]
        [TestCase("Polymorph any object", 58, 60)]
        [TestCase("Power word stun", 61, 63)]
        [TestCase("Prismatic wall", 64, 66)]
        [TestCase("Protection from spells", 67, 70)]
        [TestCase("Greater prying eyes", 71, 73)]
        [TestCase("Scintillating pattern", 74, 76)]
        [TestCase("Screen", 77, 78)]
        [TestCase("Greater shadow evocation", 79, 81)]
        [TestCase("Greater shout", 82, 84)]
        [TestCase("Summon monster VIII", 85, 87)]
        [TestCase("Sunburst", 88, 90)]
        [TestCase("Sympathy", 93, 94)]
        [TestCase("Temporal stasis", 95, 98)]
        [TestCase("Trap the soul", 99, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Clone", 13)]
        [TestCase("Symbol of death", 91)]
        [TestCase("Symbol of insanity", 92)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}