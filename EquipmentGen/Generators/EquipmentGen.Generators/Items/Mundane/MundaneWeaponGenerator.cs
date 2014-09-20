using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

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
            var type = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeapons);
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, type);
            var weaponName = percentileSelector.SelectFrom(tableName);

            var weapon = new Item();

            if (weaponName == AttributeConstants.Ammunition)
            {
                weapon = ammunitionGenerator.Generate();
            }
            else
            {
                weapon.Name = weaponName;
                weapon.ItemType = ItemTypeConstants.Weapon;
                tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, weapon.ItemType);
                weapon.Attributes = attributesSelector.SelectFrom(tableName, weapon.Name);
            }

            weapon.Traits.Add(TraitConstants.Masterwork);

            return weapon;
        }
    }
}