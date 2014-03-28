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
            AssertPercentile(SpecialAbilityConstants.Bane, 1, 8);
        }

        [Test]
        public void DistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Distance, 9, 16);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Flaming, 17, 28);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Frost, 29, 40);
        }

        [Test]
        public void MercifulPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Merciful, 41, 42);
        }

        [Test]
        public void ReturningPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Returning, 43, 47);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Shock, 48, 59);
        }

        [Test]
        public void SeekingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Seeking, 60, 64);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Thundering, 65, 68);
        }

        [Test]
        public void AnarchicPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Anarchic, 69, 71);
        }

        [Test]
        public void AxiomaticPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Axiomatic, 72, 74);
        }

        [Test]
        public void FlamingBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.FlamingBurst, 75, 79);
        }

        [Test]
        public void HolyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Holy, 80, 82);
        }

        [Test]
        public void IcyBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.IcyBurst, 83, 87);
        }

        [Test]
        public void ShockingBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ShockingBurst, 88, 92);
        }

        [Test]
        public void UnholyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Unholy, 93, 95);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 96, 100);
        }
    }
}