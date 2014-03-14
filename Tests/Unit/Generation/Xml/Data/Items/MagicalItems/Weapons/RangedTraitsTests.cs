using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Weapons
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