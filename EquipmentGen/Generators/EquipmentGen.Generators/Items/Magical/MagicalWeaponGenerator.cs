using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalWeaponGenerator : IMagicalItemGenerator
    {
        private IAttributesSelector attributesSelector;
        private IPercentileSelector percentileSelector;

        public MagicalWeaponGenerator(IAttributesSelector attributesSelector, IPercentileSelector percentileSelector)
        {
            this.attributesSelector = attributesSelector;
            this.percentileSelector = percentileSelector;
        }

        public Item GenerateAtPower(String power)
        {
            var tablename = String.Format("{0}Weapons", power);
            var bonus = percentileSelector.SelectFrom(tablename);

            var type = percentileSelector.SelectFrom("WeaponTypes");
            tablename = String.Format("{0}Weapons", type);

            var weapon = new Item();
            weapon.ItemType = ItemTypeConstants.Weapon;
            weapon.Name = percentileSelector.SelectFrom(tablename);
            weapon.Attributes = attributesSelector.SelectFrom("WeaponAttributes", weapon.Name);
            weapon.Magic.Bonus = Convert.ToInt32(bonus);

            return weapon;
        }
    }
}