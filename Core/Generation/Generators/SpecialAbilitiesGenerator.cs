using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class SpecialAbilitiesGenerator : ISpecialAbilitiesGenerator
    {
        private ISpecialAbilityPercentileResultProvider specialAbilityPercentileResultProvider;

        public SpecialAbilitiesGenerator(ISpecialAbilityPercentileResultProvider specialAbilityPercentileResultProvider)
        {
            this.specialAbilityPercentileResultProvider = specialAbilityPercentileResultProvider;
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

                if (bonusSum + ability.BonusEquivalent > 10)
                    continue;

                if (abilities.Any(a => a.Name == ability.Name))
                {
                    var previousAbility = abilities.First(a => a.Name == ability.Name);
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
            var result = specialAbilityPercentileResultProvider.GetResultFrom(tableName);

            var ability = new SpecialAbility();
            ability.Name = result.Name;
            ability.Strength = result.Strength;
            ability.BonusEquivalent = result.Bonus;

            return ability;
        }

        private String GetTableName(IEnumerable<String> types, String power)
        {
            if (types.Contains(ItemsConstants.Gear.Types.Shield))
                return String.Format("{0}ShieldSpecialAbilities", power);

            if (types.Contains(ItemsConstants.Gear.Types.Melee))
                return String.Format("{0}MeleeWeaponSpecialAbilities", power);

            if (types.Contains(ItemsConstants.Gear.Types.Ranged))
                return String.Format("{0}RangedWeaponSpecialAbilities", power);

            if (types.Contains(ItemsConstants.ItemTypes.Armor))
                return String.Format("{0}ArmorSpecialAbilities", power);

            throw new ArgumentException("invalid types for special abilities");
        }
    }
}