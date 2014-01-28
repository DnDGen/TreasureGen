using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class AlchemicalItemGenerator : IAlchemicalItemGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;

        public AlchemicalItemGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
        }

        public AlchemicalItem Generate()
        {
            var result = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult("AlchemicalItems");

            var item = new AlchemicalItem();
            item.Name = result.Type;
            item.Quantity = result.Amount;

            return item;
        }
    }
}