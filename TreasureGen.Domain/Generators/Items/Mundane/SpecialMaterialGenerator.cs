using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class SpecialMaterialGenerator : ISpecialMaterialGenerator
    {
        private Dice dice;
        private Dictionary<string, IEnumerable<string>> specialMaterialAttributes;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public SpecialMaterialGenerator(Dice dice, ICollectionsSelector attributesSelector, IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.dice = dice;
            this.booleanPercentileSelector = booleanPercentileSelector;

            specialMaterialAttributes = new Dictionary<string, IEnumerable<string>>();

            var materials = TraitConstants.SpecialMaterials.All();
            foreach (var material in materials)
            {
                var attributeRequirements = attributesSelector.SelectFrom(TableNameConstants.Collections.Set.SpecialMaterials, material);
                specialMaterialAttributes.Add(material, attributeRequirements);
            }
        }

        public bool CanHaveSpecialMaterial(string itemType, IEnumerable<string> attributes, IEnumerable<string> traits)
        {
            if (itemType != ItemTypeConstants.Weapon && itemType != ItemTypeConstants.Armor)
                return false;

            var attributesWithType = attributes.Union(new[] { itemType });
            return booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.HasSpecialMaterial)
                   && AttributesAllowForSpecialMaterials(attributesWithType)
                   && TraitsAllowForSpecialMaterials(attributesWithType, traits);
        }

        private bool AttributesAllowForSpecialMaterials(IEnumerable<string> attributes)
        {
            var allowedMaterials = GetAllowedMaterials(attributes);
            return allowedMaterials.Any();
        }

        private bool TraitsAllowForSpecialMaterials(IEnumerable<string> attributes, IEnumerable<string> traits)
        {
            var numberOfMaterialsAlreadyHad = specialMaterialAttributes.Keys.Intersect(traits).Count();
            if (numberOfMaterialsAlreadyHad > 1)
                return false;

            var numberOfAllowedMaterials = GetAllowedMaterials(attributes).Count();
            if (numberOfAllowedMaterials <= numberOfMaterialsAlreadyHad)
                return false;

            if (numberOfMaterialsAlreadyHad > 0)
                return attributes.Contains(AttributeConstants.DoubleWeapon);

            return true;
        }

        private IEnumerable<string> GetAllowedMaterials(IEnumerable<string> attributes)
        {
            var allowedMaterialEntries = specialMaterialAttributes.Where(kvp => kvp.Value.Intersect(attributes).Count() == kvp.Value.Count());
            return allowedMaterialEntries.Select(kvp => kvp.Key);
        }

        public string GenerateFor(string itemType, IEnumerable<string> attributes, IEnumerable<string> traits)
        {
            if (itemType != ItemTypeConstants.Weapon && itemType != ItemTypeConstants.Armor)
                throw new ArgumentException(itemType);

            var attributesWithType = attributes.Union(new[] { itemType });
            if (!AttributesAllowForSpecialMaterials(attributesWithType))
                throw new ArgumentException(string.Join(",", attributesWithType));

            if (!TraitsAllowForSpecialMaterials(attributesWithType, traits))
                throw new ArgumentException(string.Join(",", traits));

            var filteredSpecialMaterials = GetAllowedMaterials(attributesWithType);
            var allowedSpecialMaterials = filteredSpecialMaterials.Except(traits);

            if (allowedSpecialMaterials.Count() == 1)
                return allowedSpecialMaterials.First();

            var index = dice.Roll().d(allowedSpecialMaterials.Count()).AsSum() - 1;
            return allowedSpecialMaterials.ElementAt(index);
        }
    }
}