using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class SpecificGearGenerator : ISpecificGearGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IAttributesSelector attributesSelector;
        private ISpecialAbilityAttributesSelector specialAbilityAttributesSelector;
        private IChargesGenerator chargesGenerator;
        private IPercentileSelector percentileSelector;
        private ISpellGenerator spellGenerator;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public SpecificGearGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IAttributesSelector attributesSelector, ISpecialAbilityAttributesSelector specialAbilityAttributesSelector, IChargesGenerator chargesGenerator, IPercentileSelector percentileSelector, ISpellGenerator spellGenerator, IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.attributesSelector = attributesSelector;
            this.specialAbilityAttributesSelector = specialAbilityAttributesSelector;
            this.chargesGenerator = chargesGenerator;
            this.percentileSelector = percentileSelector;
            this.spellGenerator = spellGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public Item GenerateFrom(String power, String specificGearType)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, specificGearType);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            var gear = new Item();
            gear.Name = result.Type;
            gear.Magic.Bonus = result.Amount;
            gear.Magic.SpecialAbilities = GetSpecialAbilities(specificGearType, gear.Name);

            if (specificGearType == ItemTypeConstants.Weapon)
                gear.ItemType = ItemTypeConstants.Weapon;
            else
                gear.ItemType = ItemTypeConstants.Armor;

            tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPEAttributes, specificGearType);
            gear.Attributes = attributesSelector.SelectFrom(tableName, gear.Name);

            tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPETraits, specificGearType);
            var traits = attributesSelector.SelectFrom(tableName, gear.Name);
            gear.Traits.AddRange(traits);

            if (gear.Attributes.Contains(AttributeConstants.Charged))
                gear.Magic.Charges = chargesGenerator.GenerateFor(specificGearType, gear.Name);

            if (gear.Name == WeaponConstants.JavelinOfLightning)
            {
                gear.IsMagical = true;
            }
            else if (gear.Name == ArmorConstants.CastersShield)
            {
                var hasSpell = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell);

                if (hasSpell)
                {
                    var spellType = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes);
                    var spellLevel = spellGenerator.GenerateLevel(PowerConstants.Medium);
                    var spell = spellGenerator.Generate(spellType, spellLevel);
                    var formattedSpell = String.Format("{0} ({1}, {2})", spell, spellType, spellLevel);
                    gear.Contents.Add(formattedSpell);
                }
            }

            gear.Name = RenameGear(gear.Name);

            return gear;
        }

        private String RenameGear(String oldName)
        {
            if (oldName == WeaponConstants.SlayingArrow || oldName == WeaponConstants.GreaterSlayingArrow)
            {
                var designatedFoe = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes);
                return String.Format("{0} ({1})", oldName, designatedFoe);
            }

            switch (oldName)
            {
                case WeaponConstants.SilverDagger: return WeaponConstants.Dagger;
                case WeaponConstants.LuckBlade0: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade1: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade2: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade3: return WeaponConstants.LuckBlade;
                default: return oldName;
            }
        }

        private IEnumerable<SpecialAbility> GetSpecialAbilities(String specificGearType, String name)
        {
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPESpecialAbilities, specificGearType);
            var abilityNames = attributesSelector.SelectFrom(tableName, name);

            return abilityNames.Select(n => ReconstituteAbility(n));
        }

        private SpecialAbility ReconstituteAbility(String name)
        {
            var abilityResult = specialAbilityAttributesSelector.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributes, name);
            var ability = new SpecialAbility();

            ability.Name = name;
            ability.AttributeRequirements = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, abilityResult.BaseName);
            ability.BaseName = abilityResult.BaseName;
            ability.BonusEquivalent = abilityResult.BonusEquivalent;
            ability.Strength = abilityResult.Strength;

            return ability;
        }
    }
}