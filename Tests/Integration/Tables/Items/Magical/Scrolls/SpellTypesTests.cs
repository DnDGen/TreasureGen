using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls
{
    [TestFixture]
    public class SpellTypesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "SpellTypes"; }
        }

        [TestCase("Arcane", 1, 70)]
        [TestCase("Divine", 71, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}