using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons.Minor
{
    [TestFixture, PercentileTable("MinorRangedWeaponSpecialAbilities")]
    public class MinorRangedWeaponSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void BanePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Bane, 1, 12);
        }

        [Test]
        public void DistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Distance, 13, 25);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Flaming, 26, 40);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Frost, 41, 55);
        }

        [Test]
        public void MercifulPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Merciful, 56, 60);
        }

        [Test]
        public void ReturningPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Returning, 61, 68);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Shock, 69, 83);
        }

        [Test]
        public void SeekingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Seeking, 84, 93);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Thundering, 94, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 100);
        }
    }
}