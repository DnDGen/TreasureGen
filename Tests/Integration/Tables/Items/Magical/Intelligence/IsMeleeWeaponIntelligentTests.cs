using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IsMeleeWeaponIntelligentTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "IsMeleeWeaponIntelligent"; }
        }

        [TestCase(true, 1, 15)]
        [TestCase(false, 16, 100)]
        public void Percentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(isTrue);
            AssertPercentile(content, lower, upper);
        }
    }
}