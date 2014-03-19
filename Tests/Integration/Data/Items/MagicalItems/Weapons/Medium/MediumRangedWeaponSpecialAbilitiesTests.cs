using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons.Medium
{
    [TestFixture, PercentileTable("MediumRangedWeaponSpecialAbilities")]
    public class MediumRangedWeaponSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void BanePercentile()
        {
            AssertContent(SpecialAbilityConstants.Bane, 1, 8);
        }

        [Test]
        public void DistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.Distance, 9, 16);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Flaming, 17, 28);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertContent(SpecialAbilityConstants.Frost, 29, 40);
        }

        [Test]
        public void MercifulPercentile()
        {
            AssertContent(SpecialAbilityConstants.Merciful, 41, 42);
        }

        [Test]
        public void ReturningPercentile()
        {
            AssertContent(SpecialAbilityConstants.Returning, 43, 47);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertContent(SpecialAbilityConstants.Shock, 48, 59);
        }

        [Test]
        public void SeekingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Seeking, 60, 64);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Thundering, 65, 68);
        }

        [Test]
        public void AnarchicPercentile()
        {
            AssertContent(SpecialAbilityConstants.Anarchic, 69, 71);
        }

        [Test]
        public void AxiomaticPercentile()
        {
            AssertContent(SpecialAbilityConstants.Axiomatic, 72, 74);
        }

        [Test]
        public void FlamingBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.FlamingBurst, 75, 79);
        }

        [Test]
        public void HolyPercentile()
        {
            AssertContent(SpecialAbilityConstants.Holy, 80, 82);
        }

        [Test]
        public void IcyBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.IcyBurst, 83, 87);
        }

        [Test]
        public void ShockingBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.ShockingBurst, 88, 92);
        }

        [Test]
        public void UnholyPercentile()
        {
            AssertContent(SpecialAbilityConstants.Unholy, 93, 95);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 96, 100);
        }
    }
}