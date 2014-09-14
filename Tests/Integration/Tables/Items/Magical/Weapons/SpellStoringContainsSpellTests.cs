using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons
{
    [TestFixture]
    public class SpellStoringContainsSpellTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return "SpellStoringContainsSpell"; }
        }

        [TestCase(true, 1, 50)]
        [TestCase(false, 51, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}