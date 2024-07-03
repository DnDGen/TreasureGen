using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class PotionGenerator : MagicalItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionSelector collectionSelector;
        private readonly IReplacementSelector replacementSelector;

        public PotionGenerator(
            ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ICollectionSelector collectionSelector,
            IReplacementSelector replacementSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionSelector = collectionSelector;
            this.replacementSelector = replacementSelector;
        }

        public Item GenerateRandom(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            return GeneratePotion(result.Type, result.Amount);
        }

        private Item GeneratePotion(string itemName, int bonus, params string[] traits)
        {
            var potion = new Item();

            potion.Name = itemName;
            potion.BaseNames = new[] { itemName };
            potion.ItemType = ItemTypeConstants.Potion;
            potion.Magic.Bonus = bonus;
            potion.IsMagical = true;
            potion.Attributes = new[] { AttributeConstants.OneTimeUse };
            potion.Traits = new HashSet<string>(traits);

            return potion;
        }

        public Item Generate(string power, string itemName, params string[] traits)
        {
            var possiblePowers = collectionSelector.SelectFrom(Config.Name, TableNameConstants.Collections.Set.PowerGroups, itemName);
            var adjustedPower = PowerHelper.AdjustPower(power, possiblePowers);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, adjustedPower, ItemTypeConstants.Potion);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tableName);
            var matches = results.Where(r => NameMatches(r.Type, itemName));
            var result = collectionSelector.SelectRandomFrom(matches);

            return GeneratePotion(result.Type, result.Amount, traits);
        }

        private bool NameMatches(string source, string target)
        {
            var sourceReplacements = replacementSelector.SelectAll(source);
            var targetReplacements = replacementSelector.SelectAll(target);

            return source == target
                || sourceReplacements.Any(s => s == target)
                || targetReplacements.Any(t => t == source);
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var potion = template.Clone();
            potion.BaseNames = new[] { potion.Name };
            potion.ItemType = ItemTypeConstants.Potion;
            potion.Attributes = new[] { AttributeConstants.OneTimeUse };
            potion.IsMagical = true;
            potion.Quantity = 1;

            return potion.SmartClone();
        }
    }
}