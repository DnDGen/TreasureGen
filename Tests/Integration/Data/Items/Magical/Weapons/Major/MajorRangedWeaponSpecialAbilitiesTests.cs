using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons.Major
{
    [TestFixture]
    public class MajorRangedWeaponSpecialAbilitiesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MajorRangedWeaponSpecialAbilities";
        }

        [Test]
        public void BanePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Bane, 1, 4);
        }

        [Test]
        public void DistancePercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Distance, 5, 8);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Flaming, 9, 12);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Frost, 13, 16);
        }

        [Test]
        public void ReturningPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Returning, 17, 21);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Shock, 22, 25);
        }

        [Test]
        public void SeekingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Seeking, 26, 27);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Thundering, 28, 29);
        }

        [Test]
        public void AnarchicPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Anarchic, 30, 34);
        }

        [Test]
        public void AxiomaticPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Axiomatic, 35, 39);
        }

        [Test]
        public void FlamingBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.FlamingBurst, 40, 49);
        }

        [Test]
        public void HolyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Holy, 50, 54);
        }

        [Test]
        public void IcyBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.IcyBurst, 55, 64);
        }

        [Test]
        public void ShockingBurstPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.ShockingBurst, 65, 74);
        }

        [Test]
        public void UnholyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Unholy, 75, 79);
        }

        [Test]
        public void SpeedPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.Speed, 80, 84);
        }

        [Test]
        public void BrilliantEnergyPercentile()
        {
            AssertPercentile(SpecialAbilityConstants.BrilliantEnergy, 85, 90);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertPercentile("BonusSpecialAbility", 91, 100);
        }
    }
}