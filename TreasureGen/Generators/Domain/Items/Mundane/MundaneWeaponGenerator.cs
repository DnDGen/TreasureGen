using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Tables.Interfaces;

namespace TreasureGen.Generators.Domain.Items.Mundane
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