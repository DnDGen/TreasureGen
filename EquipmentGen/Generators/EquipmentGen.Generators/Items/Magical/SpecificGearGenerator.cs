using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

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
            var tableName = String.Format("{0}{1}", power, specificGearType);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var itemType = specificGearType.Replace("Specific", String.Empty).TrimEnd('s');

            var gear = new Item();
            gear.Name = result.Type;
            gear.Magic.Bonus = Convert.ToInt32(result.Amount);
            gear.Magic.SpecialAbilities = GetSpecialAbilities(specificGearType, gear.Name);

            if (itemType == ItemTypeConstants.Armor || itemType == AttributeConstants.Shield)
                gear.ItemType = ItemTypeConstants.Armor;
            else
                gear.ItemType = ItemTypeConstants.Weapon;

            tableName = String.Format("{0}Attributes", specificGearType);
            gear.Attributes = attributesSelector.SelectFrom(tableName, gear.Name);

            tableName = String.Format("{0}Traits", specificGearType);
            var traits = attributesSelector.SelectFrom(tableName, gear.Name);
            gear.Traits.AddRange(traits);

            if (gear.Attributes.Contains(AttributeConstants.Charged))
                gear.Magic.Charges = chargesGenerator.GenerateFor(itemType, gear.Name);

            if (gear.Name == "Javelin of lightning")
            {
                gear.IsMagical = true;
            }
            else if (gear.Name == ArmorConstants.CastersShield)
            {
                var hasSpell = booleanPercentileSelector.SelectFrom("CastersShieldContainsSpell");

                if (hasSpell)
                {
                    var spellType = percentileSelector.SelectFrom("CastersShieldSpellTypes");
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
            switch (oldName)
            {
                case WeaponConstants.SilverDagger: return WeaponConstants.Dagger;
                case WeaponConstants.LuckBlade0: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade1: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade2: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade3: return WeaponConstants.LuckBlade;
            }

            if (oldName.Contains("laying arrow"))
            {
                var designatedFoe = percentileSelector.SelectFrom("DesignatedFoes");
                return String.Format("{0} ({1})", oldName, designatedFoe);
            }

            return oldName;
        }

        private IEnumerable<SpecialAbility> GetSpecialAbilities(String specificGearType, String name)
        {
            var tableName = String.Format("{0}SpecialAbilities", specificGearType);
            var abilityNames = attributesSelector.SelectFrom(tableName, name);

            return abilityNames.Select(n => ReconstituteAbility(n));
        }

        private SpecialAbility ReconstituteAbility(String name)
        {
            var abilityResult = specialAbilityAttributesSelector.SelectFrom("SpecialAbilityAttributes", name);
            var ability = new SpecialAbility();

            ability.Name = name;
            ability.AttributeRequirements = attributesSelector.SelectFrom("SpecialAbilityAttributeRequirements", abilityResult.BaseName);
            ability.BaseName = abilityResult.BaseName;
            ability.BonusEquivalent = abilityResult.BonusEquivalent;
            ability.Strength = abilityResult.Strength;

            return ability;
        }
    }
}