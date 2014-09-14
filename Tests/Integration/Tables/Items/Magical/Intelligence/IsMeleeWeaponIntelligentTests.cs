using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IsMeleeWeaponIntelligentTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return "IsMeleeWeaponIntelligent"; }
        }

        [TestCase(true, 1, 15)]
        [TestCase(false, 16, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}