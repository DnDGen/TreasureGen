using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items.Mundane
{
    internal class AlchemicalItemGenerator : MundaneItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public AlchemicalItemGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Item Generate()
        {
            var result = typeAndAmountPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems);

            return Generate(result.Type);
        }

        public Item Generate(string itemName, params string[] traits)
        {
            var selections = typeAndAmountPercentileSelector.SelectAllFrom(TableNameConstants.Percentiles.Set.AlchemicalItems);
            var selection = selections.FirstOrDefault(s => s.Type == itemName);

            if (selection == null)
            {
                selection = new TypeAndAmountSelection();
                selection.Type = itemName;
                selection.Amount = 1;
            }

            var item = new Item();
            item.Name = itemName;
            item.Quantity = selection.Amount;
            item.ItemType = ItemTypeConstants.AlchemicalItem;
            item.BaseNames = new[] { itemName };
            item.Traits = new HashSet<string>(traits);

            return item;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var item = template.MundaneClone();
            item.ItemType = ItemTypeConstants.AlchemicalItem;
            item.BaseNames = new[] { item.Name };
            item.Attributes = Enumerable.Empty<string>();

            return item;
        }
    }
}