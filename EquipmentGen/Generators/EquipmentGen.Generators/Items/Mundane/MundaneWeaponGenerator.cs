using System;
using System.Linq;
using D20Dice;
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
        private IAttributesProvider attributesProvider;
        private IDice dice;

        public MundaneWeaponGenerator(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator,
            ISpecialMaterialGenerator materialsProvider, IAttributesProvider attributesProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.ammunitionGenerator = ammunitionGenerator;
            this.materialsProvider = materialsProvider;
            this.attributesProvider = attributesProvider;
            this.dice = dice;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var type = percentileResultProvider.GetResultFrom("MundaneWeapons", roll);
            var tableName = String.Format("{0}Weapons", type);

            roll = dice.Percentile();
            var weaponName = percentileResultProvider.GetResultFrom(tableName, roll);
            var weapon = new Item();

            if (weaponName == "Ammunition")
            {
                weapon = ammunitionGenerator.Generate();
            }
            else
            {
                weapon.Name = weaponName;
                weapon.Attributes = attributesProvider.GetAttributesFor(weapon.Name, "WeaponAttributes");
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