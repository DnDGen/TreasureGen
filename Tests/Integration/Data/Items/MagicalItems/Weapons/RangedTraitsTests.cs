using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons
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