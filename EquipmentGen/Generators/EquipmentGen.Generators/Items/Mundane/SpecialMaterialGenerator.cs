using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class SpecialMaterialGenerator : ISpecialMaterialGenerator
    {
        private IDice dice;
        private Dictionary<String, IEnumerable<String>> specialMaterialAttributes;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public SpecialMaterialGenerator(IDice dice, IAttributesSelector attributesSelector, IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.dice = dice;
            this.booleanPercentileSelector = booleanPercentileSelector;

            specialMaterialAttributes = new Dictionary<String, IEnumerable<String>>();

            var materials = attributesSelector.SelectFrom("SpecialMaterials", "SpecialMaterials");

            foreach (var material in materials)
            {
                var attributeRequirements = attributesSelector.SelectFrom("SpecialMaterials", material);
                specialMaterialAttributes.Add(material, attributeRequirements);
            }
        }

        public Boolean HasSpecialMaterial(String itemType, IEnumerable<String> attributes)
        {
            var attributesWithType = attributes.Union(new[] { itemType });
            return booleanPercentileSelector.SelectFrom("HasSpecialMaterial") && AttributesAllowForSpecialMaterials(attributesWithType);
        }

        private Boolean AttributesAllowForSpecialMaterials(IEnumerable<String> attributes)
        {
            return specialMaterialAttributes.Any(kvp => kvp.Value.All(v => attributes.Contains(v)));
        }

        public String GenerateFor(String itemType, IEnumerable<String> attributes)
        {
            var attributesWithType = attributes.Union(new[] { itemType });
            if (!AttributesAllowForSpecialMaterials(attributesWithType))
                throw new ArgumentException(String.Join(",", attributesWithType));

            var filteredSpecialMaterials = specialMaterialAttributes.Where(kvp => kvp.Value.All(v => attributesWithType.Contains(v)));
            var allowedSpecialMaterials = filteredSpecialMaterials.Select<KeyValuePair<String, IEnumerable<String>>, String>(kvp => kvp.Key);

            if (allowedSpecialMaterials.Count() == 1)
                return allowedSpecialMaterials.First();

            var rollString = String.Format("1d{0}-1", allowedSpecialMaterials.Count());
            var roll = dice.Roll(rollString);

            return allowedSpecialMaterials.ElementAt(roll);
        }
    }
}