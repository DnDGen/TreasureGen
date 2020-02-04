﻿using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;
using System;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Potion)]
        public MagicalItemGenerator PotionGenerator { get; set; }
        [Inject]
        public ClientIDManager ClientIDManager { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            ClientIDManager.SetClientID(Guid.NewGuid());
        }

        [TestCase(PotionConstants.Aid, PowerConstants.Minor)]
        [TestCase(PotionConstants.Aid, PowerConstants.Medium)]
        [TestCase(PotionConstants.Aid, PowerConstants.Major)]
        [TestCase(PotionConstants.Barkskin, PowerConstants.Minor)]
        [TestCase(PotionConstants.Barkskin, PowerConstants.Medium)]
        [TestCase(PotionConstants.Barkskin, PowerConstants.Major)]
        [TestCase(PotionConstants.BearsEndurance, PowerConstants.Minor)]
        [TestCase(PotionConstants.BearsEndurance, PowerConstants.Medium)]
        [TestCase(PotionConstants.BearsEndurance, PowerConstants.Major)]
        [TestCase(PotionConstants.BlessWeapon, PowerConstants.Minor)]
        [TestCase(PotionConstants.BlessWeapon, PowerConstants.Medium)]
        [TestCase(PotionConstants.BlessWeapon, PowerConstants.Major)]
        [TestCase(PotionConstants.Blur, PowerConstants.Minor)]
        [TestCase(PotionConstants.Blur, PowerConstants.Medium)]
        [TestCase(PotionConstants.Blur, PowerConstants.Major)]
        [TestCase(PotionConstants.BullsStrength, PowerConstants.Minor)]
        [TestCase(PotionConstants.BullsStrength, PowerConstants.Medium)]
        [TestCase(PotionConstants.BullsStrength, PowerConstants.Major)]
        [TestCase(PotionConstants.CatsGrace, PowerConstants.Minor)]
        [TestCase(PotionConstants.CatsGrace, PowerConstants.Medium)]
        [TestCase(PotionConstants.CatsGrace, PowerConstants.Major)]
        [TestCase(PotionConstants.CureLightWounds, PowerConstants.Minor)]
        [TestCase(PotionConstants.CureLightWounds, PowerConstants.Medium)]
        [TestCase(PotionConstants.CureLightWounds, PowerConstants.Major)]
        [TestCase(PotionConstants.CureModerateWounds, PowerConstants.Minor)]
        [TestCase(PotionConstants.CureModerateWounds, PowerConstants.Medium)]
        [TestCase(PotionConstants.CureModerateWounds, PowerConstants.Major)]
        [TestCase(PotionConstants.CureSeriousWounds, PowerConstants.Minor)]
        [TestCase(PotionConstants.CureSeriousWounds, PowerConstants.Medium)]
        [TestCase(PotionConstants.CureSeriousWounds, PowerConstants.Major)]
        [TestCase(PotionConstants.Darkness, PowerConstants.Minor)]
        [TestCase(PotionConstants.Darkness, PowerConstants.Medium)]
        [TestCase(PotionConstants.Darkness, PowerConstants.Major)]
        [TestCase(PotionConstants.Darkvision, PowerConstants.Minor)]
        [TestCase(PotionConstants.Darkvision, PowerConstants.Medium)]
        [TestCase(PotionConstants.Darkvision, PowerConstants.Major)]
        [TestCase(PotionConstants.Daylight, PowerConstants.Minor)]
        [TestCase(PotionConstants.Daylight, PowerConstants.Medium)]
        [TestCase(PotionConstants.Daylight, PowerConstants.Major)]
        [TestCase(PotionConstants.DelayPoison, PowerConstants.Minor)]
        [TestCase(PotionConstants.DelayPoison, PowerConstants.Medium)]
        [TestCase(PotionConstants.DelayPoison, PowerConstants.Major)]
        [TestCase(PotionConstants.Displacement, PowerConstants.Minor)]
        [TestCase(PotionConstants.Displacement, PowerConstants.Medium)]
        [TestCase(PotionConstants.Displacement, PowerConstants.Major)]
        [TestCase(PotionConstants.EaglesSplendor, PowerConstants.Minor)]
        [TestCase(PotionConstants.EaglesSplendor, PowerConstants.Medium)]
        [TestCase(PotionConstants.EaglesSplendor, PowerConstants.Major)]
        [TestCase(PotionConstants.EndureElements, PowerConstants.Minor)]
        [TestCase(PotionConstants.EndureElements, PowerConstants.Medium)]
        [TestCase(PotionConstants.EndureElements, PowerConstants.Major)]
        [TestCase(PotionConstants.EnlargePerson, PowerConstants.Minor)]
        [TestCase(PotionConstants.EnlargePerson, PowerConstants.Medium)]
        [TestCase(PotionConstants.EnlargePerson, PowerConstants.Major)]
        [TestCase(PotionConstants.FlameArrow, PowerConstants.Minor)]
        [TestCase(PotionConstants.FlameArrow, PowerConstants.Medium)]
        [TestCase(PotionConstants.FlameArrow, PowerConstants.Major)]
        [TestCase(PotionConstants.Fly, PowerConstants.Minor)]
        [TestCase(PotionConstants.Fly, PowerConstants.Medium)]
        [TestCase(PotionConstants.Fly, PowerConstants.Major)]
        [TestCase(PotionConstants.FoxsCunning, PowerConstants.Minor)]
        [TestCase(PotionConstants.FoxsCunning, PowerConstants.Medium)]
        [TestCase(PotionConstants.FoxsCunning, PowerConstants.Major)]
        [TestCase(PotionConstants.GaseousForm, PowerConstants.Minor)]
        [TestCase(PotionConstants.GaseousForm, PowerConstants.Medium)]
        [TestCase(PotionConstants.GaseousForm, PowerConstants.Major)]
        [TestCase(PotionConstants.GoodHope, PowerConstants.Minor)]
        [TestCase(PotionConstants.GoodHope, PowerConstants.Medium)]
        [TestCase(PotionConstants.GoodHope, PowerConstants.Major)]
        [TestCase(PotionConstants.Haste, PowerConstants.Minor)]
        [TestCase(PotionConstants.Haste, PowerConstants.Medium)]
        [TestCase(PotionConstants.Haste, PowerConstants.Major)]
        [TestCase(PotionConstants.Heroism, PowerConstants.Minor)]
        [TestCase(PotionConstants.Heroism, PowerConstants.Medium)]
        [TestCase(PotionConstants.Heroism, PowerConstants.Major)]
        [TestCase(PotionConstants.HideFromAnimals, PowerConstants.Minor)]
        [TestCase(PotionConstants.HideFromAnimals, PowerConstants.Medium)]
        [TestCase(PotionConstants.HideFromAnimals, PowerConstants.Major)]
        [TestCase(PotionConstants.HideFromUndead, PowerConstants.Minor)]
        [TestCase(PotionConstants.HideFromUndead, PowerConstants.Medium)]
        [TestCase(PotionConstants.HideFromUndead, PowerConstants.Major)]
        [TestCase(PotionConstants.Invisibility_Oil, PowerConstants.Minor)]
        [TestCase(PotionConstants.Invisibility_Oil, PowerConstants.Medium)]
        [TestCase(PotionConstants.Invisibility_Oil, PowerConstants.Major)]
        [TestCase(PotionConstants.Invisibility_Potion, PowerConstants.Minor)]
        [TestCase(PotionConstants.Invisibility_Potion, PowerConstants.Medium)]
        [TestCase(PotionConstants.Invisibility_Potion, PowerConstants.Major)]
        [TestCase(PotionConstants.Jump, PowerConstants.Minor)]
        [TestCase(PotionConstants.Jump, PowerConstants.Medium)]
        [TestCase(PotionConstants.Jump, PowerConstants.Major)]
        [TestCase(PotionConstants.KeenEdge, PowerConstants.Minor)]
        [TestCase(PotionConstants.KeenEdge, PowerConstants.Medium)]
        [TestCase(PotionConstants.KeenEdge, PowerConstants.Major)]
        [TestCase(PotionConstants.Levitate_Oil, PowerConstants.Minor)]
        [TestCase(PotionConstants.Levitate_Oil, PowerConstants.Medium)]
        [TestCase(PotionConstants.Levitate_Oil, PowerConstants.Major)]
        [TestCase(PotionConstants.Levitate_Potion, PowerConstants.Minor)]
        [TestCase(PotionConstants.Levitate_Potion, PowerConstants.Medium)]
        [TestCase(PotionConstants.Levitate_Potion, PowerConstants.Major)]
        [TestCase(PotionConstants.MageArmor, PowerConstants.Minor)]
        [TestCase(PotionConstants.MageArmor, PowerConstants.Medium)]
        [TestCase(PotionConstants.MageArmor, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicCircleAgainstChaos, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicCircleAgainstChaos, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicCircleAgainstChaos, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicCircleAgainstEvil, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicCircleAgainstEvil, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicCircleAgainstEvil, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicCircleAgainstGood, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicCircleAgainstGood, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicCircleAgainstGood, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicCircleAgainstLaw, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicCircleAgainstLaw, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicCircleAgainstLaw, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicCircleAgainstPARTIALALIGNMENT, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicCircleAgainstPARTIALALIGNMENT, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicCircleAgainstPARTIALALIGNMENT, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicFang, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicFang, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicFang, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicFang_Greater, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicFang_Greater, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicFang_Greater, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicStone, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicStone, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicStone, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicVestment, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicVestment, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicVestment, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicWeapon, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicWeapon, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicWeapon, PowerConstants.Major)]
        [TestCase(PotionConstants.MagicWeapon_Greater, PowerConstants.Minor)]
        [TestCase(PotionConstants.MagicWeapon_Greater, PowerConstants.Medium)]
        [TestCase(PotionConstants.MagicWeapon_Greater, PowerConstants.Major)]
        [TestCase(PotionConstants.Misdirection, PowerConstants.Minor)]
        [TestCase(PotionConstants.Misdirection, PowerConstants.Medium)]
        [TestCase(PotionConstants.Misdirection, PowerConstants.Major)]
        [TestCase(PotionConstants.NeutralizePoison, PowerConstants.Minor)]
        [TestCase(PotionConstants.NeutralizePoison, PowerConstants.Medium)]
        [TestCase(PotionConstants.NeutralizePoison, PowerConstants.Major)]
        [TestCase(PotionConstants.Nondetection, PowerConstants.Minor)]
        [TestCase(PotionConstants.Nondetection, PowerConstants.Medium)]
        [TestCase(PotionConstants.Nondetection, PowerConstants.Major)]
        [TestCase(PotionConstants.OwlsWisdom, PowerConstants.Minor)]
        [TestCase(PotionConstants.OwlsWisdom, PowerConstants.Medium)]
        [TestCase(PotionConstants.OwlsWisdom, PowerConstants.Major)]
        [TestCase(PotionConstants.PassWithoutTrace, PowerConstants.Minor)]
        [TestCase(PotionConstants.PassWithoutTrace, PowerConstants.Medium)]
        [TestCase(PotionConstants.PassWithoutTrace, PowerConstants.Major)]
        [TestCase(PotionConstants.Poison, PowerConstants.Minor)]
        [TestCase(PotionConstants.Poison, PowerConstants.Medium)]
        [TestCase(PotionConstants.Poison, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromAcid, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromAcid, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromAcid, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromArrows_10, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromArrows_10, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromArrows_10, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromArrows_15, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromArrows_15, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromArrows_15, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromChaos, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromChaos, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromChaos, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromCold, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromCold, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromCold, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromElectricity, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromElectricity, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromElectricity, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromENERGY, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromENERGY, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromENERGY, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromEvil, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromEvil, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromEvil, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromFire, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromFire, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromFire, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromGood, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromGood, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromGood, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromLaw, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromLaw, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromLaw, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromPARTIALALIGNMENT, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromPARTIALALIGNMENT, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromPARTIALALIGNMENT, PowerConstants.Major)]
        [TestCase(PotionConstants.ProtectionFromSonic, PowerConstants.Minor)]
        [TestCase(PotionConstants.ProtectionFromSonic, PowerConstants.Medium)]
        [TestCase(PotionConstants.ProtectionFromSonic, PowerConstants.Major)]
        [TestCase(PotionConstants.Rage, PowerConstants.Minor)]
        [TestCase(PotionConstants.Rage, PowerConstants.Medium)]
        [TestCase(PotionConstants.Rage, PowerConstants.Major)]
        [TestCase(PotionConstants.ReducePerson, PowerConstants.Minor)]
        [TestCase(PotionConstants.ReducePerson, PowerConstants.Medium)]
        [TestCase(PotionConstants.ReducePerson, PowerConstants.Major)]
        [TestCase(PotionConstants.RemoveBlindnessDeafness, PowerConstants.Minor)]
        [TestCase(PotionConstants.RemoveBlindnessDeafness, PowerConstants.Medium)]
        [TestCase(PotionConstants.RemoveBlindnessDeafness, PowerConstants.Major)]
        [TestCase(PotionConstants.RemoveCurse, PowerConstants.Minor)]
        [TestCase(PotionConstants.RemoveCurse, PowerConstants.Medium)]
        [TestCase(PotionConstants.RemoveCurse, PowerConstants.Major)]
        [TestCase(PotionConstants.RemoveDisease, PowerConstants.Minor)]
        [TestCase(PotionConstants.RemoveDisease, PowerConstants.Medium)]
        [TestCase(PotionConstants.RemoveDisease, PowerConstants.Major)]
        [TestCase(PotionConstants.RemoveFear, PowerConstants.Minor)]
        [TestCase(PotionConstants.RemoveFear, PowerConstants.Medium)]
        [TestCase(PotionConstants.RemoveFear, PowerConstants.Major)]
        [TestCase(PotionConstants.RemoveParalysis, PowerConstants.Minor)]
        [TestCase(PotionConstants.RemoveParalysis, PowerConstants.Medium)]
        [TestCase(PotionConstants.RemoveParalysis, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistAcid_10, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistAcid_10, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistAcid_10, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistAcid_20, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistAcid_20, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistAcid_20, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistAcid_30, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistAcid_30, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistAcid_30, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistCold_10, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistCold_10, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistCold_10, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistCold_20, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistCold_20, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistCold_20, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistCold_30, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistCold_30, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistCold_30, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistElectricity_10, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistElectricity_10, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistElectricity_10, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistElectricity_20, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistElectricity_20, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistElectricity_20, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistElectricity_30, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistElectricity_30, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistElectricity_30, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistENERGY_10, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistENERGY_10, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistENERGY_10, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistENERGY_20, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistENERGY_20, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistENERGY_20, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistENERGY_30, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistENERGY_30, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistENERGY_30, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistFire_10, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistFire_10, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistFire_10, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistFire_20, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistFire_20, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistFire_20, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistFire_30, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistFire_30, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistFire_30, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistSonic_10, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistSonic_10, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistSonic_10, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistSonic_20, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistSonic_20, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistSonic_20, PowerConstants.Major)]
        [TestCase(PotionConstants.ResistSonic_30, PowerConstants.Minor)]
        [TestCase(PotionConstants.ResistSonic_30, PowerConstants.Medium)]
        [TestCase(PotionConstants.ResistSonic_30, PowerConstants.Major)]
        [TestCase(PotionConstants.Restoration_Lesser, PowerConstants.Minor)]
        [TestCase(PotionConstants.Restoration_Lesser, PowerConstants.Medium)]
        [TestCase(PotionConstants.Restoration_Lesser, PowerConstants.Major)]
        [TestCase(PotionConstants.Sanctuary, PowerConstants.Minor)]
        [TestCase(PotionConstants.Sanctuary, PowerConstants.Medium)]
        [TestCase(PotionConstants.Sanctuary, PowerConstants.Major)]
        [TestCase(PotionConstants.ShieldOfFaith, PowerConstants.Minor)]
        [TestCase(PotionConstants.ShieldOfFaith, PowerConstants.Medium)]
        [TestCase(PotionConstants.ShieldOfFaith, PowerConstants.Major)]
        [TestCase(PotionConstants.Shillelagh, PowerConstants.Minor)]
        [TestCase(PotionConstants.Shillelagh, PowerConstants.Medium)]
        [TestCase(PotionConstants.Shillelagh, PowerConstants.Major)]
        [TestCase(PotionConstants.SpiderClimb, PowerConstants.Minor)]
        [TestCase(PotionConstants.SpiderClimb, PowerConstants.Medium)]
        [TestCase(PotionConstants.SpiderClimb, PowerConstants.Major)]
        [TestCase(PotionConstants.Tongues, PowerConstants.Minor)]
        [TestCase(PotionConstants.Tongues, PowerConstants.Medium)]
        [TestCase(PotionConstants.Tongues, PowerConstants.Major)]
        [TestCase(PotionConstants.UndetectableAlignment, PowerConstants.Minor)]
        [TestCase(PotionConstants.UndetectableAlignment, PowerConstants.Medium)]
        [TestCase(PotionConstants.UndetectableAlignment, PowerConstants.Major)]
        [TestCase(PotionConstants.WaterBreathing, PowerConstants.Minor)]
        [TestCase(PotionConstants.WaterBreathing, PowerConstants.Medium)]
        [TestCase(PotionConstants.WaterBreathing, PowerConstants.Major)]
        [TestCase(PotionConstants.WaterWalk, PowerConstants.Minor)]
        [TestCase(PotionConstants.WaterWalk, PowerConstants.Medium)]
        [TestCase(PotionConstants.WaterWalk, PowerConstants.Major)]
        public void GeneratePotion(string itemName, string power)
        {
            var isOfPower = PotionGenerator.IsItemOfPower(itemName, power);
            Assert.That(isOfPower, Is.True);

            var item = PotionGenerator.GenerateFrom(power, itemName);
            itemVerifier.AssertItem(item);
        }
    }
}