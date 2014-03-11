using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.WondrousItems
{
    [TestFixture, PercentileTable("MajorWondrousItems")]
    public class MajorWondrousItemsTests : PercentileTests
    {
        [Test]
        public void DimensionalShacklesPercentile()
        {
            AssertContent("Dimensional shackles", 1);
        }
    }
}