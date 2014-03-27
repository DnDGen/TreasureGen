using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, PercentileTable("ArmorSizes")]
    public class ArmorSizesTests : PercentileTests
    {
        [TestCase(TraitConstants.Small, 1, 10)]
        [TestCase(TraitConstants.Medium, 11, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}