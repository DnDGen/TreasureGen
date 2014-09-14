using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Staves
{
    [TestFixture]
    public class MediumStavesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MediumStaves"; }
        }

        [TestCase("Charming", 1, 15)]
        [TestCase("Fire", 16, 30)]
        [TestCase("Swarming insects", 31, 40)]
        [TestCase("Healing", 41, 60)]
        [TestCase("Size alteration", 61, 75)]
        [TestCase("Illumination", 76, 90)]
        [TestCase("Frost", 91, 95)]
        [TestCase("Defense", 96, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}