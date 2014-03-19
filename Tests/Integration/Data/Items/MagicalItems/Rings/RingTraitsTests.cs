using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Rings
{
    [TestFixture, PercentileTable("RingTraits")]
    public class RingTraitsTests : PercentileTests
    {
        [Test]
        public void MarkingsPercentile()
        {
            AssertContent(TraitConstants.Markings, 1, 30);
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertEmpty(31, 100);
        }
    }
}