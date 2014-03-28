using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Selectors
{
    public class SpecialAbilityDataSelector : ISpecialAbilityDataSelector
    {
        private ISpecialAbilityDataMapper specialAbilityDataMapper;
        private IAttributesSelector attributesSelector;

        public SpecialAbilityDataSelector(ISpecialAbilityDataMapper specialAbilityDataMapper,
            IAttributesSelector attributesSelector)
        {
            this.specialAbilityDataMapper = specialAbilityDataMapper;
            this.attributesSelector = attributesSelector;
        }

        public SpecialAbility SelectFor(String specialAbilityName)
        {
            var table = specialAbilityDataMapper.Map("SpecialAbilityData");

            if (!table.ContainsKey(specialAbilityName))
            {
                var message = String.Format("The ability {0} was not present in the special ability data collection.", specialAbilityName);
                throw new ArgumentException(message);
            }

            var ability = new SpecialAbility();
            ability.BonusEquivalent = table[specialAbilityName].BonusEquivalent;
            ability.CoreName = table[specialAbilityName].CoreName;
            ability.Name = specialAbilityName;
            ability.Strength = table[specialAbilityName].Strength;
            ability.AttributeRequirements = attributesSelector.SelectFrom("SpecialAbilityAttributes", ability.CoreName);

            return ability;
        }
    }
}