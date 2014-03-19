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
        private ISpecialAbilityDataMapper specialAbilityDataXmlParser;
        private IAttributesSelector attributesProvider;

        private Dictionary<String, SpecialAbilityDataObject> data;

        public SpecialAbilityDataSelector(ISpecialAbilityDataMapper specialAbilityDataXmlParser,
            IAttributesSelector attributesProvider)
        {
            this.specialAbilityDataXmlParser = specialAbilityDataXmlParser;
            this.attributesProvider = attributesProvider;
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
            ability.AttributeRequirements = attributesProvider.SelectFrom(ability.CoreName, "SpecialAbilityAttributes");

            return ability;
        }

        private void CacheTable()
        {
            data = specialAbilityDataXmlParser.Map("SpecialAbilityData.xml");
        }
    }
}