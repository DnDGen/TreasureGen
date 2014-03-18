using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Weapons
{
    [TestFixture, PercentileTable("RangedTraits")]
    public class RangedTraitsTests : PercentileTests
    {
        [Test]
        public void MarkingsPercentile()
        {
            AssertContent(TraitConstants.Markings, 1, 20);
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertEmpty(21, 100);
        }
    }
}