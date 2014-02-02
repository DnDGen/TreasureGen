using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class SpecialMaterialGenerator : ISpecialMaterialGenerator
    {
        private IDice dice;
        private ITypesProvider typesProvider;
        private Dictionary<String, IEnumerable<String>> specialMaterialTypes;

        public SpecialMaterialGenerator(IDice dice, ITypesProvider typesProvider)
        {
            this.dice = dice;
            this.typesProvider = typesProvider;

            specialMaterialTypes = new Dictionary<String, IEnumerable<String>>();

            CacheSpecialMaterialTypes();
        }

        private void CacheSpecialMaterialTypes()
        {
            var materials = typesProvider.GetTypesFor("SpecialMaterials", "SpecialMaterials");
            foreach (var material in materials)
            {
                var materialTypeRequirements = typesProvider.GetTypesFor(material, "SpecialMaterials");
                specialMaterialTypes.Add(material, materialTypeRequirements);
            }
        }

        private void AddTypes(String specialMaterial)
        {
            var types = typesProvider.GetTypesFor(specialMaterial, "SpecialMaterials");
            specialMaterialTypes.Add(specialMaterial, types);
        }

        public Boolean HasSpecialMaterial(IEnumerable<String> types)
        {
            return dice.Percentile() > 95 && ItemTypesAllowForSpecialMaterials(types);
        }

        private Boolean ItemTypesAllowForSpecialMaterials(IEnumerable<String> types)
        {
            return specialMaterialTypes.Any(kvp => kvp.Value.All(v => types.Contains(v)));
        }

        public String GenerateFor(IEnumerable<String> types)
        {
            if (!ItemTypesAllowForSpecialMaterials(types))
                throw new ArgumentException();

            var filteredSpecialMaterials = specialMaterialTypes.Where(kvp => kvp.Value.All(v => types.Contains(v)));
            var allowedSpecialMaterials = filteredSpecialMaterials.Select<KeyValuePair<String, IEnumerable<String>>, String>(kvp => kvp.Key);

            if (allowedSpecialMaterials.Count() == 1)
                return allowedSpecialMaterials.First();

            var rollString = String.Format("1d{0}-1", allowedSpecialMaterials.Count());
            var roll = dice.Roll(rollString);

            return allowedSpecialMaterials.ElementAt(roll);
        }
    }
}