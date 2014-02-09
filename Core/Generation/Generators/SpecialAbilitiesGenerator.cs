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
        private ITypesProvider typesProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IDice dice;
        private ISpellGenerator spellGenerator;

        public SpecialAbilitiesGenerator(ISpecialAbilityDataProvider specialAbilityDataProvider, ITypesProvider typesProvider,
            IPercentileResultProvider percentileResultProvider, IDice dice, ISpellGenerator spellGenerator)
        {
            this.specialAbilityDataProvider = specialAbilityDataProvider;
            this.typesProvider = typesProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
            this.spellGenerator = spellGenerator;
        }

        public IEnumerable<SpecialAbility> GenerateFor(IEnumerable<String> types, String power, Int32 magicalBonus, Int32 quantity)
        {
            if (magicalBonus <= 0)
                return Enumerable.Empty<SpecialAbility>();

            var abilities = new List<SpecialAbility>();
            var bonusSum = magicalBonus;

            while (quantity > 0 && bonusSum < 10)
            {
                var ability = GenerateFor(types, power);
                if (ability.Name == "BonusSpecialAbility")
                {
                    quantity++;
                    continue;
                }

                if (bonusSum + ability.BonusEquivalent > 10)
                    continue;

                if (abilities.Any(a => a.CoreName == ability.CoreName))
                {
                    var previousAbility = abilities.First(a => a.CoreName == ability.CoreName);
                    if (previousAbility.Strength < ability.Strength)
                    {
                        bonusSum -= previousAbility.BonusEquivalent;
                        abilities.Remove(previousAbility);
                    }
                    else
                    {
                        continue;
                    }
                }

                quantity--;
                bonusSum += ability.BonusEquivalent;
                abilities.Add(ability);
            }

            return abilities;
        }

        public SpecialAbility GenerateFor(IEnumerable<String> types, String power)
        {
            var tableName = GetTableName(types, power);
            var abilityName = percentileResultProvider.GetResultFrom(tableName);
            var ability = specialAbilityDataProvider.GetDataFor(abilityName);

            while (!AllTypeRequirementsMet(ability.TypeRequirements, types))
            {
                abilityName = percentileResultProvider.GetResultFrom(tableName);
                ability = specialAbilityDataProvider.GetDataFor(abilityName);
            }

            if (ability.CoreName == "Bane")
            {
                var designatedFoe = percentileResultProvider.GetResultFrom("DesignatedFoes");
                ability.Name = String.Format("{0}bane", designatedFoe);
            }
            else if (ability.CoreName == "Spell storing" && dice.Percentile() > 50)
            {
                var level = dice.d3();
                var spellType = spellGenerator.GenerateType();
                var spell = spellGenerator.GenerateOfTypeAtLevel(spellType, level);
                ability.Name = String.Format("Spell storing (contains {0})", spell);
            }

            return ability;
        }

        private String GetTableName(IEnumerable<String> types, String power)
        {
            if (types.Contains(TypeConstants.Shield))
                return String.Format("{0}ShieldSpecialAbilities", power);

            if (types.Contains(TypeConstants.Melee))
                return String.Format("{0}MeleeWeaponSpecialAbilities", power);

            if (types.Contains(TypeConstants.Ranged))
                return String.Format("{0}RangedWeaponSpecialAbilities", power);

            if (types.Contains(ItemTypeConstants.Armor))
                return String.Format("{0}ArmorSpecialAbilities", power);

            throw new ArgumentException("invalid types for special abilities");
        }

        private Boolean AllTypeRequirementsMet(IEnumerable<String> requirements, IEnumerable<String> types)
        {
            return requirements.All(r => types.Contains(r));
        }
    }
}