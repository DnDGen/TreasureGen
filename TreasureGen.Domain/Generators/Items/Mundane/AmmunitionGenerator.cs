using RollGen;
using System;
using System.Linq;
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
        private ICollectionsSelector attributesSelector;

        public AmmunitionGenerator(IPercentileSelector percentileSelector, Dice dice, ICollectionsSelector attributesSelector)
        {
            this.percentileSelector = percentileSelector;
            this.dice = dice;
            this.attributesSelector = attributesSelector;
        }

        public Item Generate()
        {
            var roll = dice.Roll().Percentile().AsSum();

            var ammunition = new Item();
            ammunition.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Ammunitions);
            ammunition.BaseNames = new[] { ammunition.Name };
            ammunition.Quantity = Math.Max(1, roll / 2);
            ammunition.Attributes = attributesSelector.SelectFrom(TableNameConstants.Collections.Set.AmmunitionAttributes, ammunition.Name);
            ammunition.ItemType = ItemTypeConstants.Weapon;

            return ammunition;
        }

        public bool TemplateIsAmmunition(Item template)
        {
            var allAmmunitions = percentileSelector.SelectAllFrom(TableNameConstants.Percentiles.Set.Ammunitions);
            return allAmmunitions.Contains(template.Name);
        }

        public Item GenerateFrom(Item template)
        {
            var ammunition = template.SmartClone();
            ammunition.BaseNames = new[] { ammunition.Name };
            ammunition.ItemType = ItemTypeConstants.Weapon;
            ammunition.Attributes = attributesSelector.SelectFrom(TableNameConstants.Collections.Set.AmmunitionAttributes, ammunition.Name);

            //INFO: This second clone takes into account the attributes now on the ammunition.
            return ammunition.SmartClone();
        }
    }
}