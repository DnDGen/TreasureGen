using System;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Tables
{
    [TestFixture]
    public class TableConstantsTests
    {
        [TestCase(TableConstants.AttributesTableNames.FormattableNames.ITEMTYPEAttributes, "{0}Attributes")]
        [TestCase(TableConstants.AttributesTableNames.FormattableNames.ITEMTYPESpecialAbilities, "{0}SpecialAbilities")]
        [TestCase(TableConstants.AttributesTableNames.FormattableNames.ITEMTYPETraits, "{0}Traits")]
        [TestCase(TableConstants.AttributesTableNames.FormattableNames.POWERITEMTYPE, "{0}{1}")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.AmmunitionAttributes, "AmmunitionAttributes")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.ChargeLimits, "ChargeLimits")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.IntelligenceAttributes, "IntelligenceAttributes")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.IntelligenceCommunication, "IntelligenceCommunication")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.ItemAlignmentRequirements, "ItemAlignmentRequirements")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.SpecialAbilityAttributeRequirements, "SpecialAbilityAttributeRequirements")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.SpecialAbilityAttributes, "SpecialAbilityAttributes")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.SpecialMaterials, "SpecialMaterials")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.SpecificShieldsAttributes, "SpecificShieldsAttributes")]
        [TestCase(TableConstants.AttributesTableNames.SetNames.WondrousItemContents, "WondrousItemContents")]
        [TestCase(TableConstants.PercentileTableNames.FormattableNames.ITEMTYPETraits, "{0}Traits")]
        [TestCase(TableConstants.PercentileTableNames.FormattableNames.LevelXCoins, "Level{0}Coins")]
        [TestCase(TableConstants.PercentileTableNames.FormattableNames.LevelXGoods, "Level{0}Goods")]
        [TestCase(TableConstants.PercentileTableNames.FormattableNames.LevelXItems, "Level{0}Items")]
        [TestCase(TableConstants.PercentileTableNames.FormattableNames.LevelXSPELLTYPESpells, "Level{0}{1}Spells")]
        [TestCase(TableConstants.PercentileTableNames.FormattableNames.POWERITEMTYPEs, "{0}{1}s")]
        [TestCase(TableConstants.PercentileTableNames.FormattableNames.POWERSpellLevels, "{0}SpellLevels")]
        [TestCase(TableConstants.PercentileTableNames.FormattableNames.WEAPONTYPEWeapons, "{0}Weapons")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.AlchemicalItems, "AlchemicalItems")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.Ammunitions, "Ammunitions")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.ArmorSizes, "ArmorSizes")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.BalorOrPitFiend, "BalorOrPitFiend")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.CastersShieldContainsSpell, "CastersShieldContainsSpell")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.CastersShieldSpellTypes, "CastersShieldSpellTypes")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.CursedDependentSituations, "CursedDependentSituations")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.CurseDrawbacks, "CurseDrawbacks")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.CurseHeightChanges, "CurseHeightChanges")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.Curses, "Curses")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.DarkwoodShields, "DarkwoodShields")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.DesignatedFoes, "DesignatedFoes")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.Elements, "Elements")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.HasSpecialMaterial, "HasSpecialMaterial")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.HornOfValhallaTypes, "HornOfValhallaTypes")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.IntelligenceAlignments, "IntelligenceAlignments")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.IntelligenceDedicatedPowers, "IntelligenceDedicatedPowers")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.IntelligenceSpecialPurposes, "IntelligenceSpecialPurposes")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.IntelligenceStrongStats, "IntelligenceStrongStats")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.IronFlaskContents, "IronFlaskContents")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.IsDeckOfIllusionsFullyCharged, "IsDeckOfIllusionsFullyCharged")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.IsItemCursed, "IsItemCursed")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.KnowledgeCategories, "KnowledgeCategories")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.MeleeWeaponTraits, "MeleeWeaponTraits")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.MundaneArmors, "MundaneArmors")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.MundaneWeapons, "MundaneWeapons")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.PersonalityTraits, "PersonalityTraits")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.Planes, "Planes")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.ProtectionAlignments, "ProtectionAlignments")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.RangedWeaponTraits, "RangedWeaponTraits")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.RobeOfUsefulItemsExtraItems, "RobeOfUsefulItemsExtraItems")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.RodOfAbsorptionContainsSpellLevels, "RodOfAbsorptionContainsSpellLevels")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.SpecificCursedItems, "SpecificCursedItems")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.SpellStoringContainsSpell, "SpellStoringContainsSpell")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.SpellTypes, "SpellTypes")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.Tools, "Tools")]
        [TestCase(TableConstants.PercentileTableNames.SetNames.WeaponTypes, "WeaponTypes")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}