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
        private ITypesProvider typesProvider;

        private Dictionary<String, SpecialAbilityDataObject> data;

        public SpecialAbilityDataProvider(ISpecialAbilityDataXmlParser specialAbilityDataXmlParser,
            ITypesProvider typesProvider)
        {
            this.specialAbilityDataXmlParser = specialAbilityDataXmlParser;
            this.typesProvider = typesProvider;
        }

        public SpecialAbility GetDataFor(String specialAbilityName)
        {
            if (data == null)
                CacheTable();

            var ability = new SpecialAbility();
            ability.BonusEquivalent = data[specialAbilityName].BonusEquivalent;
            ability.CoreName = data[specialAbilityName].CoreName;
            ability.Name = specialAbilityName;
            ability.Strength = data[specialAbilityName].Strength;
            ability.TypeRequirements = typesProvider.GetTypesFor(ability.CoreName, "SpecialAbilityTypes");

            return ability;
        }

        private void CacheTable()
        {
            data = specialAbilityDataXmlParser.Parse("SpecialAbilityData.xml");
        }
    }
}