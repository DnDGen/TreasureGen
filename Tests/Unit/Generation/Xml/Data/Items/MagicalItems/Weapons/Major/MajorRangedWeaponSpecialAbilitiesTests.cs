using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Weapons.Major
{
    [TestFixture, PercentileTable("MajorRangedWeaponSpecialAbilities")]
    public class MajorRangedWeaponSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void BanePercentile()
        {
            AssertContent(SpecialAbilityConstants.Bane, 1, 4);
        }

        [Test]
        public void DistancePercentile()
        {
            AssertContent(SpecialAbilityConstants.Distance, 5, 8);
        }

        [Test]
        public void FlamingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Flaming, 9, 12);
        }

        [Test]
        public void FrostPercentile()
        {
            AssertContent(SpecialAbilityConstants.Frost, 13, 16);
        }

        [Test]
        public void ReturningPercentile()
        {
            AssertContent(SpecialAbilityConstants.Returning, 17, 21);
        }

        [Test]
        public void ShockPercentile()
        {
            AssertContent(SpecialAbilityConstants.Shock, 22, 25);
        }

        [Test]
        public void SeekingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Seeking, 26, 27);
        }

        [Test]
        public void ThunderingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Thundering, 28, 29);
        }

        [Test]
        public void AnarchicPercentile()
        {
            AssertContent(SpecialAbilityConstants.Anarchic, 30, 34);
        }

        [Test]
        public void AxiomaticPercentile()
        {
            AssertContent(SpecialAbilityConstants.Distance, 35, 39);
        }

        [Test]
        public void FlamingBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.FlamingBurst, 40, 49);
        }

        [Test]
        public void HolyPercentile()
        {
            AssertContent(SpecialAbilityConstants.Holy, 50, 54);
        }

        [Test]
        public void IcyBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.IcyBurst, 55, 64);
        }

        [Test]
        public void ShockingBurstPercentile()
        {
            AssertContent(SpecialAbilityConstants.Distance, 65, 74);
        }

        [Test]
        public void UnholyPercentile()
        {
            AssertContent(SpecialAbilityConstants.Distance, 75, 79);
        }

        [Test]
        public void SpeedPercentile()
        {
            AssertContent(SpecialAbilityConstants.Speed, 80, 84);
        }

        [Test]
        public void BrilliantEnergyPercentile()
        {
            AssertContent(SpecialAbilityConstants.BrilliantEnergy, 85, 90);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 91, 100);
        }
    }
}