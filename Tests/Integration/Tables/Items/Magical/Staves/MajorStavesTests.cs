using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Staves
{
    [TestFixture]
    public class MajorStavesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MajorStaves"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Charming", 1, 3)]
        [TestCase("Fire", 4, 9)]
        [TestCase("Swarming insects", 10, 11)]
        [TestCase("Healing", 12, 17)]
        [TestCase("Size alteration", 18, 19)]
        [TestCase("Illumination", 20, 24)]
        [TestCase("Frost", 25, 31)]
        [TestCase("Defense", 32, 38)]
        [TestCase("Abjuration", 39, 43)]
        [TestCase("Conjuration", 44, 48)]
        [TestCase("Enchantment", 49, 53)]
        [TestCase("Evocation", 54, 58)]
        [TestCase("Illusion", 59, 63)]
        [TestCase("Necromancy", 64, 68)]
        [TestCase("Transmutation", 69, 73)]
        [TestCase("Divination", 74, 77)]
        [TestCase("Earth and stone", 78, 82)]
        [TestCase("Woodlands", 83, 87)]
        [TestCase("Life", 88, 92)]
        [TestCase("Passage", 93, 97)]
        [TestCase("Power", 98, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}