using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Weapons
{
    [TestFixture, PercentileTable("MeleeTraits")]
    public class MeleeTraitsTests : PercentileTests
    {
        [Test]
        public void ShedsLightPercentile()
        {
            AssertContent(TraitConstants.ShedsLight, 1, 30);
        }

        [Test]
        public void MarkingsPercentile()
        {
            AssertContent(TraitConstants.Markings, 31, 45);
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertEmpty(46, 100);
        }
    }
}