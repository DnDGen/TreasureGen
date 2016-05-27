﻿using NUnit.Framework;
using System;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Unit.Tables
{
    [TestFixture]
    public class TableNameConstantsTests
    {
        [TestCase(TableNameConstants.Attributes.Formattable.GOODTYPEDescriptions, "{0}Descriptions")]
        [TestCase(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, "{0}Attributes")]
        [TestCase(TableNameConstants.Attributes.Formattable.ITEMTYPESpecialAbilities, "{0}SpecialAbilities")]
        [TestCase(TableNameConstants.Attributes.Formattable.POWERITEMTYPE, "{0}{1}")]
        [TestCase(TableNameConstants.Attributes.Formattable.SpecificITEMTYPEAttributes, "Specific{0}Attributes")]
        [TestCase(TableNameConstants.Attributes.Formattable.SpecificITEMTYPESpecialAbilities, "Specific{0}SpecialAbilities")]
        [TestCase(TableNameConstants.Attributes.Formattable.SpecificITEMTYPETraits, "Specific{0}Traits")]
        [TestCase(TableNameConstants.Attributes.Set.AmmunitionAttributes, "AmmunitionAttributes")]
        [TestCase(TableNameConstants.Attributes.Set.ChargeLimits, "ChargeLimits")]
        [TestCase(TableNameConstants.Attributes.Set.IntelligenceAttributes, "IntelligenceAttributes")]
        [TestCase(TableNameConstants.Attributes.Set.IntelligenceCommunication, "IntelligenceCommunication")]
        [TestCase(TableNameConstants.Attributes.Set.ItemAlignmentRequirements, "ItemAlignmentRequirements")]
        [TestCase(TableNameConstants.Attributes.Set.ReplacementStrings, "ReplacementStrings")]
        [TestCase(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, "SpecialAbilityAttributeRequirements")]
        [TestCase(TableNameConstants.Attributes.Set.SpecialAbilityAttributes, "SpecialAbilityAttributes")]
        [TestCase(TableNameConstants.Attributes.Set.SpecialMaterials, "SpecialMaterials")]
        [TestCase(TableNameConstants.Attributes.Set.SpecificCursedItemItemTypes, "SpecificCursedItemItemTypes")]
        [TestCase(TableNameConstants.Attributes.Set.SpecificCursedItemAttributes, "SpecificCursedItemAttributes")]
        [TestCase(TableNameConstants.Attributes.Set.WondrousItemContents, "WondrousItemContents")]
        [TestCase(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "{0}Types")]
        [TestCase(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, "{0}Values")]
        [TestCase(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Intelligence{0}Powers")]
        [TestCase(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, "Is{0}Intelligent")]
        [TestCase(TableNameConstants.Percentiles.Formattable.LevelXCoins, "Level{0}Coins")]
        [TestCase(TableNameConstants.Percentiles.Formattable.LevelXGoods, "Level{0}Goods")]
        [TestCase(TableNameConstants.Percentiles.Formattable.LevelXItems, "Level{0}Items")]
        [TestCase(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, "Level{0}{1}Spells")]
        [TestCase(TableNameConstants.Percentiles.Formattable.POWERItems, "{0}Items")]
        [TestCase(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, "{0}{1}s")]
        [TestCase(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, "{0}{1}SpecialAbilities")]
        [TestCase(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, "{0}Specific{1}s")]
        [TestCase(TableNameConstants.Percentiles.Formattable.POWERSpellLevels, "{0}SpellLevels")]
        [TestCase(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "{0}Weapons")]
        [TestCase(TableNameConstants.Percentiles.Set.AlchemicalItems, "AlchemicalItems")]
        [TestCase(TableNameConstants.Percentiles.Set.Ammunitions, "Ammunitions")]
        [TestCase(TableNameConstants.Percentiles.Set.MundaneGearSizes, "MundaneGearSizes")]
        [TestCase(TableNameConstants.Percentiles.Set.BalorOrPitFiend, "BalorOrPitFiend")]
        [TestCase(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell, "CastersShieldContainsSpell")]
        [TestCase(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes, "CastersShieldSpellTypes")]
        [TestCase(TableNameConstants.Percentiles.Set.CursedDependentSituations, "CursedDependentSituations")]
        [TestCase(TableNameConstants.Percentiles.Set.CurseDrawbacks, "CurseDrawbacks")]
        [TestCase(TableNameConstants.Percentiles.Set.CurseHeightChanges, "CurseHeightChanges")]
        [TestCase(TableNameConstants.Percentiles.Set.Curses, "Curses")]
        [TestCase(TableNameConstants.Percentiles.Set.DarkwoodShields, "DarkwoodShields")]
        [TestCase(TableNameConstants.Percentiles.Set.DesignatedFoes, "DesignatedFoes")]
        [TestCase(TableNameConstants.Percentiles.Set.Elements, "Elements")]
        [TestCase(TableNameConstants.Percentiles.Set.Gender, "Gender")]
        [TestCase(TableNameConstants.Percentiles.Set.HasSpecialMaterial, "HasSpecialMaterial")]
        [TestCase(TableNameConstants.Percentiles.Set.HornOfValhallaTypes, "HornOfValhallaTypes")]
        [TestCase(TableNameConstants.Percentiles.Set.IntelligenceAlignments, "IntelligenceAlignments")]
        [TestCase(TableNameConstants.Percentiles.Set.IntelligenceDedicatedPowers, "IntelligenceDedicatedPowers")]
        [TestCase(TableNameConstants.Percentiles.Set.IntelligenceSpecialPurposes, "IntelligenceSpecialPurposes")]
        [TestCase(TableNameConstants.Percentiles.Set.IntelligenceStrongStats, "IntelligenceStrongStats")]
        [TestCase(TableNameConstants.Percentiles.Set.IronFlaskContents, "IronFlaskContents")]
        [TestCase(TableNameConstants.Percentiles.Set.IsDeckOfIllusionsFullyCharged, "IsDeckOfIllusionsFullyCharged")]
        [TestCase(TableNameConstants.Percentiles.Set.IsItemCursed, "IsItemCursed")]
        [TestCase(TableNameConstants.Percentiles.Set.IsMasterwork, "IsMasterwork")]
        [TestCase(TableNameConstants.Percentiles.Set.KnowledgeCategories, "KnowledgeCategories")]
        [TestCase(TableNameConstants.Percentiles.Set.Languages, "Languages")]
        [TestCase(TableNameConstants.Percentiles.Set.MundaneShields, "MundaneShields")]
        [TestCase(TableNameConstants.Percentiles.Set.MeleeWeaponTraits, "MeleeWeaponTraits")]
        [TestCase(TableNameConstants.Percentiles.Set.MundaneArmors, "MundaneArmors")]
        [TestCase(TableNameConstants.Percentiles.Set.MundaneWeapons, "MundaneWeapons")]
        [TestCase(TableNameConstants.Percentiles.Set.PersonalityTraits, "PersonalityTraits")]
        [TestCase(TableNameConstants.Percentiles.Set.Planes, "Planes")]
        [TestCase(TableNameConstants.Percentiles.Set.PartialAlignments, "PartialAlignments")]
        [TestCase(TableNameConstants.Percentiles.Set.FullAlignments, "FullAlignments")]
        [TestCase(TableNameConstants.Percentiles.Set.RangedWeaponTraits, "RangedWeaponTraits")]
        [TestCase(TableNameConstants.Percentiles.Set.RobeOfTheArchmagiColors, "RobeOfTheArchmagiColors")]
        [TestCase(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems, "RobeOfUsefulItemsExtraItems")]
        [TestCase(TableNameConstants.Percentiles.Set.RodOfAbsorptionContainsSpellLevels, "RodOfAbsorptionContainsSpellLevels")]
        [TestCase(TableNameConstants.Percentiles.Set.SpecificCursedItems, "SpecificCursedItems")]
        [TestCase(TableNameConstants.Percentiles.Set.SpellStoringContainsSpell, "SpellStoringContainsSpell")]
        [TestCase(TableNameConstants.Percentiles.Set.SpellTypes, "SpellTypes")]
        [TestCase(TableNameConstants.Percentiles.Set.Tools, "Tools")]
        [TestCase(TableNameConstants.Percentiles.Set.WeaponTypes, "WeaponTypes")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void PercentileItemTypeTraits()
        {
            Assert.That(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, Is.EqualTo("{0}Traits"));
        }

        [Test]
        public void AttributeItemTypeTraits()
        {
            Assert.That(TableNameConstants.Attributes.Formattable.ITEMTYPETraits, Is.EqualTo("{0}Traits"));
        }
    }
}