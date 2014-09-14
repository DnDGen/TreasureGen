using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rods
{
    [TestFixture]
    public class RodOfAbsorptionContainsSpellLevelsTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return "RodOfAbsorptionContainsSpellLevels"; }
        }

        [TestCase(false, 1, 70)]
        [TestCase(true, 71, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}