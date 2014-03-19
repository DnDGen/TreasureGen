using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class AlchemicalItemGenerator : IAlchemicalItemGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileResultProvider;
        private IDice dice;

        public AlchemicalItemGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileResultProvider, IDice dice)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var result = typeAndAmountPercentileResultProvider.SelectFrom("AlchemicalItems", roll);

            var item = new Item();
            item.Name = result.Type;
            item.Quantity = dice.Roll(result.AmountToRoll);

            return item;
        }
    }
}