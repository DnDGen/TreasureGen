using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class MundaneWeaponGenerator : IMundaneItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IMundaneItemGenerator ammunitionGenerator;
        private ISpecialMaterialGenerator materialsSelector;
        private IAttributesSelector attributesSelector;

        public MundaneWeaponGenerator(IPercentileSelector percentileSelector, IMundaneItemGenerator ammunitionGenerator, ISpecialMaterialGenerator materialsSelector, IAttributesSelector attributesSelector)
        {
            this.percentileSelector = percentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
            this.materialsSelector = materialsSelector;
            this.attributesSelector = attributesSelector;
        }

        public Item Generate()
        {
            var type = percentileSelector.SelectFrom("MundaneWeapons");
            var tableName = String.Format("{0}Weapons", type);

            var weaponName = percentileSelector.SelectFrom(tableName);
            var weapon = new Item();

            if (weaponName == "Ammunition")
            {
                weapon = ammunitionGenerator.Generate();
            }
            else
            {
                weapon.Name = weaponName;
                weapon.ItemType = ItemTypeConstants.Weapon;
                weapon.Attributes = attributesSelector.SelectFrom("WeaponAttributes", weapon.Name);
            }

            weapon.Traits.Add(TraitConstants.Masterwork);

            if (materialsSelector.HasSpecialMaterial(weapon.ItemType, weapon.Attributes))
            {
                var specialMaterial = materialsSelector.GenerateFor(weapon.ItemType, weapon.Attributes);
                if (!String.IsNullOrEmpty(specialMaterial))
                    weapon.Traits.Add(specialMaterial);

                if (weapon.Attributes.Contains(AttributeConstants.DoubleWeapon) && materialsSelector.HasSpecialMaterial(weapon.ItemType, weapon.Attributes))
                {
                    var secondSpecialMaterial = materialsSelector.GenerateFor(weapon.ItemType, weapon.Attributes);

                    if (specialMaterial != secondSpecialMaterial)
                        weapon.Traits.Add(secondSpecialMaterial);
                }
            }

            return weapon;
        }
    }
}