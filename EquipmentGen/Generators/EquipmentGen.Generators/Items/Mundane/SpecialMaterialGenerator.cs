using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
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

            var materials = TraitConstants.GetSpecialMaterials();

            foreach (var material in materials)
            {
                var attributeRequirements = attributesSelector.SelectFrom("SpecialMaterials", material);
                specialMaterialAttributes.Add(material, attributeRequirements);
            }
        }

        public Boolean HasSpecialMaterial(String itemType, IEnumerable<String> attributes, IEnumerable<String> traits)
        {
            if (itemType != ItemTypeConstants.Weapon && itemType != ItemTypeConstants.Armor)
                return false;

            var attributesWithType = attributes.Union(new[] { itemType });
            return booleanPercentileSelector.SelectFrom("HasSpecialMaterial")
                   && AttributesAllowForSpecialMaterials(attributesWithType)
                   && TraitsAllowForSpecialMaterials(attributesWithType, traits);
        }

        private Boolean AttributesAllowForSpecialMaterials(IEnumerable<String> attributes)
        {
            var allowedMaterials = GetAllowedMaterials(attributes);
            return allowedMaterials.Any();
        }

        private Boolean TraitsAllowForSpecialMaterials(IEnumerable<String> attributes, IEnumerable<String> traits)
        {
            var numberOfMaterialsAlreadyHad = specialMaterialAttributes.Keys.Intersect(traits).Count();
            var numberOfAllowedMaterials = GetAllowedMaterials(attributes).Count();

            if (numberOfAllowedMaterials <= numberOfMaterialsAlreadyHad)
                return false;

            if (numberOfMaterialsAlreadyHad > 1)
                return false;

            if (numberOfMaterialsAlreadyHad > 0)
                return attributes.Contains(AttributeConstants.DoubleWeapon);

            return true;
        }

        private IEnumerable<String> GetAllowedMaterials(IEnumerable<String> attributes)
        {
            var allowedMaterialEntries = specialMaterialAttributes.Where(kvp => kvp.Value.Intersect(attributes).Count() == kvp.Value.Count());
            return allowedMaterialEntries.Select(kvp => kvp.Key);
        }

        public String GenerateFor(String itemType, IEnumerable<String> attributes, IEnumerable<String> traits)
        {
            if (itemType != ItemTypeConstants.Weapon && itemType != ItemTypeConstants.Armor)
                throw new ArgumentException(itemType);

            var attributesWithType = attributes.Union(new[] { itemType });
            if (!AttributesAllowForSpecialMaterials(attributesWithType))
                throw new ArgumentException(String.Join(",", attributesWithType));

            if (!TraitsAllowForSpecialMaterials(attributesWithType, traits))
                throw new ArgumentException(String.Join(",", traits));

            var filteredSpecialMaterials = GetAllowedMaterials(attributesWithType);
            var allowedSpecialMaterials = filteredSpecialMaterials.Except(traits);

            if (!allowedSpecialMaterials.Any())
                throw new ArgumentException(String.Join(",", attributesWithType.Union(traits)));

            if (allowedSpecialMaterials.Count() == 1)
                return allowedSpecialMaterials.First();

            var rollString = String.Format("1d{0}-1", allowedSpecialMaterials.Count());
            var roll = dice.Roll(rollString);

            return allowedSpecialMaterials.ElementAt(roll);
        }
    }
}