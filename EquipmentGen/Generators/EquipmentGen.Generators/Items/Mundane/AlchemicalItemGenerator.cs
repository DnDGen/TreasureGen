using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
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