using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Objects;
using EquipmentGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems
{
    [TestFixture]
    public class SpecialAbilityDataTests : IntegrationTests
    {
        [Inject]
        public ISpecialAbilityDataXmlParser SpecialAbilityDataXmlParser { get; set; }

        private Dictionary<String, SpecialAbilityDataObject> data;

        public SpecialAbilityDataTests()
        {
            data = SpecialAbilityDataXmlParser.Parse("SpecialAbilityData.xml");
        }

        [Test]
        public void GlameredData()
        {
            AssertData(SpecialAbilityConstants.Glamered, 0, SpecialAbilityConstants.Glamered, 0);
        }

        [Test]
        public void AcidResistanceData()
        {
            AssertData(SpecialAbilityConstants.AcidResistance, 0, SpecialAbilityConstants.AcidResistance, 1);
        }

        [Test]
        public void ImprovedAcidResistanceData()
        {
            AssertData(SpecialAbilityConstants.ImprovedAcidResistance, 0, SpecialAbilityConstants.AcidResistance, 2);
        }

        [Test]
        public void GreaterAcidResistanceData()
        {
            AssertData(SpecialAbilityConstants.GreaterAcidResistance, 0, SpecialAbilityConstants.AcidResistance, 3);
        }

        [Test]
        public void ColdResistanceData()
        {
            AssertData(SpecialAbilityConstants.ColdResistance, 0, SpecialAbilityConstants.ColdResistance, 1);
        }

        [Test]
        public void ImprovedColdResistanceData()
        {
            AssertData(SpecialAbilityConstants.ImprovedColdResistance, 0, SpecialAbilityConstants.ColdResistance, 2);
        }

        [Test]
        public void GreaterColdResistanceData()
        {
            AssertData(SpecialAbilityConstants.GreaterColdResistance, 0, SpecialAbilityConstants.ColdResistance, 3);
        }

        [Test]
        public void ElectricityResistanceData()
        {
            AssertData(SpecialAbilityConstants.ElectricityResistance, 0, SpecialAbilityConstants.ElectricityResistance, 1);
        }

        [Test]
        public void ImprovedElectricityResistanceData()
        {
            AssertData(SpecialAbilityConstants.ImprovedElectricityResistance, 0, SpecialAbilityConstants.ElectricityResistance, 2);
        }

        [Test]
        public void GreaterElectricityResistanceData()
        {
            AssertData(SpecialAbilityConstants.GreaterElectricityResistance, 0, SpecialAbilityConstants.ElectricityResistance, 3);
        }

        [Test]
        public void FireResistanceData()
        {
            AssertData(SpecialAbilityConstants.FireResistance, 0, SpecialAbilityConstants.FireResistance, 1);
        }

        [Test]
        public void ImprovedFireResistanceData()
        {
            AssertData(SpecialAbilityConstants.ImprovedFireResistance, 0, SpecialAbilityConstants.FireResistance, 2);
        }

        [Test]
        public void GreaterFireResistanceData()
        {
            AssertData(SpecialAbilityConstants.GreaterFireResistance, 0, SpecialAbilityConstants.FireResistance, 3);
        }

        [Test]
        public void SonicResistanceData()
        {
            AssertData(SpecialAbilityConstants.SonicResistance, 0, SpecialAbilityConstants.SonicResistance, 1);
        }

        [Test]
        public void ImprovedSonicResistanceData()
        {
            AssertData(SpecialAbilityConstants.ImprovedSonicResistance, 0, SpecialAbilityConstants.SonicResistance, 2);
        }

        [Test]
        public void GreaterSonicResistanceData()
        {
            AssertData(SpecialAbilityConstants.GreaterSonicResistance, 0, SpecialAbilityConstants.SonicResistance, 3);
        }

        [Test]
        public void AnarchicData()
        {
            AssertData(SpecialAbilityConstants.Anarchic, 2, SpecialAbilityConstants.Anarchic, 0);
        }

        [Test]
        public void AxiomaticData()
        {
            AssertData(SpecialAbilityConstants.Axiomatic, 2, SpecialAbilityConstants.Axiomatic, 0);
        }

        [Test]
        public void BaneData()
        {
            AssertData(SpecialAbilityConstants.Bane, 1, SpecialAbilityConstants.Bane, 0);
        }

        [Test]
        public void DistanceData()
        {
            AssertData(SpecialAbilityConstants.Distance, 1, SpecialAbilityConstants.Distance, 0);
        }

        [Test]
        public void FlamingData()
        {
            AssertData(SpecialAbilityConstants.Flaming, 1, SpecialAbilityConstants.Flaming, 1);
        }

        [Test]
        public void FrostData()
        {
            AssertData(SpecialAbilityConstants.Frost, 1, SpecialAbilityConstants.Frost, 1);
        }

        [Test]
        public void MercifulData()
        {
            AssertData(SpecialAbilityConstants.Merciful, 1, SpecialAbilityConstants.Merciful, 0);
        }

        [Test]
        public void ReturningData()
        {
            AssertData(SpecialAbilityConstants.Returning, 1, SpecialAbilityConstants.Returning, 0);
        }

        [Test]
        public void ShockData()
        {
            AssertData(SpecialAbilityConstants.Shock, 1, SpecialAbilityConstants.Shock, 1);
        }

        [Test]
        public void SeekingData()
        {
            AssertData(SpecialAbilityConstants.Seeking, 1, SpecialAbilityConstants.Seeking, 0);
        }

        [Test]
        public void ThunderingData()
        {
            AssertData(SpecialAbilityConstants.Thundering, 1, SpecialAbilityConstants.Thundering, 0);
        }

        [Test]
        public void FlamingBurstData()
        {
            AssertData(SpecialAbilityConstants.FlamingBurst, 2, SpecialAbilityConstants.Flaming, 2);
        }

        [Test]
        public void HolyData()
        {
            AssertData(SpecialAbilityConstants.Holy, 2, SpecialAbilityConstants.Holy, 0);
        }

        [Test]
        public void IcyBurstData()
        {
            AssertData(SpecialAbilityConstants.IcyBurst, 2, SpecialAbilityConstants.Frost, 2);
        }

        [Test]
        public void ShockingBurstData()
        {
            AssertData(SpecialAbilityConstants.ShockingBurst, 2, SpecialAbilityConstants.Shock, 2);
        }

        [Test]
        public void UnholyData()
        {
            AssertData(SpecialAbilityConstants.Unholy, 2, SpecialAbilityConstants.Unholy, 0);
        }

        [Test]
        public void SpeedData()
        {
            AssertData(SpecialAbilityConstants.Speed, 3, SpecialAbilityConstants.Speed, 0);
        }

        [Test]
        public void BrilliantEnergyData()
        {
            AssertData(SpecialAbilityConstants.BrilliantEnergy, 4, SpecialAbilityConstants.BrilliantEnergy, 0);
        }

        [Test]
        public void DefendingData()
        {
            AssertData(SpecialAbilityConstants.Defending, 1, SpecialAbilityConstants.Defending, 0);
        }

        [Test]
        public void GhostTouchWeaponData()
        {
            AssertData(SpecialAbilityConstants.GhostTouchWeapon, 1, SpecialAbilityConstants.GhostTouch, 0);
        }

        [Test]
        public void KeenData()
        {
            AssertData(SpecialAbilityConstants.Keen, 1, SpecialAbilityConstants.Keen, 0);
        }

        [Test]
        public void KiFocusData()
        {
            AssertData(SpecialAbilityConstants.KiFocus, 1, SpecialAbilityConstants.KiFocus, 0);
        }

        [Test]
        public void MightyCleavingData()
        {
            AssertData(SpecialAbilityConstants.MightyCleaving, 1, SpecialAbilityConstants.MightyCleaving, 0);
        }

        [Test]
        public void SpellStoringData()
        {
            AssertData(SpecialAbilityConstants.SpellStoring, 1, SpecialAbilityConstants.SpellStoring, 0);
        }

        [Test]
        public void ThrowingData()
        {
            AssertData(SpecialAbilityConstants.Throwing, 1, SpecialAbilityConstants.Throwing, 0);
        }

        [Test]
        public void VicousData()
        {
            AssertData(SpecialAbilityConstants.Vicious, 1, SpecialAbilityConstants.Vicious, 0);
        }

        [Test]
        public void DisruptionData()
        {
            AssertData(SpecialAbilityConstants.Disruption, 2, SpecialAbilityConstants.Disruption, 0);
        }

        [Test]
        public void DancingData()
        {
            AssertData(SpecialAbilityConstants.Dancing, 4, SpecialAbilityConstants.Dancing, 0);
        }

        [Test]
        public void VorpalData()
        {
            AssertData(SpecialAbilityConstants.Vorpal, 5, SpecialAbilityConstants.Vorpal, 0);
        }

        [Test]
        public void WoundingData()
        {
            AssertData(SpecialAbilityConstants.Wounding, 2, SpecialAbilityConstants.Wounding, 0);
        }

        [Test]
        public void LightFortificationData()
        {
            AssertData(SpecialAbilityConstants.LightFortification, 1, SpecialAbilityConstants.Fortification, 1);
        }

        [Test]
        public void ModerateFortificationData()
        {
            AssertData(SpecialAbilityConstants.ModerateFortification, 3, SpecialAbilityConstants.Fortification, 2);
        }

        [Test]
        public void HeavyFortificationData()
        {
            AssertData(SpecialAbilityConstants.HeavyFortification, 5, SpecialAbilityConstants.Fortification, 3);
        }

        [Test]
        public void SlickData()
        {
            AssertData(SpecialAbilityConstants.Slick, 0, SpecialAbilityConstants.Slick, 1);
        }

        [Test]
        public void ShadowData()
        {
            AssertData(SpecialAbilityConstants.Shadow, 0, SpecialAbilityConstants.Shadow, 1);
        }

        [Test]
        public void SilentMovesData()
        {
            AssertData(SpecialAbilityConstants.SilentMoves, 0, SpecialAbilityConstants.SilentMoves, 1);
        }

        [Test]
        public void ImprovedSlickData()
        {
            AssertData(SpecialAbilityConstants.ImprovedSlick, 0, SpecialAbilityConstants.Slick, 2);
        }

        [Test]
        public void ImprovedShadowData()
        {
            AssertData(SpecialAbilityConstants.ImprovedShadow, 0, SpecialAbilityConstants.Shadow, 2);
        }

        [Test]
        public void ImprovedSilentMovesData()
        {
            AssertData(SpecialAbilityConstants.ImprovedSilentMoves, 0, SpecialAbilityConstants.SilentMoves, 2);
        }

        [Test]
        public void GreaterSlickData()
        {
            AssertData(SpecialAbilityConstants.GreaterSlick, 0, SpecialAbilityConstants.Slick, 3);
        }

        [Test]
        public void GreaterShadowData()
        {
            AssertData(SpecialAbilityConstants.GreaterShadow, 0, SpecialAbilityConstants.Shadow, 3);
        }

        [Test]
        public void GreaterSilentMovesData()
        {
            AssertData(SpecialAbilityConstants.GreaterSilentMoves, 0, SpecialAbilityConstants.SilentMoves, 3);
        }

        [Test]
        public void SpellResistance13Data()
        {
            AssertData(SpecialAbilityConstants.SpellResistance13, 2, SpecialAbilityConstants.SpellResistance, 13);
        }

        [Test]
        public void SpellResistance15Data()
        {
            AssertData(SpecialAbilityConstants.SpellResistance15, 3, SpecialAbilityConstants.SpellResistance, 15);
        }

        [Test]
        public void SpellResistance17Data()
        {
            AssertData(SpecialAbilityConstants.SpellResistance17, 4, SpecialAbilityConstants.SpellResistance, 17);
        }

        [Test]
        public void SpellResistance19Data()
        {
            AssertData(SpecialAbilityConstants.SpellResistance19, 5, SpecialAbilityConstants.SpellResistance, 19);
        }

        [Test]
        public void GhostTouchArmorData()
        {
            AssertData(SpecialAbilityConstants.GhostTouchArmor, 3, SpecialAbilityConstants.GhostTouch, 0);
        }

        [Test]
        public void InvulnerabilityData()
        {
            AssertData(SpecialAbilityConstants.Invulnerability, 3, SpecialAbilityConstants.Invulnerability, 0);
        }

        [Test]
        public void WildData()
        {
            AssertData(SpecialAbilityConstants.Wild, 3, SpecialAbilityConstants.Wild, 0);
        }

        [Test]
        public void EtherealnessData()
        {
            AssertData(SpecialAbilityConstants.Etherealness, 0, SpecialAbilityConstants.Etherealness, 0);
        }

        [Test]
        public void UndeadControllingData()
        {
            AssertData(SpecialAbilityConstants.UndeadControlling, 0, SpecialAbilityConstants.UndeadControlling, 0);
        }

        [Test]
        public void ArrowCatchingData()
        {
            AssertData(SpecialAbilityConstants.ArrowCatching, 1, SpecialAbilityConstants.ArrowCatching, 0);
        }

        [Test]
        public void ArrowDeflectionData()
        {
            AssertData(SpecialAbilityConstants.ArrowDeflection, 2, SpecialAbilityConstants.ArrowDeflection, 0);
        }

        [Test]
        public void BashingData()
        {
            AssertData(SpecialAbilityConstants.Bashing, 1, SpecialAbilityConstants.Bashing, 0);
        }

        [Test]
        public void BlindingData()
        {
            AssertData(SpecialAbilityConstants.Blinding, 1, SpecialAbilityConstants.Blinding, 0);
        }

        [Test]
        public void AnimatedData()
        {
            AssertData(SpecialAbilityConstants.Animated, 2, SpecialAbilityConstants.Animated, 0);
        }

        [Test]
        public void ReflectingData()
        {
            AssertData(SpecialAbilityConstants.Reflecting, 5, SpecialAbilityConstants.Reflecting, 0);
        }

        private void AssertData(String name, Int32 bonus, String coreName, Int32 strength)
        {
            Assert.That(data[name].BonusEquivalent, Is.EqualTo(bonus), "bonus");
            Assert.That(data[name].CoreName, Is.EqualTo(coreName));
            Assert.That(data[name].Strength, Is.EqualTo(strength), "strength");
        }
    }
}