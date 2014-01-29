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
        private ISpecialMaterialGenerator materialsProvider;
        private IGearTypesProvider gearTypesProvider;

        public MundaneWeaponGenerator(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator,
            ISpecialMaterialGenerator materialsProvider, IGearTypesProvider gearTypesProvider)
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
            var weapon = new Gear();

            if (weaponName == "Ammunition")
            {
                weapon = ammunitionGenerator.Generate();
            }
            else
            {
                weapon.Name = weaponName;
                weapon.Types = gearTypesProvider.GetGearTypesFor(weapon.Name);
            }

            weapon.Traits.Add(ItemsConstants.Gear.Traits.Masterwork);

            if (materialsProvider.HasSpecialMaterial())
            {
                var specialMaterial = materialsProvider.GenerateSpecialMaterialFor(weapon.Types);
                if (!String.IsNullOrEmpty(specialMaterial))
                    weapon.Traits.Add(specialMaterial);

                if (weapon.Types.Contains(ItemsConstants.Gear.Types.DoubleWeapon) && materialsProvider.HasSpecialMaterial())
                {
                    var secondSpecialMaterial = materialsProvider.GenerateSpecialMaterialFor(weapon.Types);

                    if (specialMaterial != secondSpecialMaterial && !String.IsNullOrEmpty(secondSpecialMaterial))
                        weapon.Traits.Add(secondSpecialMaterial);
                }
            }

            return weapon;
        }
    }
}