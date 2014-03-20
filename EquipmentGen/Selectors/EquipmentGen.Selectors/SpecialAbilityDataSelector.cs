using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Selectors
{
    public class SpecialAbilityDataSelector : ISpecialAbilityDataSelector
    {
        private ISpecialAbilityDataMapper specialAbilityDataMapper;
        private IAttributesSelector attributesSelector;

        private Dictionary<String, SpecialAbilityDataObject> data;

        public SpecialAbilityDataSelector(ISpecialAbilityDataMapper specialAbilityDataMapper,
            IAttributesSelector attributesSelector)
        {
            this.specialAbilityDataMapper = specialAbilityDataMapper;
            this.attributesSelector = attributesSelector;
        }

        public SpecialAbility SelectFor(String specialAbilityName)
        {
            if (data == null)
                CacheTable();

            if (!data.ContainsKey(specialAbilityName))
            {
                var message = String.Format("The ability {0} was not present in the special ability data collection.", specialAbilityName);
                throw new ArgumentException(message);
            }

            var ability = new SpecialAbility();
            ability.BonusEquivalent = data[specialAbilityName].BonusEquivalent;
            ability.CoreName = data[specialAbilityName].CoreName;
            ability.Name = specialAbilityName;
            ability.Strength = data[specialAbilityName].Strength;
            ability.AttributeRequirements = attributesSelector.SelectFrom(ability.CoreName, "SpecialAbilityAttributes");

            return ability;
        }

        private void CacheTable()
        {
            data = specialAbilityDataMapper.Map("SpecialAbilityData.xml");
        }
    }
}