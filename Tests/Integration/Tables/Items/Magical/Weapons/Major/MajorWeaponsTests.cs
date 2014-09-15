using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons.Major
{
    [TestFixture]
    public class MajorWeaponsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MajorWeapons"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("SpecificWeapons", 50, 63)]
        [TestCase("SpecialAbility", 64, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(3, 1, 20)]
        [TestCase(4, 21, 38)]
        [TestCase(5, 39, 49)]
        public void Percentile(Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(bonus);
            Percentile(content, lower, upper);
        }
    }
}