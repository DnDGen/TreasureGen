using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rods
{
    [TestFixture]
    public class RodOfAbsorptionContainsSpellLevelsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "RodOfAbsorptionContainsSpellLevels"; }
        }

        [TestCase(false, 1, 70)]
        [TestCase(true, 71, 100)]
        public void Percentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(isTrue);
            AssertPercentile(content, lower, upper);
        }
    }
}