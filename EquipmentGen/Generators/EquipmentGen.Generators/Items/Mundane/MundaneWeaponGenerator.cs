using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class MundaneWeaponGenerator : IMundaneItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private IAttributesSelector attributesSelector;

        public MundaneWeaponGenerator(IPercentileSelector percentileSelector, IAmmunitionGenerator ammunitionGenerator, IAttributesSelector attributesSelector)
        {
            this.percentileSelector = percentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
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

            return weapon;
        }
    }
}