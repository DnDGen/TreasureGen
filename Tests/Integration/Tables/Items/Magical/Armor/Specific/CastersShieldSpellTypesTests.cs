using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class CastersShieldSpellTypesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "CastersShieldSpellTypes"; }
        }

        [TestCase("Divine", 1, 80)]
        [TestCase("Arcane", 81, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}