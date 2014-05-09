using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class HasSpecialMaterialTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "HasSpecialMaterial"; }
        }

        [TestCase(false, 1, 95)]
        [TestCase(true, 96, 100)]
        public void Percentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(isTrue);
            AssertPercentile(content, lower, upper);
        }
    }
}