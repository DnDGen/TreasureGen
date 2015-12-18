using RollGen;
using System;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items.Mundane
{
    public class MundaneWeaponGenerator : MundaneItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private IAttributesSelector attributesSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private Dice dice;

        public MundaneWeaponGenerator(IPercentileSelector percentileSelector, IAmmunitionGenerator ammunitionGenerator, IAttributesSelector attributesSelector, IBooleanPercentileSelector booleanPercentileSelector, Dice dice)
        {
            this.percentileSelector = percentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
            this.attributesSelector = attributesSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.dice = dice;
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

            var thrownWeapons = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.AmmunitionAttributes, AttributeConstants.Thrown);
            if (thrownWeapons.Contains(weapon.Name))
                weapon.Quantity = dice.Roll().d20();

            var size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
            weapon.Traits.Add(size);

            return weapon;
        }
    }
}