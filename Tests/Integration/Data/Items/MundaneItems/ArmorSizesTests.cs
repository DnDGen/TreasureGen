using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, PercentileTable("ArmorSizes")]
    public class ArmorSizesTests : PercentileTests
    {
        [Test]
        public void SmallPercentile()
        {
            AssertContent(TraitConstants.Small, 1, 10);
        }

        [Test]
        public void MediumPercentile()
        {
            AssertContent(TraitConstants.Medium, 11, 100);
        }
    }
}