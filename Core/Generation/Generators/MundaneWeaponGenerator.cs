using System;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MundaneWeaponGenerator : IMundaneGearGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAmmunitionGenerator ammunitionGenerator;
        private ISpecialMaterialGenerator materialsProvider;
        private ITypesProvider typesProvider;

        public MundaneWeaponGenerator(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator,
            ISpecialMaterialGenerator materialsProvider, ITypesProvider typesProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.ammunitionGenerator = ammunitionGenerator;
            this.materialsProvider = materialsProvider;
            this.typesProvider = typesProvider;
        }

        public Gear Generate()
        {
            var type = percentileResultProvider.GetResultFrom("MundaneWeapons");
            var tableName = String.Format("{0}Weapons", type);
            var weaponName = percentileResultProvider.GetResultFrom(tableName);
            var weapon = new Gear();

            if (weaponName == "Ammunition")
            {
                weapon = ammunitionGenerator.Generate();
            }
            else
            {
                weapon.Name = weaponName;
                weapon.Types = typesProvider.GetTypesFor(weapon.Name, "WeaponTypes");
            }

            weapon.Traits.Add(TraitConstants.Masterwork);

            if (materialsProvider.HasSpecialMaterial(weapon.Types))
            {
                var specialMaterial = materialsProvider.GenerateFor(weapon.Types);
                if (!String.IsNullOrEmpty(specialMaterial))
                    weapon.Traits.Add(specialMaterial);

                if (weapon.Types.Contains(TypeConstants.DoubleWeapon) && materialsProvider.HasSpecialMaterial(weapon.Types))
                {
                    var secondSpecialMaterial = materialsProvider.GenerateFor(weapon.Types);

                    if (specialMaterial != secondSpecialMaterial)
                        weapon.Traits.Add(secondSpecialMaterial);
                }
            }

            return weapon;
        }
    }
}