using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class AlchemicalItemGenerator : IAlchemicalItemGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;

        public AlchemicalItemGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var result = typeAndAmountPercentileResultProvider.GetResultFrom("AlchemicalItems", roll);

            var item = new Item();
            item.Name = result.Type;
            item.Quantity = dice.Roll(result.AmountToRoll);

            return item;
        }
    }
}