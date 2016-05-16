using RollGen;
using System;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class AmmunitionGenerator : IAmmunitionGenerator
    {
        private IPercentileSelector percentileSelector;
        private Dice dice;
        private IAttributesSelector attributesSelector;

        public AmmunitionGenerator(IPercentileSelector percentileSelector, Dice dice, IAttributesSelector attributesSelector)
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