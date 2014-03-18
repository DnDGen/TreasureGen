using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Rods
{
    [TestFixture, PercentileTable("RodTraits")]
    public class RodTraitsTests : PercentileTests
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