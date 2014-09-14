using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class HasSpecialMaterialTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return "HasSpecialMaterial"; }
        }

        [TestCase(false, 1, 95)]
        [TestCase(true, 96, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}