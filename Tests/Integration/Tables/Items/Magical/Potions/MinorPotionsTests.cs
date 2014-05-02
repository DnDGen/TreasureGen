using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Potions
{
    [TestFixture]
    public class MinorPotionsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MinorPotions"; }
        }

        [TestCase("Potion of cure light wounds", 0, 1, 10)]
        [TestCase("Potion of endure elements", 0, 11, 13)]
        [TestCase("Potion of hide from animals", 0, 14, 15)]
        [TestCase("Potion of hide from undead", 0, 16, 17)]
        [TestCase("Potion of jump", 0, 18, 19)]
        [TestCase("Potion of mage armor", 0, 20, 22)]
        [TestCase("Potion of magic fang", 0, 23, 25)]
        [TestCase("Oil of magic weapon", 0, 27, 29)]
        [TestCase("Potion of protection from ALIGNMENT", 0, 31, 32)]
        [TestCase("Potion of remove fear", 0, 33, 34)]
        [TestCase("Potion of shield of faith", 2, 36, 38)]
        [TestCase("Oil of bless weapon", 0, 40, 41)]
        [TestCase("Potion of enlarge person", 0, 42, 44)]
        [TestCase("Potion of aid", 0, 46, 47)]
        [TestCase("Potion of barkskin", 2, 48, 50)]
        [TestCase("Potion of bear's endurance", 0, 51, 53)]
        [TestCase("Potion of blur", 0, 54, 56)]
        [TestCase("Potion of bull's strength", 0, 57, 59)]
        [TestCase("Potion of cat's grace", 0, 60, 62)]
        [TestCase("Potion of cure moderate wounds", 0, 63, 67)]
        [TestCase("Potion of darkvision", 0, 69, 71)]
        [TestCase("Potion of delay poison", 0, 72, 74)]
        [TestCase("Potion of eagle's splendor", 0, 75, 76)]
        [TestCase("Potion of fox's cunning", 0, 77, 78)]
        [TestCase("Potion of invisibility", 0, 79, 80)]
        [TestCase("Potion of lesser restoration", 0, 82, 84)]
        [TestCase("Potion of owl's wisdom", 0, 88, 89)]
        [TestCase("Potion of protection from arrows 10/magic", 0, 90, 91)]
        [TestCase("Potion of remove paralysis", 0, 92, 93)]
        [TestCase("Potion of resist ENERGY", 0, 94, 96)]
        [TestCase("Potion of spider climb", 0, 98, 99)]
        public void Percentile(String name, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", name, bonus);
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Oil of magic stone", 0, 26)]
        [TestCase("Potion of pass without trace", 0, 30)]
        [TestCase("Potion of sanctuary", 0, 35)]
        [TestCase("Oil of shillelagh", 0, 39)]
        [TestCase("Potion of reduce person", 0, 45)]
        [TestCase("Oil of darkness", 0, 68)]
        [TestCase("Oil of invisibility", 0, 81)]
        [TestCase("Potion of levitate", 0, 85)]
        [TestCase("Oil of levitate", 0, 86)]
        [TestCase("Potion of misdirection", 0, 87)]
        [TestCase("Potion of shield of faith", 3, 97)]
        [TestCase("Potion of undetectable alignment", 0, 100)]
        public void Percentile(String name, Int32 bonus, Int32 roll)
        {
            var content = String.Format("{0},{1}", name, bonus);
            AssertPercentile(content, roll);
        }
    }
}