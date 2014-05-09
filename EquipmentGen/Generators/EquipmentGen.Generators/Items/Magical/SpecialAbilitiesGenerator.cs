using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class SpecialAbilitiesGenerator : ISpecialAbilitiesGenerator
    {
        private const Int32 MaxBonus = 10;

        private IAttributesSelector attributesSelector;
        private ISpecialAbilityAttributesSelector specialAbilityAttributesSelector;
        private IPercentileSelector percentileSelector;
        private IDice dice;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public SpecialAbilitiesGenerator(IAttributesSelector attributesSelector, IPercentileSelector percentileSelector, IDice dice,
            ISpecialAbilityAttributesSelector specialAbilityAttributesSelector, IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.attributesSelector = attributesSelector;
            this.percentileSelector = percentileSelector;
            this.dice = dice;
            this.specialAbilityAttributesSelector = specialAbilityAttributesSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public IEnumerable<SpecialAbility> GenerateFor(String itemType, IEnumerable<String> attributes, String power, Int32 magicalBonus, Int32 quantity)
        {
            if (magicalBonus <= 0)
                return Enumerable.Empty<SpecialAbility>();

            var tableName = GetTableName(itemType, attributes, power);
            var bonusSum = magicalBonus;
            var availableAbilities = GetAvailableAbilities(tableName, bonusSum, attributes);
            var abilities = new List<SpecialAbility>();

            while (quantity > 0 && availableAbilities.Count > 0)
            {
                if (CanHaveAllAvailableAbilities(quantity, bonusSum, availableAbilities))
                {
                    var strongestAbilities = GetStrongestAvailableAbilities(availableAbilities);
                    var duplicates = abilities.Where(a => strongestAbilities.Any(sA => sA.BaseName == a.BaseName));
                    abilities = abilities.Except(duplicates).ToList();

                    abilities.AddRange(strongestAbilities);
                    availableAbilities.Clear();
                    continue;
                }

                var ability = GenerateAbilityFrom(availableAbilities, tableName);
                if (ability.Name == "BonusSpecialAbility")
                {
                    quantity++;
                    continue;
                }

                if (abilities.Any(a => a.BaseName == ability.BaseName))
                {
                    var previousAbility = abilities.First(a => a.BaseName == ability.BaseName);
                    bonusSum -= previousAbility.BonusEquivalent;
                    abilities.Remove(previousAbility);
                }

                quantity--;
                bonusSum += ability.BonusEquivalent;
                abilities.Add(ability);
                availableAbilities.Remove(ability);

                var weakerAbilities = availableAbilities.Where(a => a.BaseName == ability.BaseName && a.Strength < ability.Strength);
                availableAbilities = availableAbilities.Except(weakerAbilities).ToList();

                var tooStrongAbilities = availableAbilities.Where(a => a.BonusEquivalent + bonusSum > 10);
                availableAbilities = availableAbilities.Except(tooStrongAbilities).ToList();
            }

            return abilities;
        }

        private String GetTableName(String itemType, IEnumerable<String> attributes, String power)
        {
            if (itemType == ItemTypeConstants.Weapon)
            {
                if (attributes.Contains(AttributeConstants.Melee))
                    return String.Format("{0}MeleeWeaponSpecialAbilities", power);
                else if (attributes.Contains(AttributeConstants.Ranged))
                    return String.Format("{0}RangedWeaponSpecialAbilities", power);

                var attributesString = String.Join(",", attributes);
                var attributeMessage = String.Format("invalid attributes for special abilities: {0}, {1}", itemType, attributesString);
                throw new ArgumentException(attributeMessage);
            }

            if (itemType == ItemTypeConstants.Armor)
            {
                if (attributes.Contains(AttributeConstants.Shield))
                    return String.Format("{0}ShieldSpecialAbilities", power);

                return String.Format("{0}ArmorSpecialAbilities", power);
            }

            var itemTypeMessage = String.Format("invalid item type for special abilities: {0}", itemType);
            throw new ArgumentException(itemTypeMessage);
        }

        private List<SpecialAbility> GetAvailableAbilities(String tableName, Int32 bonus, IEnumerable<String> attributes)
        {
            var abilityNames = percentileSelector.SelectAllFrom(tableName);
            var availableAbilities = new List<SpecialAbility>();

            foreach (var abilityName in abilityNames)
            {
                if (abilityName == "BonusSpecialAbility")
                    continue;

                var ability = GetSpecialAbility(abilityName);

                if (AllAttributeRequirementsMet(ability.AttributeRequirements, attributes) && bonus + ability.BonusEquivalent <= MaxBonus)
                    availableAbilities.Add(ability);
            }

            return availableAbilities;
        }

        private SpecialAbility GetSpecialAbility(String abilityName)
        {
            var ability = new SpecialAbility();
            var abilityResult = specialAbilityAttributesSelector.SelectFrom("SpecialAbilityAttributes", abilityName);

            ability.Name = abilityName;
            ability.BaseName = abilityResult.BaseName;
            ability.AttributeRequirements = attributesSelector.SelectFrom("SpecialAbilityAttributeRequirements", ability.BaseName);
            ability.BonusEquivalent = abilityResult.BonusEquivalent;
            ability.Strength = abilityResult.Strength;

            return ability;
        }

        private Boolean AllAttributeRequirementsMet(IEnumerable<String> requirements, IEnumerable<String> attributes)
        {
            var missingRequirements = requirements.Except(attributes);
            return !missingRequirements.Any();
        }

        private Boolean CanHaveAllAvailableAbilities(Int32 quantity, Int32 bonusSum, IEnumerable<SpecialAbility> availableAbilities)
        {
            return quantity >= availableAbilities.Count() && availableAbilities.Sum(a => a.BonusEquivalent) + bonusSum <= MaxBonus;
        }

        private IEnumerable<SpecialAbility> GetStrongestAvailableAbilities(IEnumerable<SpecialAbility> availableAbilities)
        {
            var strongestAbilities = new List<SpecialAbility>();

            foreach (var ability in availableAbilities)
            {
                var max = availableAbilities.Where(a => a.BaseName == ability.BaseName).Max(a => a.Strength);

                if (ability.Strength == max)
                {
                    ability.Name = GetModifiedName(ability);
                    strongestAbilities.Add(ability);
                }
            }

            return strongestAbilities;
        }

        private SpecialAbility GenerateAbilityFrom(IEnumerable<SpecialAbility> availableAbilities, String tableName)
        {
            var abilityName = String.Empty;

            do
            {
                var roll = dice.Percentile();
                abilityName = percentileSelector.SelectFrom(tableName, roll);

                if (abilityName == "BonusSpecialAbility")
                    return new SpecialAbility { Name = abilityName };
            } while (!availableAbilities.Any(a => a.Name == abilityName));

            var ability = availableAbilities.First(a => a.Name == abilityName);
            ability.Name = GetModifiedName(ability);

            return ability;
        }

        private String GetModifiedName(SpecialAbility ability)
        {
            if (ability.BaseName != "Bane")
                return ability.Name;

            var roll = dice.Percentile();
            var designatedFoe = percentileSelector.SelectFrom("DesignatedFoes", roll);
            return String.Format("{0}bane", designatedFoe);
        }
    }
}