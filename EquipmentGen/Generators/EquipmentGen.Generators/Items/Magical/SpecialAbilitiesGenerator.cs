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

        private ISpecialAbilityDataSelector specialAbilityDataSelector;
        private IAttributesSelector attributesSelector;
        private IPercentileSelector percentileSelector;
        private IDice dice;
        private ISpellGenerator spellGenerator;

        public SpecialAbilitiesGenerator(ISpecialAbilityDataSelector specialAbilityDataSelector, IAttributesSelector attributesSelector,
            IPercentileSelector percentileSelector, IDice dice, ISpellGenerator spellGenerator)
        {
            this.specialAbilityDataSelector = specialAbilityDataSelector;
            this.attributesSelector = attributesSelector;
            this.percentileSelector = percentileSelector;
            this.dice = dice;
            this.spellGenerator = spellGenerator;
        }

        public IEnumerable<SpecialAbility> GenerateWith(IEnumerable<String> attributes, String power, Int32 magicalBonus, Int32 quantity)
        {
            if (magicalBonus <= 0)
                return Enumerable.Empty<SpecialAbility>();

            var tableName = GetTableName(attributes, power);
            var bonusSum = magicalBonus;
            var availableAbilities = GetAvailableAbilities(tableName, bonusSum, attributes);
            var abilities = new List<SpecialAbility>();

            while (quantity > 0 && availableAbilities.Count > 0)
            {
                if (CanHaveAllAvailableAbilities(quantity, bonusSum, availableAbilities))
                {
                    var strongestAbilities = GetStrongestAvailableAbilities(availableAbilities);
                    var duplicates = abilities.Where(a => strongestAbilities.Any(sA => sA.CoreName == a.CoreName));
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

                if (abilities.Any(a => a.CoreName == ability.CoreName))
                {
                    var previousAbility = abilities.First(a => a.CoreName == ability.CoreName);
                    bonusSum -= previousAbility.BonusEquivalent;
                    abilities.Remove(previousAbility);
                }

                quantity--;
                bonusSum += ability.BonusEquivalent;
                abilities.Add(ability);

                var weakerAbilities = availableAbilities.Where(a => a.CoreName == ability.CoreName && a.Strength <= ability.Strength);
                availableAbilities = availableAbilities.Except(weakerAbilities).ToList();

                var tooStrongAbilities = availableAbilities.Where(a => a.BonusEquivalent + bonusSum > 10);
                availableAbilities = availableAbilities.Except(tooStrongAbilities).ToList();
            }

            return abilities;
        }

        private String GetTableName(IEnumerable<String> attributes, String power)
        {
            if (!attributes.Any())
                throw new ArgumentException("no attributes when getting table name for special abilities");

            if (attributes.Contains(AttributeConstants.Shield))
                return String.Format("{0}ShieldSpecialAbilities", power);

            if (attributes.Contains(AttributeConstants.Melee))
                return String.Format("{0}MeleeWeaponSpecialAbilities", power);

            if (attributes.Contains(AttributeConstants.Ranged))
                return String.Format("{0}RangedWeaponSpecialAbilities", power);

            if (attributes.Contains(ItemTypeConstants.Armor))
                return String.Format("{0}ArmorSpecialAbilities", power);

            var attributesString = String.Join(",", attributes);
            throw new ArgumentException("invalid attributes for special abilities: {0}", attributesString);
        }

        private List<SpecialAbility> GetAvailableAbilities(String tableName, Int32 bonus, IEnumerable<String> attributes)
        {
            var abilityNames = percentileSelector.SelectAllFrom(tableName);
            var availableAbilities = new List<SpecialAbility>();

            foreach (var abilityName in abilityNames)
            {
                if (abilityName == "BonusSpecialAbility")
                    continue;

                var ability = specialAbilityDataSelector.SelectFor(abilityName);

                if (AllAttributeRequirementsMet(ability.AttributeRequirements, attributes) && bonus + ability.BonusEquivalent <= MaxBonus)
                    availableAbilities.Add(ability);
            }

            return availableAbilities;
        }

        private Boolean AllAttributeRequirementsMet(IEnumerable<String> requirements, IEnumerable<String> attributes)
        {
            return requirements.All(r => attributes.Contains(r));
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
                var max = availableAbilities.Where(a => a.CoreName == ability.CoreName).Max(a => a.Strength);

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
            if (ability.CoreName == "Bane")
            {
                var roll = dice.Percentile();
                var designatedFoe = percentileSelector.SelectFrom("DesignatedFoes", roll);
                return String.Format("{0}bane", designatedFoe);
            }

            if (ability.CoreName == "Spell storing" && dice.Percentile() > 50)
            {
                var level = dice.d4() - 1;
                var spellType = spellGenerator.GenerateType();
                var spell = spellGenerator.Generate(spellType, level);
                return String.Format("Spell storing (contains {0})", spell);
            }

            return ability.Name;
        }
    }
}