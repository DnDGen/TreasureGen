using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Helpers;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class SpecialAbilitiesGenerator : ISpecialAbilitiesGenerator
    {
        private const int MaxBonus = 10;

        private readonly ICollectionSelector collectionsSelector;
        private readonly ISpecialAbilityDataSelector specialAbilityDataSelector;
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly DamageHelper damageHelper;

        public SpecialAbilitiesGenerator(ICollectionSelector collectionsSelector, ITreasurePercentileSelector percentileSelector, ISpecialAbilityDataSelector specialAbilityDataSelector)
        {
            this.collectionsSelector = collectionsSelector;
            this.percentileSelector = percentileSelector;
            this.specialAbilityDataSelector = specialAbilityDataSelector;

            damageHelper = new DamageHelper();
        }

        public IEnumerable<SpecialAbility> GenerateFor(Item targetItem, string power, int quantity)
        {
            if (targetItem.Magic.Bonus <= 0 || quantity <= 0)
                return Enumerable.Empty<SpecialAbility>();

            var tableNames = GetTableNames(targetItem, power);
            var bonusSum = targetItem.Magic.Bonus;
            var availableAbilities = GetAvailableAbilities(targetItem, tableNames, bonusSum);
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

        private IEnumerable<string> GetTableNames(Item targetItem, string power)
        {
            var tableNames = new List<string>();

            if (targetItem.Attributes.Contains(AttributeConstants.Melee))
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Melee);
                tableNames.Add(tableName);
            }

            if (targetItem.Attributes.Contains(AttributeConstants.Ranged))
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Ranged);
                tableNames.Add(tableName);
            }

            if (targetItem.Attributes.Contains(AttributeConstants.Shield))
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, AttributeConstants.Shield);
                tableNames.Add(tableName);
            }
            else if (targetItem.ItemType == ItemTypeConstants.Armor)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, power, ItemTypeConstants.Armor);
                tableNames.Add(tableName);
            }

            return tableNames;
        }

        private List<SpecialAbility> GetAvailableAbilities(Item targetItem, IEnumerable<string> tableNames, int bonus)
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

                    if (ability.RequirementsMet(targetItem) && bonus + ability.BonusEquivalent <= 10)
                        availableAbilities.Add(ability);
                }
            }

            return availableAbilities;
        }

        private SpecialAbility GetSpecialAbility(string abilityName)
        {
            var ability = new SpecialAbility();
            var abilitySelection = specialAbilityDataSelector.SelectFrom(abilityName);

            ability.Name = abilityName;
            ability.BaseName = abilitySelection.BaseName;
            ability.AttributeRequirements = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributeRequirements, ability.BaseName);
            ability.BonusEquivalent = abilitySelection.BonusEquivalent;
            ability.Power = abilitySelection.Power;

            var damagesData = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, abilityName).ToArray();
            if (!damagesData.Any())
            {
                return ability;
            }

            if (!string.IsNullOrEmpty(damagesData[0]))
            {
                var damageEntries = damageHelper.ParseEntries(damagesData[0]);

                foreach (var damageEntry in damageEntries)
                {
                    ability.Damages.Add(new Damage
                    {
                        Roll = damageEntry[DataIndexConstants.Weapon.DamageData.RollIndex],
                        Type = damageEntry[DataIndexConstants.Weapon.DamageData.TypeIndex],
                    });
                }
            }

            if (string.IsNullOrEmpty(damagesData[1]))
            {
                return ability;
            }

            var multipliers = new[] { "x2", "x3", "x4" };

            for (var i = 1; i < damagesData.Length; i++)
            {
                var multiplier = multipliers[i - 1];
                ability.CriticalDamages[multiplier] = new List<Damage>();

                var criticalDamageEntries = damageHelper.ParseEntries(damagesData[i]);

                foreach (var criticalDamageEntry in criticalDamageEntries)
                {
                    var damage = new Damage
                    {
                        Roll = criticalDamageEntry[DataIndexConstants.Weapon.DamageData.RollIndex],
                        Type = criticalDamageEntry[DataIndexConstants.Weapon.DamageData.TypeIndex],
                    };

                    ability.CriticalDamages[multiplier].Add(damage);
                }
            }

            return ability;
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
                var tableName = collectionsSelector.SelectRandomFrom(tableNames);

                abilityName = percentileSelector.SelectFrom(tableName);

                if (abilityName == "BonusSpecialAbility")
                    return new SpecialAbility { Name = abilityName };
            } while (!availableAbilities.Any(a => a.Name == abilityName));

            return availableAbilities.First(a => a.Name == abilityName);
        }

        public IEnumerable<SpecialAbility> GenerateFor(IEnumerable<SpecialAbility> abilityPrototypes)
        {
            var abilities = new List<SpecialAbility>();

            foreach (var abilityPrototype in abilityPrototypes)
            {
                if (specialAbilityDataSelector.IsSpecialAbility(abilityPrototype.Name))
                {
                    var ability = GetSpecialAbility(abilityPrototype.Name);
                    abilities.Add(ability);
                }
                else
                {
                    abilities.Add(abilityPrototype);
                }
            }

            return abilities;
        }
    }
}