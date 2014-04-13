using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Armors
{
    [TestFixture]
    public class ArmorSizesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "ArmorSizes"; }
        }

        [TestCase(TraitConstants.Small, 1, 10)]
        [TestCase(TraitConstants.Medium, 11, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}