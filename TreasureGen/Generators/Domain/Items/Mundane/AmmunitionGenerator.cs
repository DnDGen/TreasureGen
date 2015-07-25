using RollGen;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Tables.Interfaces;

namespace TreasureGen.Generators.Domain.Items.Mundane
{
    public class AmmunitionGenerator : IAmmunitionGenerator
    {
        private IPercentileSelector percentileSelector;
        private IDice dice;
        private IAttributesSelector attributesSelector;

        public AmmunitionGenerator(IPercentileSelector percentileSelector, IDice dice,
            IAttributesSelector attributesSelector)
        {
            this.percentileSelector = percentileSelector;
            this.dice = dice;
            this.attributesSelector = attributesSelector;
        }

        public Item Generate()
        {
            var roll = dice.Roll().Percentile();

            var ammunition = new Item();
            ammunition.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Ammunitions);
            ammunition.Quantity = Math.Max(1, roll / 2);
            ammunition.Attributes = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.AmmunitionAttributes, ammunition.Name);
            ammunition.ItemType = ItemTypeConstants.Weapon;

            return ammunition;
        }
    }
}