using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Weapons.Minor
{
    [TestFixture, PercentileTable("MinorRangedWeaponSpecialAbilities")]
    public class MinorRangedWeaponSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void BanePercentile()
        {
            AssertContent(SpecialAbilityConstants.Bane, 1, 12);
        }

        [Test]
        public void DistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.Distance, 13, 25);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Flaming, 26, 40);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertContent(SpecialAbilityConstants.Frost, 41, 55);
        }

        [Test]
        public void MercifulPercentile()
        {
            AssertContent(SpecialAbilityConstants.Merciful, 56, 60);
        }

        [Test]
        public void ReturningPercentile()
        {
            AssertContent(SpecialAbilityConstants.Returning, 61, 68);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertContent(SpecialAbilityConstants.Shock, 69, 83);
        }

        [Test]
        public void SeekingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Seeking, 84, 93);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Thundering, 94, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 100);
        }
    }
}