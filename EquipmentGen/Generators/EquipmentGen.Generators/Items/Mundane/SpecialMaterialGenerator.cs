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
        private IAttributesSelector attributesSelector;
        private Dictionary<String, IEnumerable<String>> specialMaterialAttributes;

        public SpecialMaterialGenerator(IDice dice, IAttributesSelector attributesSelector)
        {
            this.dice = dice;
            this.attributesSelector = attributesSelector;

            specialMaterialAttributes = new Dictionary<String, IEnumerable<String>>();

            CacheSpecialMaterialTypes();
        }

        private void CacheSpecialMaterialTypes()
        {
            var materials = attributesSelector.SelectFrom("SpecialMaterials", "SpecialMaterials");

            foreach (var material in materials)
                AddTypes(material);
        }

        private void AddTypes(String specialMaterial)
        {
            var attributeRequirements = attributesSelector.SelectFrom("SpecialMaterials", specialMaterial);
            specialMaterialAttributes.Add(specialMaterial, attributeRequirements);
        }

        public Boolean HasSpecialMaterial(IEnumerable<String> attributes)
        {
            return dice.Percentile() > 95 && AttributesAllowForSpecialMaterials(attributes);
        }

        private Boolean AttributesAllowForSpecialMaterials(IEnumerable<String> attributes)
        {
            return specialMaterialAttributes.Any(kvp => kvp.Value.All(v => attributes.Contains(v)));
        }

        public String GenerateFor(IEnumerable<String> attributes)
        {
            if (!AttributesAllowForSpecialMaterials(attributes))
                throw new ArgumentException(String.Join(",", attributes));

            var filteredSpecialMaterials = specialMaterialAttributes.Where(kvp => kvp.Value.All(v => attributes.Contains(v)));
            var allowedSpecialMaterials = filteredSpecialMaterials.Select<KeyValuePair<String, IEnumerable<String>>, String>(kvp => kvp.Key);

            if (allowedSpecialMaterials.Count() == 1)
                return allowedSpecialMaterials.First();

            var rollString = String.Format("1d{0}-1", allowedSpecialMaterials.Count());
            var roll = dice.Roll(rollString);

            return allowedSpecialMaterials.ElementAt(roll);
        }
    }
}