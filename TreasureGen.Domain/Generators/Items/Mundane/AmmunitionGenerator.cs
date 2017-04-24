using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class AmmunitionGenerator : IAmmunitionGenerator
    {
        private readonly IPercentileSelector percentileSelector;
        private readonly Dice dice;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly Generator generator;

        public AmmunitionGenerator(IPercentileSelector percentileSelector, Dice dice, ICollectionsSelector collectionsSelector, Generator generator)
        {
            this.percentileSelector = percentileSelector;
            this.dice = dice;
            this.collectionsSelector = collectionsSelector;
            this.generator = generator;
        }

        public Item Generate()
        {
            var roll = dice.Roll().Percentile().AsSum();

            var ammunition = new Item();
            ammunition.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Ammunitions);
            ammunition.BaseNames = new[] { ammunition.Name };
            ammunition.Quantity = Math.Max(1, roll / 2);
            ammunition.Attributes = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.AmmunitionAttributes, ammunition.Name);
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
            var ammunition = template.Clone();
            ammunition.BaseNames = new[] { ammunition.Name };
            ammunition.ItemType = ItemTypeConstants.Weapon;
            ammunition.Attributes = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.AmmunitionAttributes, ammunition.Name);

            //INFO: This second clone takes into account the attributes now on the ammunition.
            return ammunition.SmartClone();
        }

        public Item GenerateFrom(IEnumerable<string> subset)
        {
            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            var ammunition = generator.Generate(
                Generate,
                a => subset.Any(n => a.NameMatches(n)),
                () => CreateDefaultAmmunition(subset),
                $"Ammunition from [{string.Join(", ", subset)}]");

            return ammunition;
        }

        private Item CreateDefaultAmmunition(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);

            var roll = dice.Roll().Percentile().AsSum();
            template.Quantity = Math.Max(1, roll / 2);

            var ammunition = GenerateFrom(template);
            return ammunition;
        }
    }
}