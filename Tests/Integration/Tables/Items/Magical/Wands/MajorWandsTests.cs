using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Wands
{
    [TestFixture]
    public class MajorWandsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MajorWands"; }
        }

        [TestCase("Magic missile (7th)", 1, 2)]
        [TestCase("Magic missile (9th)", 3, 5)]
        [TestCase("Call lightning (5th)", 6, 7)]
        [TestCase("Contagion", 9, 10)]
        [TestCase("Cure serious wounds", 11, 13)]
        [TestCase("Dispel magic", 14, 15)]
        [TestCase("Fireball (5th)", 16, 17)]
        [TestCase("Keen edge", 18, 19)]
        [TestCase("Lightning bolt (5th)", 20, 21)]
        [TestCase("Major image", 22, 23)]
        [TestCase("Slow", 24, 25)]
        [TestCase("Suggestion", 26, 27)]
        [TestCase("Summon monster III", 28, 29)]
        [TestCase("Fireball (6th)", 30, 31)]
        [TestCase("Lightning bolt (6th)", 32, 33)]
        [TestCase("Searing light (6th)", 34, 35)]
        [TestCase("Call lightning (8th)", 36, 37)]
        [TestCase("Fireball (8th)", 38, 39)]
        [TestCase("Lightning bolt (8th)", 40, 41)]
        [TestCase("Charm monster", 42, 45)]
        [TestCase("Cure critical wounds", 46, 50)]
        [TestCase("Dimensional anchor", 51, 52)]
        [TestCase("Fear", 53, 55)]
        [TestCase("Greater invisibility", 56, 59)]
        [TestCase("Ice storm", 61, 65)]
        [TestCase("Inflict critical wounds", 66, 68)]
        [TestCase("Neutralize poison", 69, 72)]
        [TestCase("Poison", 73, 74)]
        [TestCase("Polymorph", 75, 77)]
        [TestCase("Summon monster IV", 80, 82)]
        [TestCase("Wall of fire", 83, 86)]
        [TestCase("Wall of ice", 87, 90)]
        [TestCase("Restoration", 98, 99)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Heightened charm person (3rd-level spell)", 8)]
        [TestCase("Heightened hold person (4th-level spell)", 60)]
        [TestCase("Heightened ray of enfeeblement (4th-level spell)", 78)]
        [TestCase("Heightened suggestion (4th-level spell)", 79)]
        [TestCase("Dispel magic (10th)", 91)]
        [TestCase("Fireball (10th)", 92)]
        [TestCase("Lightning bolt (10th)", 93)]
        [TestCase("Chaos hammer (10th)", 94)]
        [TestCase("Holy smite (8th)", 95)]
        [TestCase("Order's wrath (8th)", 96)]
        [TestCase("Unholy blight (8th)", 97)]
        [TestCase("Stoneskin", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}