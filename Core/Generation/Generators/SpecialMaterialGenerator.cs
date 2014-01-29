using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class SpecialMaterialGenerator : ISpecialMaterialGenerator
    {
        private IDice dice;
        private ITypesXmlParser typesXmlParser;

        public SpecialMaterialGenerator(IDice dice, ITypesXmlParser typesXmlParser)
        {
            this.dice = dice;
            this.typesXmlParser = typesXmlParser;
        }

        public Boolean HasSpecialMaterial()
        {
            return dice.Percentile() > 95;
        }

        public String GenerateSpecialMaterialFor(IEnumerable<String> types)
        {
            var specialMaterials = typesXmlParser.Parse("SpecialMaterials.xml");
            var filteredSpecialMaterials = specialMaterials.Where(kvp => kvp.Value.All(v => types.Contains(v)));
            var allowedMaterials = filteredSpecialMaterials.Select<KeyValuePair<String, IEnumerable<String>>, String>(kvp => kvp.Key);

            if (!allowedMaterials.Any())
                return String.Empty;

            var rollString = String.Format("1d{0}-1", allowedMaterials.Count());
            var roll = dice.Roll(rollString);
            return allowedMaterials.ElementAt(roll);
        }
    }
}