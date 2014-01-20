using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class ArmorSizesTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "ArmorSizes";
        }

        [Test]
        public void SmallPercentile()
        {
            AssertContent(ItemsConstants.Gear.Traits.Small, 1, 10);
        }

        [Test]
        public void MediumPercentile()
        {
            AssertContent(ItemsConstants.Gear.Traits.Medium, 11, 100);
        }
    }
}