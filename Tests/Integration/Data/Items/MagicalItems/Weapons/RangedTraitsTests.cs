using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons
{
    [TestFixture, PercentileTable("RangedTraits")]
    public class RangedTraitsTests : PercentileTests
    {
        [Test]
        public void MarkingsPercentile()
        {
            AssertPercentile(TraitConstants.Markings, 1, 20);
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertEmpty(21, 100);
        }
    }
}