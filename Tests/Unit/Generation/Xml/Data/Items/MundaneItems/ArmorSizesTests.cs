using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
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