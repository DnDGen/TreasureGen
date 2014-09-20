using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
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