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
        private ITypesProvider typesProvider;

        public AmmunitionGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice,
            ITypesProvider typesProvider)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
            this.typesProvider = typesProvider;
        }

        public Ammunition Generate()
        {
            var result = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult("Ammunition");

            var ammunition = new Ammunition();
            ammunition.Name = result.Type;
            ammunition.Quantity = result.Amount;
            ammunition.Types = typesProvider.GetTypesFor(ammunition.Name, "AmmunitionTypes");

            return ammunition;
        }
    }
}