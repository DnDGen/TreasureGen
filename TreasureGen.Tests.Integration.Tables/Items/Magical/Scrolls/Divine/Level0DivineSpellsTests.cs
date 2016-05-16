using System;
using TreasureGen.Domain.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls.Divine
{
    [TestFixture]
    public class Level0DivineSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 0, "Divine"); }
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

        [TestCase("Create water", 1, 7)]
        [TestCase("Cure minor wounds", 8, 14)]
        [TestCase("Detect magic", 15, 22)]
        [TestCase("Detect poison", 23, 29)]
        [TestCase("Flare", 30, 36)]
        [TestCase("Guidance", 37, 43)]
        [TestCase("Inflict minor wounds", 44, 50)]
        [TestCase("Know direction", 51, 57)]
        [TestCase("Light", 58, 65)]
        [TestCase("Mending", 66, 72)]
        [TestCase("Purify food and drink", 73, 79)]
        [TestCase("Read magic", 80, 86)]
        [TestCase("Resistance", 87, 93)]
        [TestCase("Virtue", 94, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}