using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Potions
{
    [TestFixture]
    public class MajorPotionsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.Potion); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Potion of blur", 0, 1, 2)]
        [TestCase("Potion of cure moderate wounds", 0, 3, 7)]
        [TestCase("Potion of darkvision", 0, 8, 9)]
        [TestCase("Potion of shield of faith", 4, 17, 18)]
        [TestCase("Potion of resist ENERGY 20", 0, 19, 20)]
        [TestCase("Potion of cure serious wounds", 0, 21, 28)]
        [TestCase("Potion of displacement", 0, 30, 32)]
        [TestCase("Potion of fly", 0, 34, 38)]
        [TestCase("Potion of haste", 0, 40, 41)]
        [TestCase("Potion of heroism", 0, 42, 44)]
        [TestCase("Oil of keen edge", 0, 45, 46)]
        [TestCase("Potion of neutralize poison", 0, 48, 50)]
        [TestCase("Potion of nondetection", 0, 51, 52)]
        [TestCase("Potion of protection from ENERGY", 0, 53, 54)]
        [TestCase("Potion of barkskin", 4, 62, 63)]
        [TestCase("Potion of resist ENERGY 30", 0, 66, 68)]
        [TestCase("Potion of greater magic fang", 2, 70, 73)]
        [TestCase("Oil of greater magic weapon", 2, 74, 77)]
        [TestCase("Oil of magic vestment", 2, 78, 81)]
        [TestCase("Potion of greater magic fang", 3, 83, 85)]
        [TestCase("Oil of greater magic weapon", 3, 86, 88)]
        [TestCase("Oil of magic vestment", 3, 89, 91)]
        [TestCase("Potion of greater magic fang", 4, 92, 93)]
        [TestCase("Oil of greater magic weapon", 4, 94, 95)]
        [TestCase("Oil of magic vestment", 4, 96, 97)]
        public override void TypeAndAmountPercentile(String name, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(name, amount, lower, upper);
        }

        [TestCase("Potion of invisibility", 0, 10)]
        [TestCase("Oil of invisibility", 0, 11)]
        [TestCase("Potion of lesser restoration", 0, 12)]
        [TestCase("Potion of remove paralysis", 0, 13)]
        [TestCase("Potion of shield of faith", 3, 14)]
        [TestCase("Potion of undetectable alignment", 0, 15)]
        [TestCase("Potion of barkskin", 3, 16)]
        [TestCase("Oil of daylight", 0, 29)]
        [TestCase("Oil of flame arrow", 0, 33)]
        [TestCase("Potion of gaseous form", 0, 39)]
        [TestCase("Potion of magic circle against ALIGNMENT", 0, 47)]
        [TestCase("Potion of rage", 0, 55)]
        [TestCase("Potion of remove blindness/deafness", 0, 56)]
        [TestCase("Potion of remove curse", 0, 57)]
        [TestCase("Potion of remove disease", 0, 58)]
        [TestCase("Potion of tongues", 0, 59)]
        [TestCase("Potion of water breathing", 0, 60)]
        [TestCase("Potion of water walk", 0, 61)]
        [TestCase("Potion of shield of faith", 5, 64)]
        [TestCase("Potion of good hope", 0, 65)]
        [TestCase("Potion of barkskin", 5, 69)]
        [TestCase("Potion of protection from arrows 15/magic", 0, 82)]
        [TestCase("Potion of greater magic fang", 5, 98)]
        [TestCase("Oil of greater magic weapon", 5, 99)]
        [TestCase("Oil of magic vestment", 5, 100)]
        public override void TypeAndAmountPercentile(String name, Int32 amount, Int32 roll)
        {
            base.TypeAndAmountPercentile(name, amount, roll);
        }
    }
}