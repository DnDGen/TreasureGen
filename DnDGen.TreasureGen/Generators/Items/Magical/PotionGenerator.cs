using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class PotionGenerator : MagicalItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionSelector collectionSelector;

        public PotionGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICollectionSelector collectionSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionSelector = collectionSelector;
        }

        public Item GenerateFrom(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            return GeneratePotion(result.Type, result.Amount);
        }

        private Item GeneratePotion(string itemName, int bonus)
        {
            var potion = new Item();

            potion.Name = itemName;
            potion.BaseNames = new[] { itemName };
            potion.ItemType = ItemTypeConstants.Potion;
            potion.Magic.Bonus = bonus;
            potion.IsMagical = true;
            potion.Attributes = new[] { AttributeConstants.OneTimeUse };

            return potion;
        }

        public Item GenerateFrom(string power, string itemName)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tableName);
            var matches = results.Where(r => r.Type == itemName);

            if (!matches.Any())
            {
                throw new ArgumentException($"{itemName} is not a valid {power} Potion");
            }

            var result = collectionSelector.SelectRandomFrom(matches);

            return GeneratePotion(itemName, result.Amount);
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
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