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
        private IAttributesProvider typesProvider;

        public MundaneWeaponGenerator(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator,
            ISpecialMaterialGenerator materialsProvider, IAttributesProvider typesProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.ammunitionGenerator = ammunitionGenerator;
            this.materialsProvider = materialsProvider;
            this.typesProvider = typesProvider;
        }

        public Item Generate()
        {
            var type = percentileResultProvider.GetResultFrom("MundaneWeapons");
            var tableName = String.Format("{0}Weapons", type);
            var weaponName = percentileResultProvider.GetResultFrom(tableName);
            var weapon = new Item();

            if (weaponName == "Ammunition")
            {
                weapon = ammunitionGenerator.Generate();
            }
            else
            {
                weapon.Name = weaponName;
                weapon.Attributes = typesProvider.GetAttributesFor(weapon.Name, "WeaponAttributes");
            }

            weapon.Traits.Add(TraitConstants.Masterwork);

            if (materialsProvider.HasSpecialMaterial(weapon.Attributes))
            {
                var specialMaterial = materialsProvider.GenerateFor(weapon.Attributes);
                if (!String.IsNullOrEmpty(specialMaterial))
                    weapon.Traits.Add(specialMaterial);

                if (weapon.Attributes.Contains(AttributeConstants.DoubleWeapon) && materialsProvider.HasSpecialMaterial(weapon.Attributes))
                {
                    var secondSpecialMaterial = materialsProvider.GenerateFor(weapon.Attributes);

                    if (specialMaterial != secondSpecialMaterial)
                        weapon.Traits.Add(secondSpecialMaterial);
                }
            }

            return weapon;
        }
    }
}