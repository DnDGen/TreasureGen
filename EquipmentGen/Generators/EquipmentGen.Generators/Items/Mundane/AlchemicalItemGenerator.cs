using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class AlchemicalItemGenerator : IMundaneItemGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IDice dice;

        public AlchemicalItemGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IDice dice)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.dice = dice;
        }

        public Item Generate()
        {
            var result = typeAndAmountPercentileSelector.SelectFrom("AlchemicalItems");

            var item = new Item();
            item.Name = result.Type;
            item.Quantity = dice.Roll(result.Amount);
            item.ItemType = ItemTypeConstants.AlchemicalItem;

            return item;
        }
    }
}