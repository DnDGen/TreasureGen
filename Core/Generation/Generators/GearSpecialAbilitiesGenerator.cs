using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class GearSpecialAbilitiesGenerator : IGearSpecialAbilitiesGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;

        public GearSpecialAbilitiesGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
        }

        public IEnumerable<GearSpecialAbility> GenerateFor(IEnumerable<String> types, String power, Int32 magicalBonus, Int32 quantity)
        {
            if (magicalBonus <= 0)
                return Enumerable.Empty<GearSpecialAbility>();

            var tableName = GetTableName(types, power);
            var abilities = new List<GearSpecialAbility>();
            var bonusSum = magicalBonus;

            while (quantity-- > 0)
            {
                var result = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult(tableName);

                if (bonusSum + result.Amount > 10)
                {
                    quantity++;
                    continue;
                }

                bonusSum += result.Amount;

                var ability = new GearSpecialAbility();
                ability.Name = result.Type;
                abilities.Add(ability);
            }

            return abilities;
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

            throw new ArgumentException("invalid types for gear special abilities");
        }
    }
}