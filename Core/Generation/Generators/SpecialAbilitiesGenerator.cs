using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class SpecialAbilitiesGenerator : ISpecialAbilitiesGenerator
    {
        private ISpecialAbilityDataProvider specialAbilityDataProvider;
        private IAttributesProvider typesProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IDice dice;
        private ISpellGenerator spellGenerator;

        private const Int32 MaxBonus = 10;

        public SpecialAbilitiesGenerator(ISpecialAbilityDataProvider specialAbilityDataProvider, IAttributesProvider typesProvider,
            IPercentileResultProvider percentileResultProvider, IDice dice, ISpellGenerator spellGenerator)
        {
            this.specialAbilityDataProvider = specialAbilityDataProvider;
            this.typesProvider = typesProvider;
            this.percentileResultProvider = percentileResultProvider;
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
                if (quantity >= availableAbilities.Count && availableAbilities.Sum(a => a.BonusEquivalent) + bonusSum <= MaxBonus)
                {
                    var strongestAbilities = GetStrongestAbilities(availableAbilities);

                    foreach (var strongAbility in strongestAbilities)
                        strongAbility.Name = GetModifiedName(strongAbility);

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
                    if (previousAbility.Strength >= ability.Strength)
                        continue;

                    bonusSum -= previousAbility.BonusEquivalent;
                    abilities.Remove(previousAbility);
                }

                quantity--;
                bonusSum += ability.BonusEquivalent;
                abilities.Add(ability);

                var weakerAbilities = availableAbilities.Where(a => a.CoreName == ability.CoreName && a.Strength <= ability.Strength);
                availableAbilities = availableAbilities.Except(weakerAbilities).ToList();

                var tooStrongAbilities = availableAbilities.Where(a => a.BonusEquivalent > 10 - bonusSum);
                availableAbilities = availableAbilities.Except(tooStrongAbilities).ToList();
            }

            return abilities;
        }

        private IEnumerable<SpecialAbility> GetStrongestAbilities(List<SpecialAbility> availableAbilities)
        {
            var abilities = new List<SpecialAbility>();

            foreach (var ability in availableAbilities)
            {
                var perCoreName = availableAbilities.Where(a => a.CoreName == ability.CoreName);

                if (perCoreName.Count() == 1)
                {
                    abilities.Add(ability);
                }
                else
                {
                    var max = perCoreName.Max(a => a.Strength);
                    if (ability.Strength == max)
                        abilities.Add(ability);
                }
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
            var abilityNames = percentileResultProvider.GetAllResultsFrom(tableName);
            var availableAbilities = new List<SpecialAbility>();

            foreach (var abilityName in abilityNames)
            {
                if (abilityName == "BonusSpecialAbility")
                    continue;

                var ability = specialAbilityDataProvider.GetDataFor(abilityName);

                if (AllAttributeRequirementsMet(ability.AttributeRequirements, attributes) && bonus + ability.BonusEquivalent <= MaxBonus)
                    availableAbilities.Add(ability);
            }

            return availableAbilities;
        }

        private Boolean AllAttributeRequirementsMet(IEnumerable<String> requirements, IEnumerable<String> attributes)
        {
            return requirements.All(r => attributes.Contains(r));
        }

        private SpecialAbility GenerateAbilityFrom(IEnumerable<SpecialAbility> availableAbilities, String tableName)
        {
            var abilityName = String.Empty;

            do
            {
                abilityName = percentileResultProvider.GetResultFrom(tableName);

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
                var designatedFoe = percentileResultProvider.GetResultFrom("DesignatedFoes");
                return String.Format("{0}bane", designatedFoe);
            }

            if (ability.CoreName == "Spell storing" && dice.Percentile() > 50)
            {
                var level = dice.d3();
                var spellType = spellGenerator.GenerateType();
                var spell = spellGenerator.Generate(spellType, level);
                return String.Format("Spell storing (contains {0})", spell);
            }

            return ability.Name;
        }
    }
}