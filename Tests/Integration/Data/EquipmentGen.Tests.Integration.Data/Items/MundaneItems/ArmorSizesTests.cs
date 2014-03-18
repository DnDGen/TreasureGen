using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MundaneItems
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