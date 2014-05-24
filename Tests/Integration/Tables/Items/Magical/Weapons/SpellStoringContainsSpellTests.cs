using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons
{
    [TestFixture]
    public class SpellStoringContainsSpellTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "SpellStoringContainsSpell"; }
        }

        [TestCase(true, 1, 50)]
        [TestCase(false, 51, 100)]
        public void Percentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(isTrue);
            AssertPercentile(content, lower, upper);
        }
    }
}