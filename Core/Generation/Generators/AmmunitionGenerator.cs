using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class AmmunitionGenerator : IAmmunitionGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;
        private IAttributesProvider attributesProvider;

        public AmmunitionGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice,
            IAttributesProvider typesProvider)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
            this.attributesProvider = typesProvider;
        }

        public Item Generate()
        {
            var result = typeAndAmountPercentileResultProvider.GetResultFrom("Ammunition");

            var ammunition = new Item();
            ammunition.Name = result.Type;
            ammunition.Quantity = result.Amount;
            ammunition.Attributes = attributesProvider.GetAttributesFor(ammunition.Name, "AmmunitionAttributes");

            return ammunition;
        }
    }
}