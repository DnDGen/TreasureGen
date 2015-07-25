using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Tables.Interfaces;

namespace TreasureGen.Generators.Domain.Items.Mundane
{
    public class AlchemicalItemGenerator : IMundaneItemGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public AlchemicalItemGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Item Generate()
        {
            var result = typeAndAmountPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems);

            var item = new Item();
            item.Name = result.Type;
            item.Quantity = result.Amount;
            item.ItemType = ItemTypeConstants.AlchemicalItem;

            return item;
        }
    }
}