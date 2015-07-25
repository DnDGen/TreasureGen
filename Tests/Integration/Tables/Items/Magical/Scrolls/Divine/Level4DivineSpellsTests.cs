using System;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Divine
{
    [TestFixture]
    public class Level4DivineSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 4, "Divine"); }
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

        [TestCase("Air walk", 1, 5)]
        [TestCase("Antiplant shell", 6, 7)]
        [TestCase("Blight", 8, 9)]
        [TestCase("Break enchantment", 10, 11)]
        [TestCase("Command plants", 12, 13)]
        [TestCase("Control water", 14, 15)]
        [TestCase("Cure critical wounds", 16, 21)]
        [TestCase("Death ward", 22, 26)]
        [TestCase("Dimensional anchor", 27, 31)]
        [TestCase("Discern lies", 32, 34)]
        [TestCase("Dismissal", 35, 37)]
        [TestCase("Divination", 38, 39)]
        [TestCase("Divine power", 40, 42)]
        [TestCase("Freedom of movement", 43, 47)]
        [TestCase("Giant vermin", 48, 49)]
        [TestCase("Holy sword", 50, 51)]
        [TestCase("Imbue with spell ability", 52, 54)]
        [TestCase("Inflict critical wounds", 55, 57)]
        [TestCase("Greater magic weapon", 58, 60)]
        [TestCase("Nondetection", 61, 62)]
        [TestCase("Lesser planar ally", 63, 64)]
        [TestCase("Poison", 65, 67)]
        [TestCase("Reincarnate", 68, 69)]
        [TestCase("Repel vermin", 70, 71)]
        [TestCase("Restoration", 72, 76)]
        [TestCase("Rusting grasp", 77, 78)]
        [TestCase("Sending", 79, 81)]
        [TestCase("Spell immunity", 82, 85)]
        [TestCase("Spike stones", 86, 87)]
        [TestCase("Summon monster IV", 88, 90)]
        [TestCase("Summon nature's ally IV", 91, 93)]
        [TestCase("Tongues", 94, 98)]
        [TestCase("Tree stride", 99, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}