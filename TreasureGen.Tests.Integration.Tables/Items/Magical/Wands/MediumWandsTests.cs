using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Wands
{
    [TestFixture]
    public class MediumWandsTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Wand); }
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

        [TestCase("Magic missile (5th)", 1, 3)]
        [TestCase("Bear's endurance", 4, 7)]
        [TestCase("Bull's strength", 8, 11)]
        [TestCase("Cat's grace", 12, 15)]
        [TestCase("Cure moderate wounds", 16, 20)]
        [TestCase("Darkness", 21, 22)]
        [TestCase("Daze monster", 23, 24)]
        [TestCase("Delay poison", 25, 27)]
        [TestCase("Eagle's splendor", 28, 31)]
        [TestCase("False life", 32, 33)]
        [TestCase("Fox's cunning", 34, 37)]
        [TestCase("Invisibility", 40, 42)]
        [TestCase("Knock", 43, 44)]
        [TestCase("Acid arrow", 46, 47)]
        [TestCase("Mirror image", 48, 49)]
        [TestCase("Owl's wisdom", 50, 53)]
        [TestCase("Silence", 55, 56)]
        [TestCase("Web", 58, 59)]
        [TestCase("Magic missile (7th)", 60, 62)]
        [TestCase("Magic missile (9th)", 63, 64)]
        [TestCase("Call lightning (5th)", 65, 67)]
        [TestCase("Contagion", 69, 70)]
        [TestCase("Cure serious wounds", 71, 74)]
        [TestCase("Dispel magic", 75, 77)]
        [TestCase("Fireball (5th)", 78, 81)]
        [TestCase("Keen edge", 82, 83)]
        [TestCase("Lightning bolt (5th)", 84, 87)]
        [TestCase("Major image", 88, 89)]
        [TestCase("Slow", 90, 91)]
        [TestCase("Suggestion", 92, 94)]
        [TestCase("Summon monster III", 95, 97)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Ghoul touch", 38)]
        [TestCase("Hold person", 39)]
        [TestCase("Levitate", 45)]
        [TestCase("Shatter", 54)]
        [TestCase("Summon monster II", 57)]
        [TestCase("Heightened charm person (3rd-level spell)", 68)]
        [TestCase("Fireball (6th)", 98)]
        [TestCase("Lightning bolt (6th)", 99)]
        [TestCase("Searing light (6th)", 100)]
        public override void Percentile(string content, int roll)
        {
            base.Percentile(content, roll);
        }
    }
}