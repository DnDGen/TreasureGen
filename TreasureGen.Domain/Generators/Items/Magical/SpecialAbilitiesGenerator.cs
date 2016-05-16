using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class SpecialAbilitiesGenerator : ISpecialAbilitiesGenerator
    {
        private const int MaxBonus = 10;

        private IAttributesSelector attributesSelector;
        private ISpecialAbilityAttributesSelector specialAbilityAttributesSelector;
        private IPercentileSelector percentileSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private Dice dice;

        public SpecialAbilitiesGenerator(IAttributesSelector attributesSelector, IPercentileSelector percentileSelector, ISpecialAbilityAttributesSelector specialAbilityAttributesSelector,
            IBooleanPercentileSelector booleanPercentileSelector, Dice dice)
        {
            this.attributesSelector = attributesSelector;
            this.percentileSelector = percentileSelector;
            this.specialAbilityAttributesSelector = specialAbilityAttributesSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.dice = dice;
        }

        public IEnumerable<SpecialAbility> GenerateFor(string itemType, IEnumerable<string> attributes, string power, int magicalBonus, Int32 quantity)
        {
            if (magicalBonus <= 0)
                return Enumerable.Empty<SpecialAbility>();

            var tableNames = GetTableNames(itemType, attributes, power);
            var bonusSum = magicalBonus;
            var availableAbilities = GetAvailableAbilities(tableNames, bonusSum, attributes);
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

                var ability = GenerateAbilityFrom(availableAbilities, tableNames);
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

                var weakerAbilities = availableAbilities.Where(a => a.BaseName == ability.BaseName && a.Power < ability.Power);
                availableAbilities = availableAbilities.Except(weakerAbilities).ToList();

                var tooStrongAbilities = availableAbilities.Where(a => a.BonusEquivalent + bonusSum > 10);
                availableAbilities = availableAbilities.Except(tooStrongAbilities).ToList();
            }

            return abilities;
        }

        private IEnumerable<string> GetTableNames(string itemType, IEnumerable<string> attributes, string power)
        {
            var tableNames = new List<string>();

            if (attributes.Contains(AttributeConstants.Melee))
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Melee);
                tableNames.Add(tableName);
            }

            if (attributes.Contains(AttributeConstants.Ranged))
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Ranged);
                tableNames.Add(tableName);
            }

            if (attributes.Contains(AttributeConstants.Shield))
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Shield);
                tableNames.Add(tableName);
            }
            else if (itemType == ItemTypeConstants.Armor)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, ItemTypeConstants.Armor);
                tableNames.Add(tableName);
            }

            return tableNames;
        }

        private List<SpecialAbility> GetAvailableAbilities(IEnumerable<string> tableNames, int bonus, IEnumerable<string> attributes)
        {
            var availableAbilities = new List<SpecialAbility>();

            foreach (var tableName in tableNames)
            {
                var abilityNames = percentileSelector.SelectAllFrom(tableName);

                foreach (var abilityName in abilityNames)
                {
                    if (abilityName == "BonusSpecialAbility")
                        continue;

                    var ability = GetSpecialAbility(abilityName);

                    if (AllAttributeRequirementsMet(ability.AttributeRequirements, attributes) && bonus + ability.BonusEquivalent <= MaxBonus)
                        availableAbilities.Add(ability);
                }
            }

            return availableAbilities;
        }

        private SpecialAbility GetSpecialAbility(string abilityName)
        {
            var ability = new SpecialAbility();
            var abilityResult = specialAbilityAttributesSelector.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributes, abilityName);

            ability.Name = abilityName;
            ability.BaseName = abilityResult.BaseName;
            ability.AttributeRequirements = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, ability.BaseName);
            ability.BonusEquivalent = abilityResult.BonusEquivalent;
            ability.Power = abilityResult.Power;

            return ability;
        }

        private bool AllAttributeRequirementsMet(IEnumerable<string> requirements, IEnumerable<string> attributes)
        {
            var missingRequirements = requirements.Except(attributes);
            return !missingRequirements.Any();
        }

        private bool CanHaveAllAvailableAbilities(int quantity, int bonusSum, IEnumerable<SpecialAbility> availableAbilities)
        {
            return quantity >= availableAbilities.Count() && availableAbilities.Sum(a => a.BonusEquivalent) + bonusSum <= MaxBonus;
        }

        private IEnumerable<SpecialAbility> GetStrongestAvailableAbilities(IEnumerable<SpecialAbility> availableAbilities)
        {
            var strongestAbilities = new List<SpecialAbility>();

            foreach (var ability in availableAbilities)
            {
                var max = availableAbilities.Where(a => a.BaseName == ability.BaseName).Max(a => a.Power);

                if (ability.Power == max)
                    strongestAbilities.Add(ability);
            }

            return strongestAbilities;
        }

        private SpecialAbility GenerateAbilityFrom(IEnumerable<SpecialAbility> availableAbilities, IEnumerable<string> tableNames)
        {
            var abilityName = string.Empty;

            do
            {
                var index = dice.Roll().d(tableNames.Count()) - 1;
                var tableName = tableNames.ElementAt(index);

                abilityName = percentileSelector.SelectFrom(tableName);

                if (abilityName == "BonusSpecialAbility")
                    return new SpecialAbility { Name = abilityName };
            } while (!availableAbilities.Any(a => a.Name == abilityName));

            return availableAbilities.First(a => a.Name == abilityName);
        }
    }
}