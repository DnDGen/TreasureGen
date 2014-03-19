using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Objects;

namespace EquipmentGen.Core.Generation.Providers
{
    public class SpecialAbilityDataProvider : ISpecialAbilityDataProvider
    {
        private ISpecialAbilityDataXmlParser specialAbilityDataXmlParser;
        private IAttributesProvider attributesProvider;

        private Dictionary<String, SpecialAbilityDataObject> data;

        public SpecialAbilityDataProvider(ISpecialAbilityDataXmlParser specialAbilityDataXmlParser,
            IAttributesProvider attributesProvider)
        {
            this.specialAbilityDataXmlParser = specialAbilityDataXmlParser;
            this.attributesProvider = attributesProvider;
        }

        public SpecialAbility GetDataFor(String specialAbilityName)
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
            ability.AttributeRequirements = attributesProvider.GetAttributesFor(ability.CoreName, "SpecialAbilityAttributes");

            return ability;
        }

        private void CacheTable()
        {
            data = specialAbilityDataXmlParser.Parse("SpecialAbilityData.xml");
        }
    }
}