using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("MundaneWeapons")]
    public class MundaneWeaponsTests : PercentileTests
    {
        [Test]
        public void MundaneCommonMeleeWeaponPercentile()
        {
            AssertContent("CommonMelee", 1, 50);
        }

        [Test]
        public void MundaneUncommonWeaponPercentile()
        {
            AssertContent("Uncommon", 51, 70);
        }

        [Test]
        public void MundaneRangedWeaponPercentile()
        {
            AssertContent("CommonRanged", 71, 100);
        }
    }
}