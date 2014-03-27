using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, PercentileTable("MundaneWeapons")]
    public class MundaneWeaponsTests : PercentileTests
    {
        [Test]
        public void MundaneCommonMeleeWeaponPercentile()
        {
            AssertPercentile("CommonMelee", 1, 50);
        }

        [Test]
        public void MundaneUncommonWeaponPercentile()
        {
            AssertPercentile("Uncommon", 51, 70);
        }

        [Test]
        public void MundaneRangedWeaponPercentile()
        {
            AssertPercentile("CommonRanged", 71, 100);
        }
    }
}