using System;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class SpecificCursedItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Percentiles.Set.SpecificCursedItems; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Incense of obsession", 1, 5)]
        [TestCase("Ring of clumsiness", 6, 15)]
        [TestCase("Amulet of inescapable location", 16, 20)]
        [TestCase("Stone of weight", 21, 25)]
        [TestCase("Bracers of defenselessness", 26, 30)]
        [TestCase("Gauntlets of fumbling", 31, 35)]
        [TestCase("Cursed -2 sword", 36, 40)]
        [TestCase("Armor of rage", 41, 43)]
        [TestCase("Medallion of thought projection", 44, 46)]
        [TestCase("Flask of curses", 47, 52)]
        [TestCase("Dust of sneezing and choking", 53, 54)]
        [TestCase("Potion of poison", 56, 60)]
        [TestCase("Robe of powerlessness", 62, 63)]
        [TestCase("Cursed backbiter spear", 65, 68)]
        [TestCase("Armor of arrow attraction", 69, 70)]
        [TestCase("Net of snaring", 71, 72)]
        [TestCase("Bag of devouring", 73, 75)]
        [TestCase("Mace of blood", 76, 80)]
        [TestCase("Robe of vermin", 81, 85)]
        [TestCase("Periapt of foul rotting", 86, 88)]
        [TestCase("Berserking sword", 89, 92)]
        [TestCase("Boots of dancing", 93, 96)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Helm of opposite alignment", 55)]
        [TestCase("Broom of animated attack", 61)]
        [TestCase("Vacuous grimoire", 64)]
        [TestCase("Crystal hypnosis ball", 97)]
        [TestCase("Necklace of strangulation", 98)]
        [TestCase("Cloak of poisonousness", 99)]
        [TestCase("Scarab of death", 100)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}