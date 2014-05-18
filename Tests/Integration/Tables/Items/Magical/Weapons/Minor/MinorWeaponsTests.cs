using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons.Minor
{
    [TestFixture]
    public class MinorWeaponsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MinorWeapons"; }
        }

        [TestCase("SpecificWeapon", 86, 90)]
        [TestCase("SpecialAbility", 91, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(1, 1, 70)]
        [TestCase(2, 71, 85)]
        public void Percentile(Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(bonus);
            AssertPercentile(content, lower, upper);
        }
    }
}