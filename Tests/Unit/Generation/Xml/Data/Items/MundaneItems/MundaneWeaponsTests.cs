using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class MundaneWeaponsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "MundaneWeapons";
        }

        [Test]
        public void MundaneCommonMeleeWeaponPercentile()
        {
            AssertContent(ItemsConstants.Gear.WeaponTypes.CommonMelee, 1, 50);
        }

        [Test]
        public void MundaneUncommonWeaponPercentile()
        {
            AssertContent(ItemsConstants.Gear.WeaponTypes.Uncommon, 51, 70);
        }

        [Test]
        public void MundaneRangedWeaponPercentile()
        {
            AssertContent(ItemsConstants.Gear.WeaponTypes.CommonRanged, 71, 100);
        }
    }
}