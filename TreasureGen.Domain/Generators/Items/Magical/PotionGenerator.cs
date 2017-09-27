using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class PotionGenerator : MagicalItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly Generator generator;

        public PotionGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICollectionSelector collectionsSelector, Generator generator)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.generator = generator;
        }

        public Item GenerateFrom(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var potion = new Item();

            potion.Name = result.Type;
            potion.BaseNames = new[] { result.Type };
            potion.ItemType = ItemTypeConstants.Potion;
            potion.Magic.Bonus = result.Amount;
            potion.IsMagical = true;
            potion.Attributes = new[] { AttributeConstants.OneTimeUse };

            return potion;
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

        public Item GenerateFrom(string power, IEnumerable<string> subset)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tableName);

            if (!results.Any(r => subset.Any(n => r.Type == n)))
            {
                return CreateDefaultPotion(power, subset);
            }

            var potion = generator.Generate(
                () => GenerateFrom(power),
                p => subset.Any(n => p.NameMatches(n)),
                () => CreateDefaultPotion(power, subset),
                p => $"{p.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Potion from [{string.Join(", ", subset)}]");

            return potion;
        }

        private Item CreateDefaultPotion(string power, IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);

            var result = GetResult(power, template.Name);
            template.Magic.Bonus = result.Amount;

            var defaultPotion = GenerateFrom(template);
            return defaultPotion;
        }

        private TypeAndAmountSelection GetResult(string power, string name)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tableName);
            var result = results.FirstOrDefault(r => r.Type == name);

            if (result != null)
                return result;

            if (power != PowerConstants.Minor)
            {
                tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.Potion);
                var minorResults = typeAndAmountPercentileSelector.SelectAllFrom(tableName);

                result = minorResults.FirstOrDefault(r => r.Type == name);

                if (result != null)
                    return result;
            }

            if (power != PowerConstants.Medium)
            {
                tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Potion);
                var mediumResults = typeAndAmountPercentileSelector.SelectAllFrom(tableName);

                result = mediumResults.FirstOrDefault(r => r.Type == name);

                if (result != null)
                    return result;
            }

            if (power != PowerConstants.Major)
            {
                tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Potion);
                var majorResults = typeAndAmountPercentileSelector.SelectAllFrom(tableName);

                result = majorResults.FirstOrDefault(r => r.Type == name);

                if (result != null)
                    return result;
            }

            //INFO: This means the potion name replaces some fillable field such as ALIGNMENT, so we will assume a bonus of 0
            if (result == null)
                return new TypeAndAmountSelection();

            return result;
        }
    }
}