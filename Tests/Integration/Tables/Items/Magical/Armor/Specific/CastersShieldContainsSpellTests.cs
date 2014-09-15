using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class CastersShieldContainsSpellTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return "CastersShieldContainsSpell"; }
        }

        [TestCase(false, 1, 50)]
        [TestCase(true, 51, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}