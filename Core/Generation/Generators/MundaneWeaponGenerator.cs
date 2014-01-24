using System;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MundaneWeaponGenerator : IMundaneGearGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAmmunitionGenerator ammunitionGenerator;
        private IMaterialsProvider materialsProvider;
        private IGearTypesProvider gearTypesProvider;

        public MundaneWeaponGenerator(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator,
            IMaterialsProvider materialsProvider, IGearTypesProvider gearTypesProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.ammunitionGenerator = ammunitionGenerator;
            this.materialsProvider = materialsProvider;
            this.gearTypesProvider = gearTypesProvider;
        }

        public Gear Generate()
        {
            var type = percentileResultProvider.GetPercentileResult("MundaneWeapons");
            var tableName = String.Format("{0}Weapons", type);
            var weaponName = percentileResultProvider.GetPercentileResult(tableName);

            if (weaponName == "Ammunition")
                return ammunitionGenerator.Generate();

            var weapon = new Gear();
            weapon.Traits.Add(ItemsConstants.Gear.Traits.Masterwork);
            weapon.Name = weaponName;
            weapon.Types = gearTypesProvider.GetGearTypesFor(weapon.Name);

            if (materialsProvider.HasSpecialMaterial())
            {
                var specialMaterial = materialsProvider.GetSpecialMaterialFor(weapon.Types);
                if (!String.IsNullOrEmpty(specialMaterial))
                    weapon.Traits.Add(specialMaterial);

                if (weapon.Types.Contains(ItemsConstants.Gear.Types.DoubleWeapon) && materialsProvider.HasSpecialMaterial())
                {
                    var secondSpecialMaterial = materialsProvider.GetSpecialMaterialFor(weapon.Types);

                    if (specialMaterial != secondSpecialMaterial && !String.IsNullOrEmpty(secondSpecialMaterial))
                        weapon.Traits.Add(secondSpecialMaterial);
                }
            }

            return weapon;
        }
    }
}