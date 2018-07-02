using NUnit.Framework;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Weapons
{
    [TestFixture]
    public class DesignatedFoesTests : PercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.DesignatedFoes; }
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

        [TestCase("Aquatic-humanoid", 40)]
        [TestCase("Gnoll", 45)]
        [TestCase("Gnome", 46)]
        [TestCase("Halfling", 50)]
        [TestCase("Air-outsider", 73)]
        [TestCase("Earth-outsider", 77)]
        [TestCase("Fire-outsider", 81)]
        [TestCase("Water-outsider", 88)]
        public override void Percentile(string content, int roll)
        {
            base.Percentile(content, roll);
        }

        [TestCase("Aberration", 1, 5)]
        [TestCase("Animal", 6, 9)]
        [TestCase("Construct", 10, 16)]
        [TestCase("Dragon", 17, 22)]
        [TestCase("Elemental", 23, 27)]
        [TestCase("Fey", 28, 32)]
        [TestCase("Giant", 33, 39)]
        [TestCase("Dwarf", 41, 42)]
        [TestCase("Elf", 43, 44)]
        [TestCase("Goblinoid", 47, 49)]
        [TestCase("Human", 51, 54)]
        [TestCase("Reptilian-humanoid", 55, 57)]
        [TestCase("Orc", 58, 60)]
        [TestCase("Magical-beast", 61, 65)]
        [TestCase("Monstrous-humanoid", 66, 70)]
        [TestCase("Ooze", 71, 72)]
        [TestCase("Chaotic-outsider", 74, 76)]
        [TestCase("Evil-outsider", 78, 80)]
        [TestCase("Good-outsider", 82, 84)]
        [TestCase("Lawful-outsider", 85, 87)]
        [TestCase("Plant", 89, 90)]
        [TestCase("Undead", 91, 98)]
        [TestCase("Vermin", 99, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}