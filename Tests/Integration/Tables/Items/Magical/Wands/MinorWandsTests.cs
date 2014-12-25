using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Wands
{
    [TestFixture]
    public class MinorWandsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.Wand); }
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

        [TestCase("Detect magic", 1, 2)]
        [TestCase("Light", 3, 4)]
        [TestCase("Burning hands", 5, 7)]
        [TestCase("Charm animal", 8, 10)]
        [TestCase("Charm person", 11, 13)]
        [TestCase("Color spray", 14, 16)]
        [TestCase("Cure light wounds", 17, 19)]
        [TestCase("Detect secret doors", 20, 22)]
        [TestCase("Enlarge person", 23, 25)]
        [TestCase("Magic missile (1st)", 26, 28)]
        [TestCase("Shocking grasp", 29, 31)]
        [TestCase("Summon monster I", 32, 34)]
        [TestCase("Magic missile (3rd)", 35, 36)]
        [TestCase("Bear's endurance", 38, 40)]
        [TestCase("Bull's strength", 41, 43)]
        [TestCase("Cat's grace", 44, 46)]
        [TestCase("Cure moderate wounds", 47, 49)]
        [TestCase("Darkness", 50, 51)]
        [TestCase("Daze monster", 52, 54)]
        [TestCase("Delay poison", 55, 57)]
        [TestCase("Eagle's splendor", 58, 60)]
        [TestCase("False life", 61, 63)]
        [TestCase("Fox's cunning", 64, 66)]
        [TestCase("Ghoul touch", 67, 68)]
        [TestCase("Hold person", 69, 71)]
        [TestCase("Invisibility", 72, 74)]
        [TestCase("Knock", 75, 77)]
        [TestCase("Levitate", 78, 80)]
        [TestCase("Acid arrow", 81, 83)]
        [TestCase("Mirror image", 84, 86)]
        [TestCase("Owl's wisdom", 87, 89)]
        [TestCase("Shatter", 90, 91)]
        [TestCase("Silence", 92, 94)]
        [TestCase("Summon monster II", 95, 97)]
        [TestCase("Web", 98, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Magic missile (5th)", 37)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}