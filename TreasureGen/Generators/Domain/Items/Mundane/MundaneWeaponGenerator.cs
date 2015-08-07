using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items.Mundane
{
    public class MundaneWeaponGenerator : IMundaneItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private IAttributesSelector attributesSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public MundaneWeaponGenerator(IPercentileSelector percentileSelector, IAmmunitionGenerator ammunitionGenerator, IAttributesSelector attributesSelector, IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
            this.attributesSelector = attributesSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
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

            var isMasterwork = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork);
            if (isMasterwork)
                weapon.Traits.Add(TraitConstants.Masterwork);

            return weapon;
        }
    }
}