using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class CastersShieldContainsSpellTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "CastersShieldContainsSpell"; }
        }

        [TestCase(false, 1, 50)]
        [TestCase(true, 51, 100)]
        public void Percentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(isTrue);
            AssertPercentile(content, lower, upper);
        }
    }
}