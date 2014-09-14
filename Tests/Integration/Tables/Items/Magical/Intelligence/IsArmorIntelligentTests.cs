using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IsArmorIntelligentTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return "IsArmorIntelligent"; }
        }

        [TestCase(false, 2, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }

        [TestCase(true, 1)]
        public override void BooleanPercentile(Boolean isTrue, Int32 roll)
        {
            base.BooleanPercentile(isTrue, roll);
        }
    }
}