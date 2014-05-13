using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Potions
{
    [TestFixture]
    public class MediumPotionsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MediumPotions"; }
        }

        [TestCase("Oil of bless weapon", 0, 1, 2)]
        [TestCase("Potion of enlarge person", 0, 3, 4)]
        [TestCase("Potion of bear's endurance", 0, 8, 10)]
        [TestCase("Potion of blur", 0, 11, 13)]
        [TestCase("Potion of bull's strength", 0, 14, 16)]
        [TestCase("Potion of cat's grace", 0, 17, 19)]
        [TestCase("Potion of cure moderate wounds", 0, 20, 27)]
        [TestCase("Potion of darkvision", 0, 29, 30)]
        [TestCase("Potion of eagle's splendor", 0, 32, 33)]
        [TestCase("Potion of fox's cunning", 0, 34, 35)]
        [TestCase("Potion of owl's wisdom", 0, 41, 42)]
        [TestCase("Potion of resist ENERGY 10", 0, 45, 46)]
        [TestCase("Potion of shield of faith", 3, 47, 48)]
        [TestCase("Potion of resist ENERGY 20", 0, 53, 55)]
        [TestCase("Potion of cure serious wounds", 0, 56, 60)]
        [TestCase("Potion of displacement", 0, 62, 64)]
        [TestCase("Potion of fly", 0, 66, 68)]
        [TestCase("Potion of greater magic fang", 1, 70, 71)]
        [TestCase("Oil of greater magic weapon", 1, 72, 73)]
        [TestCase("Potion of haste", 0, 74, 75)]
        [TestCase("Potion of heroism", 0, 76, 78)]
        [TestCase("Oil of keen edge", 0, 79, 80)]
        [TestCase("Oil of magic vestment", 1, 82, 83)]
        [TestCase("Potion of neutralize poison", 0, 84, 86)]
        [TestCase("Potion of nondetection", 0, 87, 88)]
        [TestCase("Potion of protection from ENERGY", 0, 89, 91)]
        [TestCase("Potion of rage", 0, 92, 93)]
        [TestCase("Potion of water breathing", 0, 98, 99)]
        public void Percentile(String name, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", name, bonus);
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Potion of reduce person", 0, 5)]
        [TestCase("Potion of aid", 0, 6)]
        [TestCase("Potion of barkskin", 2, 7)]
        [TestCase("Oil of darkness", 0, 28)]
        [TestCase("Potion of delay poison", 0, 31)]
        [TestCase("Potion of invisibility", 0, 36)]
        [TestCase("Oil of invisibility", 0, 37)]
        [TestCase("Potion of lesser restoration", 0, 38)]
        [TestCase("Potion of levitate", 0, 39)]
        [TestCase("Potion of misdirection", 0, 40)]
        [TestCase("Potion of protection from arrows 10/magic", 0, 43)]
        [TestCase("Potion of remove paralysis", 0, 44)]
        [TestCase("Potion of spider climb", 0, 49)]
        [TestCase("Potion of undetectable alignment", 0, 50)]
        [TestCase("Potion of barkskin", 3, 51)]
        [TestCase("Potion of shield of faith", 4, 52)]
        [TestCase("Oil of daylight", 0, 61)]
        [TestCase("Oil of flame arrow", 0, 65)]
        [TestCase("Potion of gaseous form", 0, 69)]
        [TestCase("Potion of magic circle against ALIGNMENT", 0, 81)]
        [TestCase("Potion of remove blindness/deafness", 0, 94)]
        [TestCase("Potion of remove curse", 0, 95)]
        [TestCase("Potion of remove disease", 0, 96)]
        [TestCase("Potion of tongues", 0, 97)]
        [TestCase("Potion of water walk", 0, 100)]
        public void Percentile(String name, Int32 bonus, Int32 roll)
        {
            var content = String.Format("{0},{1}", name, bonus);
            AssertPercentile(content, roll);
        }
    }
}