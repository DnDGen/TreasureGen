using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Wands
{
    [TestFixture, PercentileTable("WandTraits")]
    public class WandTraitsTests : PercentileTests
    {
        [Test]
        public void MarkingsPercentile()
        {
            AssertPercentile(TraitConstants.Markings, 1, 30);
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertEmpty(31, 100);
        }
    }
}